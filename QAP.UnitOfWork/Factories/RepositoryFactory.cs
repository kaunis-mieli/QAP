using QAP.DataContext;
using QAP.Repository.Repositories.ProblemRepo;
using QAP.Repository.Repositories.SessionRepo;
using QAP.Repository.Repositories.SolutionRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAP.UnitOfWork.Factories
{
    public class RepositoryFactory
    {
        private IQAPDBContext context;

        public RepositoryFactory(IQAPDBContext qAPDBContext)
        {
            context = qAPDBContext;
        }

        public ProblemInstanceRepo ProblemInstanceRepo 
        { 
            get
            { 
                if (problemInstanceRepo == null)
                {
                    problemInstanceRepo = new ProblemInstanceRepo(context);
                }

                return problemInstanceRepo;
            } 
        }
        ProblemInstanceRepo problemInstanceRepo;

        public PermutationRepo PermutationRepo
        {
            get
            {
                if (permutationRepo == null)
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
                if (sessionRepo == null)
                {
                    sessionRepo = new SessionRepo(context);
                }

                return sessionRepo;
            }
        }
        SessionRepo sessionRepo;


    }
}
