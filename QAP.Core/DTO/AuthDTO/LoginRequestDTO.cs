using QAP.Core.DTO.Base.Request;
using TypeGen.Core.TypeAnnotations;

namespace QAP.Core.DTO.AuthDTO;

[ExportTsInterface(OutputDir = "../QAP.Frontend/src/interfaces")]
public class LoginRequestDTO : QAPRequest
{
    public string AliasOrEmail { get; set; }
    public string Password { get; set; }
    public bool RememberMe { get; set; }
}
