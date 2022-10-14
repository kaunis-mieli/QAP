using QAP.DataContext;
using QAP.Repository.Repositories.ProblemRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAP.UnitOfWork.UnitOfWork
{
    public class ImportUnitOfWork
    {
        private readonly ProblemRepo problemRepo;

        public ImportUnitOfWork(ProblemRepo problemRepo)
        {
            this.problemRepo = problemRepo;
        }

        public void CreateProblem(Problem problem)
        {
            problemRepo.Insert(problem);
        }

        public List<Problem> GetAllProblems()
        {
            return problemRepo.GetAll();
        }

        public void Save()
        {
            problemRepo.Save();
        }
    }
}
