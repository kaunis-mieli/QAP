using TypeGen.Core.TypeAnnotations;

namespace QAP.Core.Models.Permutation;

public class PermutationModel
{
    public long Cost { get; set; }
    public int[] Permutation { get; set; }
}