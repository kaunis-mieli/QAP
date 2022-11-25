namespace QAP.Core.Models.Problem;

public class ProblemModel
{
    public string Alias { get; set; }
    public int Size { get; set; }
    public MatrixWrapper MatrixA { get; set; }
    public MatrixWrapper MatrixB { get; set; }
    public long? InitialBestKnownCost { get; set; }
}
