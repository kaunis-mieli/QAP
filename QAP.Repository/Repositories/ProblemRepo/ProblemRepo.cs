using QAP.DataContext;
using QAP.Repository.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAP.Repository.Repositories.ProblemRepo
{
    public class ProblemRepo : BaseRepository<Problem>
    {
        public ProblemRepo(IQAPDBContext context) : base(context)
        {
        }

        public List<Problem> GetAll()
        {
            return context.Problems.ToList();
        }

        public void Add(string text)
        {
            Insert(new Problem()
            {
                MatrixA = Encoding.UTF8.GetBytes(text),
                MatrixB = Encoding.UTF8.GetBytes(text)
            });
        }
    }
}
