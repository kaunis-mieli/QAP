using QAP.Core.Models.Problem;
using QAP.DataContext;
using QAP.UnitOfWork.Factories;
using QAP.UnitOfWork.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QAP.UnitOfWork.UnitOfWork
{
    public class ProblemUnitOfWork : BaseUnitOfWork
    {
        private List<ProblemRecord> existingProblems;

        public ProblemUnitOfWork(UoWFactory uoWFactory) : base(uoWFactory) { }

        public List<string> GetAliases()
        {
            return parentFactory.RepositoryFactory.ProblemRepo.GetAllAliases();
        }

        public ProblemModel GetProblemByAlias(string alias)
        {
            return ConversionHelpers.GetProblemModel(
                parentFactory.RepositoryFactory.ProblemRepo.GetProblemByAlias(alias));
        }

        public void InsertProblem(string alias, string title, string description, int size, 
            byte[] binaryMatrixA, byte[] binaryMatrixB, long cost)
        {

            if (existingProblems is null)
            {
                existingProblems = parentFactory.RepositoryFactory.ProblemRepo.GetAllProblemRecords();
            }

            var hash = SHA1.Create()
                .ComputeHash(Enumerable.Concat(binaryMatrixA, binaryMatrixB)
                .ToArray());

            if (!existingProblems.Any(pm => Enumerable.SequenceEqual(pm.Hash, hash)) &&
                !existingProblems.Any(pm => pm.Alias.Equals(alias)))
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
                    InitialBestKnownCost = cost
                };

                parentFactory.RepositoryFactory.ProblemRepo.Insert(problem);

                existingProblems.Add(new ProblemRecord(alias, hash));
            }
            else
            {
                throw new Exception($"{alias} already exists in database, so it will be skipped");
            }
        }

        //// TODO: unfinished
        //public SolutionModel LocalSearch(string alias, int iterations)
        //{
        //    var problem = Context.Problems.FirstOrDefault(problem => problem.Alias.ToLower().Equals(alias.ToLower()));

        //    if (problem is not null)
        //    {
        //        var problemModel = ConversionHelpers.GetProblemModel(problem);

        //        var initialSolution = permutationUnitOfWork.CreateRandomSolution(problemModel);

        //        var solutions = new List<Permutation>()
        //        {
        //            new Permutation()
        //            {
        //                Cost = initialSolution.Cost,
        //                Value = BinaryHelpers.ToBytes(initialSolution.Permutation)
        //            }
        //        };

        //        // TODO: perform calculations

        //        var session = new Session()
        //        {
        //            Problem = problem
        //        };

        //        Context.Sessions.Add(session);
        //        Save();

        //        //return initialSolutionę;
        //    }
        //    else
        //    {
        //        throw new ArgumentException($"Problem by alias = {problem.Alias} was not found!");
        //    }

        //    return null;
        //}
    }
}
