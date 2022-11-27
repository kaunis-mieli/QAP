using QAP.Core.Models.Problem;
using QAP.DataContext;
using QAP.UnitOfWork.Factories;
using QAP.UnitOfWork.UnitOfWork.Algorithm.LocalSearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAP.UnitOfWork.UnitOfWork.Algorithm
{
    public abstract class Algorithm<T> : IAlgorithm
        where T : IAlgorithmConfig
    {
        public T Configuration { get; protected set; }

        protected UoWFactory uoWFactory { get; set; }
        protected SessionAlgorithmVersion sessionAlgorithmVersion { get; set; }

        public Algorithm(UoWFactory uoWFactory)
        {
            this.uoWFactory = uoWFactory;
        }

        

        public abstract void Solve();
    }
}
