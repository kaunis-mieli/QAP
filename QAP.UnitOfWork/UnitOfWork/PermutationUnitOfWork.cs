using QAP.Core.Models.Permutation;
using QAP.Core.Models.Problem;
using QAP.DataContext;
using QAP.Repository.Repositories.ProblemRepo;
using QAP.UnitOfWork.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QAP.UnitOfWork.UnitOfWork;

public class PermutationUnitOfWork : BaseUnitOfWork
{
    private static Random randomNumberGenerator = new Random();

    public PermutationUnitOfWork(UoWFactory uoWFactory) : base(uoWFactory) { }

    public PermutationModel CreateRandomPermutation(ProblemModel problemInstanceModel)
    {
        var permutation = Enumerable.Range(0, problemInstanceModel.Size).ToArray();

        Shuffle(permutation);

        return new PermutationModel()
        {
            Value = permutation,
            Cost = CalculateCost(problemInstanceModel, permutation)
        };
    }

    public static long CalculateCost(ProblemModel problemModel, int[] permutation)
    {
        var cost = 0L;

        for (int i = 0; i < problemModel.Size; ++i)
        {
            for (int j = 0; j < problemModel.Size; ++j)
            {
                cost += problemModel.MatrixA[i, j] * problemModel.MatrixB[permutation[i], permutation[j]];
            }
        }

        return cost;
    }

    private static void Shuffle<T>(T[] values)
    {
        for (int i = values.Length - 1; i > 0; i--)
        {
            int k = randomNumberGenerator.Next(i + 1);
            T value = values[k];
            values[k] = values[i];
            values[i] = value;
        }
    }
}
