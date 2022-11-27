using QAP.DataContext;
using QAP.Repository.Repositories.ProblemRepo;
using QAP.Repository.Repositories.SessionRepo;
using QAP.Repository.Repositories.PermutationRepo;
using QAP.Repository.Repositories.MultiverseRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QAP.Repository.Repositories.AlgorithmRepo;

namespace QAP.UnitOfWork.Factories;

public class RepositoryFactory
{
    private IQAPDBContext context;

    public RepositoryFactory(IQAPDBContext qAPDBContext)
    {
        context = qAPDBContext;
    }

    public ProblemRepo ProblemRepo
    {
        get
        {
            if (problemRepo is null)
            {
                problemRepo = new ProblemRepo(context);
            }

            return problemRepo;
        }
    }
    ProblemRepo problemRepo;

    public PermutationRepo PermutationRepo
    {
        get
        {
            if (permutationRepo is null)
            {
                permutationRepo = new PermutationRepo(context);
            }

            return permutationRepo;
        }
    }
    PermutationRepo permutationRepo;

    public SessionRepo SessionRepo
    {
        get
        {
            if (sessionRepo is null)
            {
                sessionRepo = new SessionRepo(context);
            }

            return sessionRepo;
        }
    }
    SessionRepo sessionRepo;

    public SessionAlgorithmVersionRepo SessionAlgorithmVersionRepo
    {
        get
        {
            if (sessionAlgorithmVersionRepo is null)
            {
                sessionAlgorithmVersionRepo = new SessionAlgorithmVersionRepo(context);
            }

            return sessionAlgorithmVersionRepo;
        }
    }
    SessionAlgorithmVersionRepo sessionAlgorithmVersionRepo;

    public MultiverseRepo MultiverseRepo
    {
        get
        {
            if (multiverseRepo is null)
            {
                multiverseRepo = new MultiverseRepo(context);
            }

            return multiverseRepo;
        }
    }
    MultiverseRepo multiverseRepo;

    public AlgorithmRepo AlgorithmRepo
    {
        get
        {
            if (algorithmRepo is not null)
            {
                algorithmRepo = new AlgorithmRepo(context);
            }

            return AlgorithmRepo;
        }
    }
    AlgorithmRepo algorithmRepo;

    public AlgorithmVersionRepo AlgorithmVersionRepo
    {
        get
        {
            if (algorithmVersionRepo is not null)
            {
                algorithmVersionRepo = new AlgorithmVersionRepo(context);
            }

            return AlgorithmVersionRepo;
        }
    }
    AlgorithmVersionRepo algorithmVersionRepo;
}
