using QAP.DataContext;
using QAP.Repository.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAP.Repository.Repositories.SessionRepo;

public class SessionRepo : BaseRepository<Session>
{
    public SessionRepo(IQAPDBContext context) : base(context) { }
}
