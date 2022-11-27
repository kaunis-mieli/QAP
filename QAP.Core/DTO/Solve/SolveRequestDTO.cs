using QAP.Core.DTO.Algorithm;
using QAP.Core.DTO.Base.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAP.Core.DTO.Solve
{
    public class SolveRequestDTO : QAPRequest
    {
        public List<int> ProblemIds { get; set; }
        public List<AlgorithmVersionRequest> AlgorithmVersions { get; set; }

        public SolveRequestDTO()
        {
            ProblemIds = new List<int>();
            AlgorithmVersions = new List<AlgorithmVersionRequest>();
        }
    }
}
