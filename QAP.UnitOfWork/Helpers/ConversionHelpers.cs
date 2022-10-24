using QAP.DataContext;
using QAP.MvvM.Problem;
using QAP.MvvM.Solution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAP.UnitOfWork.Helpers
{
    public static class ConversionHelpers
    {
        public static List<ProblemModel> GetProblemModels(List<Problem> problems)
        {
            return problems
                .Select(problem => GetProblemModel(problem))
                .ToList();
        }

        public static ProblemModel GetProblemModel(Problem problem)
        {
            var totalElements = problem.Size * problem.Size;
            var matrixA = BinaryHelpers.ToOrigin<int[]>(problem.MatrixA);
            var matrixB = BinaryHelpers.ToOrigin<int[]>(problem.MatrixB);
            //var solutions = GetSolutionModels(problem.Size, problem.Solutions);

            //if (matrixA.Length != matrixB.Length || matrixA.Length != totalElements || matrixB.Length != totalElements)
            //{
            //    throw new ArgumentException($"Problem #{problem.Id} has wrong sized matrices. |MatrixA| = {matrixA.Length}, |MatrixB| = {matrixB.Length}, Should be {totalElements}");
            //}

            //return new ProblemModel()
            //{
            //    Size = problem.Size,
            //    MatrixA = matrixA,
            //    MatrixB = matrixB,
            //    Hash = problem.Hash,
            //    Alias = problem.Alias,
            //    Solutions = solutions,
            //    BestCost = solutions.Count > 0 ? solutions.Min(solution => solution.Cost) : null
            //};

            return null;
        }

        public static List<SolutionModel> GetSolutionModels(int permutationSizeShouldBe, IEnumerable<Solution> solutions)
        {
            return solutions
                .Select(solution => GetSolutionModel(permutationSizeShouldBe, solution))
                .ToList();
        }

        public static SolutionModel GetSolutionModel(int permutationSizeShouldBe, Solution solution)
        {
            var permutation = solution.Permutation is not null ? BinaryHelpers.ToOrigin<int[]>(solution.Permutation) : null;

            var toReturn = new SolutionModel();

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
