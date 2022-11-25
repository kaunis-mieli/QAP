using QAP.Core.Models.Problem;
using QAP.UnitOfWork.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAP.UnitOfWork.UnitOfWork.Algorithm
{
    public abstract class Algorthm<T> : IAlgorithm
        where T : IAlgorithmConfig
    {
        public T Configuration { get; private set; }

        protected UoWFactory uoWFactory { get; set; }

        public Algorthm(T configuration, UoWFactory uoWFactory)
        {
            Configuration = configuration;
            this.uoWFactory = uoWFactory;
        }

        public abstract void Solve(ProblemModel problemInstanceModel);
    }
}
