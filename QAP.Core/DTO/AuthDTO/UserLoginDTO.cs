using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeGen.Core.TypeAnnotations;

namespace QAP.Core.DTO.AuthDTO;

[ExportTsInterface(OutputDir = "../QAP.Frontend/src/interfaces")]
public class UserLoginDTO
{
    public string Token { get; set; }
    public DateTime ValidUntil { get; set; }
    public string Alias { get; set; }
    public string Email { get; set; }
    public string FullName { get; set; }

}
