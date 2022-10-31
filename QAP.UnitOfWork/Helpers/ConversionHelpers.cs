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
        public static List<ProblemModel> GetProblemModels(List<ProblemInstance> problems)
        {
            return problems
                .Select(problem => GetProblemModel(problem))
                .ToList();
        }

        public static ProblemModel GetProblemModel(ProblemInstance problem)
        {
            var totalElements = problem.Size * problem.Size;
            var matrixA = BinaryHelpers.ToOrigin<int[]>(problem.MatrixA);
            var matrixB = BinaryHelpers.ToOrigin<int[]>(problem.MatrixB);

            if (matrixA.Length != matrixB.Length || matrixA.Length != totalElements || matrixB.Length != totalElements)
            {
                throw new ArgumentException($"Problem #{problem.Id} has wrong sized matrices. |MatrixA| = {matrixA.Length}, |MatrixB| = {matrixB.Length}, Should be {totalElements}");
            }

            return new ProblemModel()
            {
                Size = problem.Size,
                MatrixA = matrixA,
                MatrixB = matrixB,
            };
        }

        public static List<PermutationModel> GetSolutionModels(int permutationSizeShouldBe, IEnumerable<Permutation> solutions)
        {
            return solutions
                .Select(solution => GetSolutionModel(permutationSizeShouldBe, solution))
                .ToList();
        }

        public static PermutationModel GetSolutionModel(int permutationSizeShouldBe, Permutation solution)
        {
            var permutation = solution.Value is not null ? BinaryHelpers.ToOrigin<int[]>(solution.Value) : null;

            var toReturn = new PermutationModel();

            if (permutation is null || permutation.Length == permutationSizeShouldBe)
            {
                toReturn.Permutation = permutation;
                toReturn.Cost = solution.Cost;
            }
            else
            {
                throw new ArgumentException($"Solution #{solution.Id} has wrong size Permutation of {permutation.Length}. Should be {permutationSizeShouldBe}.");
            }

            return toReturn;
        }
    }
}
