using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QAP.MvvM.Solution;

namespace QAP.MvvM.Problem;


public class ProblemModel
{
    public int Size { get; set; }
    public int[] MatrixA { get; set; }
    public int[] MatrixB { get; set; }
    public byte[] Hash { get; set; }
    public long? BestCost { get; set; }
    public string Alias { get; set; }
    public List<SolutionModel> Solutions { get; set; }

    public ProblemModel()
    {
        Solutions = new List<SolutionModel>();
    }
}
