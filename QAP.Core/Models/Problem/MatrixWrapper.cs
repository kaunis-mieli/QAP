using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAP.Core.Models.Problem
{
    public class MatrixWrapper
    {
        public int[] Matrix {get; set;}
        public int Size { get; private set; }

        public int this[int i, int j]
        {
            get
            {
                return Matrix[i * Size + j];
            }
            set 
            {
                Matrix[i * Size + j] = value;
            }
        }

        public MatrixWrapper(int[] matrix, int size)
        {
            if (size * size != matrix.Length)
            {
                throw new ArgumentException("Size should be square root of total matrix elements count.");
            }

            Matrix = matrix;
            Size = size;
        }
    }
}
