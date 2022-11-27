using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAP.Core.DTO.Algorithm
{
    public class AlgorithmVersionDTO
    {
        public int Id { get; set; }
        public string Alias { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string DefaultConfiguration { get; set; }
    }
}
