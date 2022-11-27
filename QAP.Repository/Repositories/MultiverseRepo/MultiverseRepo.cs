using Microsoft.EntityFrameworkCore;
using QAP.Core.Constants;
using QAP.DataContext;
using QAP.Repository.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAP.Repository.Repositories.MultiverseRepo;

public class MultiverseRepo : BaseRepository<Multiverse>
{
    public MultiverseRepo(IQAPDBContext context) : base(context) { }

    public Multiverse? GetMultiverseById(int multiverseId)
    {
        return context.Multiverses
            .Where(multiverse => multiverse.Id == multiverseId)
            .Include(multiverse => multiverse.Sessions)
                .ThenInclude(session => session.SessionAlgorithmVersions)
                    .ThenInclude(sav => sav.AlgorithmVersion)
                        .ThenInclude(av => av.const_Algorithm)
            .Include(multiverse => multiverse.Sessions)
                .ThenInclude(session => session.Problem)
            .FirstOrDefault();
    }
}
