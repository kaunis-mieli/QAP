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
    public class AlgorithmRepo : BaseRepository<const_Algorithm>
    {
        public AlgorithmRepo(IQAPDBContext context) : base(context) { }

        public const_Algorithm? GetAlgorithmWithVersions(string algorithmAlias)
        {
            return context.const_Algorithms
                .Include(algorithm => algorithm.AlgorithmVersions)
                .FirstOrDefault(algorithm => algorithm.Alias.Equals(algorithmAlias));
        }

        // TODO: crashes, stack overflow.
        public List<const_Algorithm> GetAlgorithmsWithVersions()
        {
            return context.const_Algorithms
                .Include(algorithm => algorithm.AlgorithmVersions)
                .ToList();
        }
    }
}
