using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using QAP.UnitOfWork.Helpers;

namespace QAP.Importer;

internal class Importer
{
    public static void Import()
    {
        var lines = File.ReadAllLines(@"Data\esc128.dat")
            .Where(line => line.Trim().Length > 0)
            .Select(line => line.Trim())
            .ToList();

        Console.WriteLine($"File read. {lines.Count} lines");

        var size = Convert.ToInt32(lines.First());

        if ((size * 2 + 1) == lines.Count)
        {
            var matrixA = ToOneDimensionMatrix(lines, size, 1);
            var matrixB = ToOneDimensionMatrix(lines, size, 1 + size);

            if (matrixA.Length == matrixB.Length && matrixA.Length == size * size)
            {
                var a = BinaryHelpers.ToBytes(matrixA);
                var b = BinaryHelpers.ToBytes(matrixB);

                Console.WriteLine("A: " + BitConverter.ToString(a));
                Console.WriteLine("B: " + BitConverter.ToString(b));
            }
            else
            {
                throw new ArgumentException("Wrong data input dimension.");
            }
        }
        else
        {
            throw new ArgumentException("Wrong data input dimension.");
        }
    }

    private static double[] ToOneDimensionMatrix(List<string> lines, int size, int skipSize)
    {
        return lines
            .Skip(skipSize)
            .Take(size)
            .SelectMany(line => line
                .Split(' ')
                .Select(str => double.Parse(str))
                .ToArray())
            .ToArray();
    }
}
