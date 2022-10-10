using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAP.MvvM.Problem;

/// <summary>
/// Matrix representation class
/// </summary>
/// <typeparam name="T">Number type - double, float, int, long, ...</typeparam>
public class MatrixMvvM<T> where T : struct, IEquatable<T>, IFormattable
{
    public int Size { get; private set; }
    public T[] Matrix { get; set; }
}
