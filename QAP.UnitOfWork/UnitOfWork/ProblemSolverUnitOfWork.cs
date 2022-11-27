using QAP.Core.Constants;
using QAP.Core.DTO.Algorithm;
using QAP.Core.DTO.Solve;
using QAP.DataContext;
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
    public ProblemSolverUnitOfWork(UoWFactory _parentFactory) : base(_parentFactory) { }


    public SolveRequestResponseDTO EnqueueSessions(SolveRequestDTO solveRequest)
    {
        var toReturn = new SolveRequestResponseDTO();

        var problems = parentFactory.RepositoryFactory.ProblemRepo.GetProblemsByIds(solveRequest.ProblemIds);
        var algorithmVersions = parentFactory.RepositoryFactory.AlgorithmVersionRepo
            .GetAlgorithmVersionsByIds(solveRequest.AlgorithmVersions.Select(av => av.AlgorithmVersionId).ToList());

        if (problems.Any() && algorithmVersions.Any())
        {
            var multiverse = new Multiverse()
            {
                Sessions = problems.Select(problem => new Session()
                {
                    ProblemId = problem.Id,
                    SessionAlgorithmVersions = HandleSessionAlgorithmVersions(solveRequest.AlgorithmVersions)
                }).ToList()
            };

            parentFactory.RepositoryFactory.MultiverseRepo.Insert(multiverse);
            parentFactory.ProblemSolverUnitOfWork.Save();

            toReturn.MultiverseId = multiverse.Id;
        }
        else
        {
            throw new ArgumentException($"Not found any problems and/or algorithm versions. |Problems| = {problems.Count}, " +
                $"|AlgorithmVersions| = {algorithmVersions.Count}");
        }

        return toReturn;
    }

    public void Solve(int multiverseId)
    {
        var multiverse = parentFactory.RepositoryFactory.MultiverseRepo.GetMultiverseById(multiverseId);

        if (multiverse is not null)
        {
            foreach (var session in multiverse.Sessions)
            {
                foreach (var sessionAlgorithmVersion in session.SessionAlgorithmVersions)
                {
                    var worker = AlgorithmFactory.Resolve(sessionAlgorithmVersion, parentFactory);
                    worker.Solve();
                }
            }
        }
        
    }

    private List<SessionAlgorithmVersion> HandleSessionAlgorithmVersions(List<AlgorithmVersionRequest> algorithmVersionRequests)
    {
        var toReturn = new List<SessionAlgorithmVersion>();

        foreach (var algorithmVersionRequest in algorithmVersionRequests)
        {
            if (algorithmVersionRequest.SeedsForInstances.Count == 0)
            {
                algorithmVersionRequest.SeedsForInstances.Add(null);
            }

            toReturn.AddRange(algorithmVersionRequest.SeedsForInstances.Select(seed => new SessionAlgorithmVersion()
            {
                Seed = seed is not null ? seed.Value : Random.Shared.Next(),
                StateId = State.Queued
            }));
        }

        return toReturn;
    }
}
