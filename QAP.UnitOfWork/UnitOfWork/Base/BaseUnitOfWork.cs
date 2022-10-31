using QAP.DataContext;
using QAP.UnitOfWork.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAP.UnitOfWork.UnitOfWork
{
    public abstract class BaseUnitOfWork
    {
        internal UoWFactory parentFactory { get; set; }

        protected BaseUnitOfWork(UoWFactory _parentFactory)
        {
            parentFactory = _parentFactory;
        }

        public void Save()
        {
            parentFactory.Context.SaveChanges();
        } 
    }
}
