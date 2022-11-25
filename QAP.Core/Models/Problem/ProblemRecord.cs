namespace QAP.Core.Models.Problem;

public class ProblemRecord
{
    public string Alias { get; set; }
    public byte[] Hash { get; set; }

    public ProblemRecord() { }

    public ProblemRecord(string alias, byte[] hash)
    {
        Alias = alias;
        Hash = hash;
    }
}
