using QAP.UnitOfWork.Factories;
using QAP.UnitOfWork.Helpers;
using QAP.UnitOfWork.UnitOfWork.Algorithm;
using QAP.UnitOfWork.UnitOfWork.Algorithm.LocalSearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAP.UnitOfWork.UnitOfWork;

public class ProblemSolverUnitOfWork : BaseUnitOfWork
{
    public ProblemSolverUnitOfWork(UoWFactory _parentFactory) : base(_parentFactory) {
    }

    /// <summary>
    /// Sets internal algorithm strategy and returns current instance of ProblemSolverUnitOfWork.
    /// </summary>
    /// <returns>Current instance</returns>
    public void Solve(string problemAlias, int repeat)
    {
        var problemModel = ConversionHelpers.GetProblemModel(
            parentFactory.RepositoryFactory.ProblemRepo.GetProblemByAlias(problemAlias));

        var algorithm = new LocalSearch001(new LocalSearch001Config() { Iterations = 100 }, parentFactory);
        algorithm.Solve(problemModel);

        parentFactory.ProblemSolverUnitOfWork.Save();
    }

    public void SolveMultiverse(int multiverseId)
    {
        // Get Multiverse
    }
}
