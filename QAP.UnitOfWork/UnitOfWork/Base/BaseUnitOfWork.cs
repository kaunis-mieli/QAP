using QAP.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAP.UnitOfWork.UnitOfWork.Base
{
    public abstract class BaseUnitOfWork
    {
        protected IQAPDBContext Context { get; set; }

        public BaseUnitOfWork(IQAPDBContext context)
        {
            Context = context;
        }

        public void Save()
        {
            Context.SaveChanges();
        } 
    }
}
