using Microsoft.EntityFrameworkCore;
using QAP.Core.Models.Problem;
using QAP.DataContext;
using QAP.Repository.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAP.Repository.Repositories.ProblemRepo;

public class ProblemRepo : BaseRepository<Problem>
{
    public ProblemRepo(IQAPDBContext context) : base(context) { }

    public List<string> GetAllAliases()
    {
        return context.Problems
            .Select(problem => problem.Alias)
            .ToList();
    }

    public List<ProblemRecord> GetAllProblemRecords()
    {
        return context.Problems
            .Select(problem => new ProblemRecord(problem.Alias, problem.Hash))
            .ToList();
    }

    public Problem? GetProblemByAlias(string alias)
    {
        return context.Problems
            .FirstOrDefault(problem => problem.Alias.Equals(alias));
    }

    public void Add(Problem problem)
    {
        context.Problems.Add(problem);
    }
}
