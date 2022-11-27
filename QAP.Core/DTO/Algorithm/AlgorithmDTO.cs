using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAP.Core.DTO.Algorithm
{
    public class AlgorithmDTO
    {
        public int Id { get; set; }
        public string Alias { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<AlgorithmVersionDTO> AlgorithmVersionDTOs { get; set; }

        public AlgorithmDTO()
        {
            AlgorithmVersionDTOs = new List<AlgorithmVersionDTO>();
        }
    }
}
