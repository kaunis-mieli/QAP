using Microsoft.EntityFrameworkCore;
using QAP.Core.DTO.Problem;
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

    public List<ProblemRecordDTO> GetAllAliases()
    {
        return context.Problems
            .Select(problem => new ProblemRecordDTO() 
            { 
                Id = problem.Id, 
                Alias = problem.Alias, 
                Hash = problem.Hash 
            }).ToList();
    }

    public List<ProblemRecordDTO> GetAllProblemRecords()
    {
        return context.Problems
            .Select(problem => new ProblemRecordDTO(problem.Id, problem.Alias, problem.Hash))
            .ToList();
    }

    public Problem? GetProblemByAlias(string alias)
    {
        return context.Problems
            .FirstOrDefault(problem => problem.Alias.Equals(alias));
    }

    public List<Problem> GetProblemsByIds(List<int> ids)
    {
        return context.Problems
            .Where(problem => ids.Contains(problem.Id))
            .ToList();
    }
}
