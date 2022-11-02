using QAP.Core.DTO.AuthDTO;
using TypeGen.Core.TypeAnnotations;

namespace QAP.Core.DTO.Base.Answer;

[ExportTsInterface(OutputDir = "../QAP.Frontend/src/interfaces")]
public class AuthenticationAnswer
{
    public bool IsFatalError { get; set; }
    public string ErrorMessage { get; set; }
    public UserLoginDTO? UserLogin { get; set; }

    public AuthenticationAnswer()
    {
        ErrorMessage = string.Empty;
    }
}
