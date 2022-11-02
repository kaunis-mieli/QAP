using TypeGen.Core.TypeAnnotations;

namespace QAP.Core.DTO.Base.Answer;

[ExportTsInterface(OutputDir = "../QAP.Frontend/src/interfaces")]
public class GenericAnswer<T> where T : class, new()
{
    public AuthenticationAnswer AuthenticationAnswer { get; set; }
    public AnswerMessage AnswerMessage { get; set; }
    public T? Result { get; set; }

    public GenericAnswer()
    {
        AuthenticationAnswer = new AuthenticationAnswer();
        AnswerMessage = new AnswerMessage();
    }

}
