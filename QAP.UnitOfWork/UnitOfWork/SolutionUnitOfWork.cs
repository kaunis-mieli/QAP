using QAP.DataContext;
using QAP.MvvM.Problem;
using QAP.MvvM.Solution;
using QAP.Repository.Repositories.ProblemRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QAP.UnitOfWork.UnitOfWork
{
    public class SolutionUnitOfWork
    {
        private readonly ProblemRepo problemRepo;
        private static Random randomNumberGenerator = new Random();

        public SolutionUnitOfWork(ProblemRepo problemRepo)
        {
            this.problemRepo = problemRepo;
        }

        public SolutionModel CreateRandomSolution(ProblemModel problem)
        {
            var permutation = Enumerable.Range(0, problem.Size).ToArray();

            Shuffle(permutation);

            return new SolutionModel()
            {
                Permutation = permutation,
                Cost = CalculateCost(problem, permutation)
            };
        }

        private static long CalculateCost(ProblemModel problem, int[] permutation)
        {
            var cost = 0l;

            for (int i = 0; i < problem.Size; ++i)
            {
                for (int j = 0; j < problem.Size; ++j)
                {
                    cost += problem.MatrixA[i + j * problem.Size] * problem.MatrixB[permutation[i] + permutation[j * problem.Size]];
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

}
