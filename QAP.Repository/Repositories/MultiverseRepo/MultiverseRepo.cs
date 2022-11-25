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

public class MultiverseRepo : BaseRepository<Permutation>
{
    public MultiverseRepo(IQAPDBContext context) : base(context) { }

    public Multiverse? GetMultiverseWithQueuedSessionsById(int multiverseId)
    {
        return context.Multiverses
            .Where(multiverse => multiverse.Id == multiverseId)
            .Include(multiverse => multiverse.Sessions)
                .ThenInclude(session => session.SessionAlgorithmVersions.Where(sav => sav.const_State.Id == State.Queued))
                    .ThenInclude(sav => sav.AlgorithmVersion)
                        .ThenInclude(av => av.const_Algorithm)
            .FirstOrDefault();
    }
}
