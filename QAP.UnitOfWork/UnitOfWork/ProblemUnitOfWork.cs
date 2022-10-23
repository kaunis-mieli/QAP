using QAP.DataContext;
using QAP.MvvM.Problem;
using QAP.Repository.Repositories.ProblemRepo;
using QAP.UnitOfWork.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAP.UnitOfWork.UnitOfWork
{
    public class ProblemUnitOfWork
    {
        private readonly ProblemRepo problemRepo;

        private List<Problem> existingProblems;

        public ProblemUnitOfWork(ProblemRepo problemRepo)
        {
            this.problemRepo = problemRepo;
        }

        public List<ProblemModel> GetAllProblemsShallow()
        {
            return ConversionHelpers.GetProblemModels(problemRepo.GetAllShallow());
        }

        public List<string> GetAliases()
        {
            return problemRepo.GetAliases();
        }

        public void AddProblemWithOnePermutation(string alias, string title, string description, int size, byte[] binaryMatrixA, byte[] binaryMatrixB,
            long cost, byte[] permutation)
        {
            if (existingProblems is null)
            {
                existingProblems = problemRepo.GetAllShallow();
            }

            var hash = BinaryHelpers.GetHash(Enumerable.Concat(binaryMatrixA, binaryMatrixB));

            if (!existingProblems.Any(pm => Enumerable.SequenceEqual(pm.Hash, hash)) && 
                !existingProblems.Any(pm => pm.Alias.ToLower().Equals(alias.ToLower())))
            {
                var problem = new Problem()
                {
                    Alias = alias,
                    Title = title,
                    Description = description,
                    Hash = hash,
                    Size = size,
                    MatrixA = binaryMatrixA,
                    MatrixB = binaryMatrixB,
                    Solutions = {
                            new Solution() {
                                Cost = cost,
                                Permutation = permutation,
                            }
                        }
                };
                existingProblems.Add(problem);
                problemRepo.Insert(problem);
            }
            else
            {
                throw new Exception($"{alias} already exists in database, so it will be skipped.");
            }
        }

        public ProblemModel GetProblemWithSolutionsByAlias(string alias)
        {
            return ConversionHelpers.GetProblemModel(problemRepo.GetProblemWithSolutionsByAlias(alias));
        }

        public void Save()
        {
            problemRepo.Save();
        }
    }
}
