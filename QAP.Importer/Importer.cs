using QAP.DataContext;
using QAP.UnitOfWork.Helpers;
using QAP.UnitOfWork.UnitOfWork;
using System.Text.RegularExpressions;

namespace QAP.Importer;

internal class Importer
{
    private readonly ImportUnitOfWork importUnitOfWork;

    private List<Problem> existingProblems;

    public Importer(ImportUnitOfWork importUnitOfWork)
    {
        this.importUnitOfWork = importUnitOfWork;
    }

    public void Import(string directory)
    {
        existingProblems = importUnitOfWork.GetAllProblems();

        foreach (var file in Directory.GetFiles(directory))
        {
            ProcessFile(file);
        }

        importUnitOfWork.Save();
    }

    private void ProcessFile(string file)
    {
        try
        {
            var parsedLines = ParseLines(file);

            Validate(parsedLines, file);

            byte[] serializedMatrixA, serializedMatrixB;
            SerializeMatrices(parsedLines, out serializedMatrixA, out serializedMatrixB);

            var hash = BinaryHelpers.GetHash(Enumerable.Concat(serializedMatrixA, serializedMatrixB));

            ProcessProblem(file, parsedLines, serializedMatrixA, serializedMatrixB, hash);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private void ProcessProblem(string file, List<int[]> parsedLines, byte[] serializedMatrixA, byte[] serializedMatrixB, byte[] hash)
    {
        if (!existingProblems.Any(problem => Enumerable.SequenceEqual(problem.Hash, hash)))
        {
            var shortName = Path.GetFileNameWithoutExtension(file);

            var problem = new Problem()
            {
                Size = parsedLines[0][0],
                Title = $"{shortName.ToUpper()}: N = {parsedLines[0][0]}",
                Alias = shortName.ToLower(),
                Hash = hash,
                MatrixA = serializedMatrixA,
                MatrixB = serializedMatrixB
            };

            if (parsedLines[0].Length > 1)
            {
                problem.Solutions.Add(new Solution() { Cost = parsedLines[0][1] });
            }

            importUnitOfWork.CreateProblem(problem);
            existingProblems.Add(problem);

            Console.Write($".");
        }
        else
        {
            throw new Exception($"{file} already exists in database, so it will be skipped.");
        }
    }

    private static void SerializeMatrices(List<int[]> parsedLines, out byte[] serializedMatrixA, out byte[] serializedMatrixB)
    {
        var matrixA = parsedLines
            .Skip(1)
            .Take(parsedLines[0][0])
            .SelectMany(x => x)
            .ToArray();

        var matrixB = parsedLines
            .Skip(1 + parsedLines[0][0])
            .Take(parsedLines[0][0])
            .SelectMany(x => x)
            .ToArray();

        serializedMatrixA = BinaryHelpers.ToBytes(matrixA);
        serializedMatrixB = BinaryHelpers.ToBytes(matrixB);
    }

    private static List<int[]> ParseLines(string file)
    {
        return File.ReadAllLines(file)
            .Select(line => RemoveWhitespaces(line).Trim())
            .Where(line => line.Length > 0)
            .Select(line => line.Split().Select(part => int.Parse(part)).ToArray())
            .ToList();
    }

    private static void Validate(List<int[]> parsedLines, string file)
    {
        if (parsedLines.Count != parsedLines[0][0] * 2 + 1 ||
            parsedLines.Skip(1).Any(inlinedArray => inlinedArray.Length != parsedLines[0][0]))
        {
            throw new ArgumentException($"{file} has wrong is broken, cannot be ready.");
        }
    }

    private static string RemoveWhitespaces(string dirtyString)
    {
        return Regex.Replace(dirtyString, @"\s+", " ");
    }
}
