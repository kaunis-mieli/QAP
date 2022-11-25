using Microsoft.EntityFrameworkCore;
using QAP.DataContext;
using QAP.Repository.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAP.Repository.Repositories.PermutationRepo;

public class PermutationRepo : BaseRepository<Permutation>
{
    public PermutationRepo(IQAPDBContext context) : base(context) { }
}
