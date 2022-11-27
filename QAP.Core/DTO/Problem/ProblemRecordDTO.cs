namespace QAP.Core.DTO.Problem;

public class ProblemRecordDTO
{
    public int Id { get; set; }
    public string Alias { get; set; }
    public byte[] Hash { get; set; }

    public ProblemRecordDTO() { }

    public ProblemRecordDTO(int id, string alias, byte[] hash)
    {
        Id = id;
        Alias = alias;
        Hash = hash;
    }
}
