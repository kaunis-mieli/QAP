using QAP.DataContext;
using QAP.Repository.Repositories.ProblemRepo;
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
        public ProblemUnitOfWork(ProblemRepo problemRepo)
        {
            this.problemRepo = problemRepo;
        }

        public List<Problem> GetAll()
        {
            return problemRepo.GetAll();
        }

        public void Insert(string text)
        {
            problemRepo.Add(text);
            problemRepo.Save();
        }
    }
}
