using QAP.DataContext;
using QAP.UnitOfWork.Factories;
using QAP.UnitOfWork.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAP.UnitOfWork.UnitOfWork
{
    public class ProblemInstanceUnitOfWork : BaseUnitOfWork
    {
        private List<ProblemInstance> existingProblems;

        public ProblemInstanceUnitOfWork(UoWFactory uoWFactory) : base(uoWFactory) { }

        //public List<string> GetAliases()
        //{
        //    return Context.ProblemInstances
        //        .Select(x => x.Alias)
        //        .ToList();
        //}

        //public ProblemInstance GetProblem(string alias)
        //{
        //    return Context.ProblemInstances.FirstOrDefault(problem => problem.Alias.ToLower().Equals(alias.ToLower()));
        //}

        //public void AddProblemWithOnePermutation(string alias, string title, string description, int size, byte[] binaryMatrixA, byte[] binaryMatrixB,
        //    long cost, byte[] permutation)
        //{
        //    if (existingProblems is null)
        //    {
        //        existingProblems = Context.ProblemInstances.ToList();
        //    }

        //    var hash = BinaryHelpers.GetHash(Enumerable.Concat(binaryMatrixA, binaryMatrixB));

        //    if (!existingProblems.Any(pm => Enumerable.SequenceEqual(pm.Hash, hash)) &&
        //        !existingProblems.Any(pm => pm.Alias.ToLower().Equals(alias.ToLower())))
        //    {
        //        var problem = new ProblemInstance()
        //        {
        //            Alias = alias,
        //            Title = title,
        //            Description = description,
        //            Hash = hash,
        //            Size = size,
        //            MatrixA = binaryMatrixA,
        //            MatrixB = binaryMatrixB,
        //            InitialBestKnownCost = cost
        //        };

        //        existingProblems.Add(problem);

        //        Context.ProblemInstances.Add(problem);
        //    }
        //    else
        //    {
        //        throw new Exception($"{alias} already exists in database, so it will be skipped.");
        //    }
        //}

        //// TODO: unfinished
        //public SolutionModel LocalSearch(string alias, int iterations)
        //{
        //    var problem = Context.ProblemInstances.FirstOrDefault(problem => problem.Alias.ToLower().Equals(alias.ToLower()));

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
        //            ProblemInstance = problem
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
