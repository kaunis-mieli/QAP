using QAP.DataContext;
using QAP.MvvM.Problem;
using QAP.UnitOfWork.Helpers;
using QAP.UnitOfWork.UnitOfWork.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAP.UnitOfWork.UnitOfWork
{
    public class ProblemUnitOfWork : BaseUnitOfWork
    {


        private List<Problem> existingProblems;

        public ProblemUnitOfWork(IQAPDBContext context)
            : base(context)
        { }

        public List<string> GetAliases()
        {
            return Context.Problems
                .Select(x => x.Alias)
                .ToList();
        }

        public Problem GetProblem(string alias)
        {
            return Context.Problems.FirstOrDefault(problem => problem.Alias.ToLower().Equals(alias.ToLower()));
        }

        public void AddProblemWithOnePermutation(string alias, string title, string description, int size, byte[] binaryMatrixA, byte[] binaryMatrixB,
            long cost, byte[] permutation)
        {
            if (existingProblems is null)
            {
                existingProblems = Context.Problems.ToList();
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
                    InitialBestKnownCost = cost
                };

                existingProblems.Add(problem);

                Context.Problems.Add(problem);
            }
            else
            {
                throw new Exception($"{alias} already exists in database, so it will be skipped.");
            }
        }

        // TODO: unfinished
        public void LocalSearch(string alias, int iterations)
        {
            var problem = Context.Problems.FirstOrDefault(problem => problem.Alias.ToLower().Equals(alias.ToLower()));

            var session = new Session()
            {
                Problem = problem,
                SessionAlgorithms =
                {
                    new SessionAlgorithm()
                    {
                         AlgorithmId = (short)AlgorithmType.ClassicLocalSearchAlgorithm,
                    }
                }
            };

            

            Context.Sessions.Add(session);
            Save();
        }
    }
}
