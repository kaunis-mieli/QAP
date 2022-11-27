using MessagePack;
using Microsoft.VisualBasic;
using QAP.Core.DTO.Algorithm;
using QAP.Core.Models.Permutation;
using QAP.Core.Models.Problem;
using QAP.DataContext;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAP.UnitOfWork.Helpers
{
    public static class ConversionHelpers
    {
        public static List<AlgorithmDTO> GetAlgorithmDTOs(IEnumerable<const_Algorithm> algorithms)
        {
            return algorithms
                .Select(x => new AlgorithmDTO())
                .ToList();
        }

        public static AlgorithmDTO GetAlgorithmDTO(const_Algorithm algorithm)
        {
            var toReturn = new AlgorithmDTO()
            {
                Id = algorithm.Id,
                Alias = algorithm.Alias,
                Title = algorithm.Title,
                Description = algorithm.Description
            };

            if (algorithm.AlgorithmVersions is not null)
            {
                toReturn.AlgorithmVersionDTOs = GetAlgorithmVersionDTOs(algorithm.AlgorithmVersions);
            }

            return toReturn;
        }

        public static List<AlgorithmVersionDTO> GetAlgorithmVersionDTOs(IEnumerable<AlgorithmVersion> algorithmVersions)
        {
            return algorithmVersions
                .Select(algorithmVersion => GetAlgorithmVersionDTO(algorithmVersion))
                .ToList();
        }

        public static AlgorithmVersionDTO GetAlgorithmVersionDTO(AlgorithmVersion algorithmVersion)
        {
            return new AlgorithmVersionDTO()
            {
                Id = algorithmVersion.Id,
                Alias = algorithmVersion.Alias,
                Title = algorithmVersion.Title,
                Description = algorithmVersion.Description
            };
        }


        public static List<ProblemModel> GetProblemModels(List<Problem> problem)
        {
#pragma warning disable CS8619 // Nullability of reference types in value doesn't match target type.
            return problem
                .Select(problem => GetProblemModel(problem))
                .ToList();
#pragma warning restore CS8619 // Nullability of reference types in value doesn't match target type.
        }

        public static ProblemModel? GetProblemModel(Problem problem)
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
