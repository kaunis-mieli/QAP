using MessagePack;
using QAP.Core.Models.Permutation;
using QAP.Core.Models.Problem;
using QAP.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAP.UnitOfWork.Helpers
{
    public static class ConversionHelpers
    {
        public static List<ProblemModel> GetProblemInstanceModels(List<Problem> problem)
        {
            return problem
                .Select(problem => GetProblemModel(problem))
                .ToList();
        }

        public static ProblemModel GetProblemModel(Problem problem)
        {
            ProblemModel toReturn = null;

            if (problem is not null)
            {
                var matrixA = MessagePackSerializer.Deserialize<int[]>(problem.MatrixA);
                var matrixB = MessagePackSerializer.Deserialize<int[]>(problem.MatrixB);

                toReturn = new ProblemModel()
                {
                    Alias = problem.Alias,
                    Size = problem.Size,
                    MatrixA = new MatrixWrapper(matrixA, problem.Size),
                    MatrixB = new MatrixWrapper(matrixB, problem.Size),
                    InitialBestKnownCost = problem.InitialBestKnownCost
                };
            }

            return toReturn;
        }

        public static List<PermutationModel> GetPermutationModels(int permutationSizeShouldBe, 
            IEnumerable<Permutation> solutions)
        {
            return solutions
                .Select(solution => GetPermutationModel(permutationSizeShouldBe, solution))
                .ToList();
        }

        public static PermutationModel GetPermutationModel(int permutationSizeShouldBe, 
            Permutation permutation)
        {
            var value = permutation.Value is not null ? 
                MessagePackSerializer.Deserialize<int[]>(permutation.Value) : null;

            var toReturn = new PermutationModel();

            if (value is not null && value.Length == permutationSizeShouldBe)
            {
                toReturn.Value = value;
                toReturn.Cost = permutation.Cost;
            }
            else
            {
                throw new ArgumentException($"Permutation #{permutation.Id} has wrong size. " +
                    $"Should be {permutationSizeShouldBe}.");
            }

            return toReturn;
        }
    }
}
