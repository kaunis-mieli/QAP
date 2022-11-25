using QAP.DataContext;
using QAP.Repository.Repositories.ProblemRepo;
using QAP.UnitOfWork.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAP.UnitOfWork.Factories
{
    public class UoWFactory : IDisposable
    {
        internal IQAPDBContext Context;
        internal RepositoryFactory RepositoryFactory;

        public UoWFactory(IQAPDBContext context)
        {
            Context = context;
            RepositoryFactory = new RepositoryFactory(context);
        }

        public ProblemUnitOfWork ProblemUnitOfWork
        {
            get
            {
                if (problemInstanceUnitOfWork is null)
                {
                    problemInstanceUnitOfWork = new ProblemUnitOfWork(this);
                }

                return problemInstanceUnitOfWork;
            }
        }
        ProblemUnitOfWork problemInstanceUnitOfWork;

        public ProblemSolverUnitOfWork ProblemSolverUnitOfWork
        {
            get
            {
                if (problemSolverUnitOfWork is null)
                {
                    problemSolverUnitOfWork = new ProblemSolverUnitOfWork(this);
                }

                return problemSolverUnitOfWork;
            }
        }
        ProblemSolverUnitOfWork problemSolverUnitOfWork;

        public PermutationUnitOfWork PermutationUnitOfWork
        {
            get
            {
                if (permutationUnitOfWork is null)
                {
                    permutationUnitOfWork = new PermutationUnitOfWork(this);
                }

                return permutationUnitOfWork;
            }
        }
        PermutationUnitOfWork permutationUnitOfWork;

        public void Dispose()
        {
            Context = null;
            RepositoryFactory = null;
        }
    }
}
