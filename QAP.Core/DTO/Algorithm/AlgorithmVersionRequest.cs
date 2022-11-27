using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAP.Core.DTO.Algorithm
{
    public class AlgorithmVersionRequest
    {
        public int AlgorithmVersionId { get; set; }
        public List<int?> SeedsForInstances { get; set; }

        public AlgorithmVersionRequest()
        {
            SeedsForInstances = new List<int?>() { null };
        }
    }
}
