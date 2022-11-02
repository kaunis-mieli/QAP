using TypeGen.Core.TypeAnnotations;

namespace QAP.Core.DTO.Base.Answer;

[ExportTsInterface(OutputDir = "../QAP.Frontend/src/interfaces")]
public class AnswerMessage
{
    public List<string> Infos { get; set; }
    public List<string> Errors { get; set; }
    public List<string> Warnings { get; set; }

    public AnswerMessage()
    {
        Infos = new List<string>();
        Errors = new List<string>();
        Warnings = new List<string>();
    }
}
