using QAP.Core.Models.Problem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAP.UnitOfWork.UnitOfWork.Algorithm
{
    internal interface IAlgorithm
    {
        void Solve(ProblemModel problemInstanceModel);
    }
}
