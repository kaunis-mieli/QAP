using QAP.Core.DTO.Base.Request;
using TypeGen.Core.TypeAnnotations;

namespace QAP.Core.DTO.AuthDTO;

[ExportTsInterface(OutputDir = "../QAP.Frontend/src/interfaces")]
public class RegisterRequestDTO : QAPRequest
{
    public string Alias { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string? FullName { get; set; }

}
