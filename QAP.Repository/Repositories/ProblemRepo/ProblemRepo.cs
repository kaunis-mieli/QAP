using Microsoft.EntityFrameworkCore;
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
        public ProblemRepo(IQAPDBContext context) : base(context) { }

        public List<Problem> GetAllShallow()
        {
            return context.Problems.ToList();
        }

        public Problem GetProblemByAliasShallow(string alias)
        {
            return context.Problems
                .Where(problem => problem.Alias.ToLower().Equals(alias.ToLower()))
                .First();
        }

        public List<string> GetAliases()
        {
            return context.Problems
                .Select(x => x.Alias)
                .ToList();
        } 
    }
}
