using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeGen.Core.TypeAnnotations;

namespace QAP.Core.DTO.Base.Request
{
    [ExportTsInterface(OutputDir = "../QAP.Frontend/src/interfaces")]
    public abstract class QAPRequest : IQAPRequest
    {
        public virtual string Token { get; set; }
    }
}
