using QAP.DataContext;
using QAP.UnitOfWork.Factories;
using QAP.UnitOfWork.Helpers;
using QAP.UnitOfWork.UnitOfWork;
using System.Text.RegularExpressions;

namespace QAP.Importer;

internal class Importer
{
    private readonly UoWFactory uoWFactory;

    public Importer(UoWFactory _uoWFactory)
    {
        uoWFactory = _uoWFactory;
    }

    public void Import(string directory)
    {
        foreach (var file in Directory.GetFiles(directory))
        {
            ProcessFile(file);
        }

        uoWFactory.ProblemInstanceUnitOfWork.Save();
    }

    private void ProcessFile(string file)
    {
        try
        {
            var parsedLines = ParseLines(file);

            Validate(parsedLines, file);

            SerializeMatrices(parsedLines, out byte[] binaryMatrixA, out byte[] binaryMatrixB);

            var shortName = Path.GetFileNameWithoutExtension(file);

            //problemUnitOfWork.AddProblemWithOnePermutation(shortName.ToLower(), $"{shortName.ToUpper()}: N = {parsedLines[0][0]}", null,
            //    parsedLines[0][0], binaryMatrixA, binaryMatrixB, parsedLines[0][1], null);

            Console.Write(".");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
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
            throw new ArgumentException($"{file} is broken, cannot be read.");
        }
    }

    private static string RemoveWhitespaces(string dirtyString)
    {
        return Regex.Replace(dirtyString, @"\s+", " ");
    }
}
