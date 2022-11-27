using Microsoft.EntityFrameworkCore;
using QAP.DataContext;
using QAP.Repository.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAP.Repository.Repositories.AlgorithmRepo
{
    public class AlgorithmVersionRepo : BaseRepository<AlgorithmVersion>
    {
        public AlgorithmVersionRepo(IQAPDBContext context) : base(context) { }

        public AlgorithmVersion? GetAlgorithmVersion(string algorithmAlias, string versionAlias)
        {
            return context.AlgorithmVersions
                    .Include(av => av.const_Algorithm)
                .FirstOrDefault(av => av.const_Algorithm.Alias.Equals(algorithmAlias) &&
                    av.Equals(versionAlias));
        }

        public AlgorithmVersion? GetAlgorithmVersion(int algorithmVersionId)
        {
            return context.AlgorithmVersions
                    .Include(av => av.const_Algorithm)
                .FirstOrDefault(av => av.Id == algorithmVersionId);
        }

        public List<AlgorithmVersion> GetAlgorithmVersionsByIds(List<int> ids)
        {
            return context.AlgorithmVersions
                .Where(av => ids.Contains(av.Id))
                .ToList();
        }
    }
}
