// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace QAP.DataContext
{
    // Solution
    public class Solution
    {
        public long Id { get; set; } // Id (Primary key)
        public long Cost { get; set; } // Cost
        public byte[] Permutation { get; set; } // Permutation
        public int ProblemId { get; set; } // ProblemId
        public DateTime CreatedAt { get; set; } // CreatedAt

        // Foreign keys

        /// <summary>
        /// Parent Problem pointed by [Solution].([ProblemId]) (FK_Solution_Problem)
        /// </summary>
        public virtual Problem Problem { get; set; } // FK_Solution_Problem

        public Solution()
        {
            CreatedAt = DateTime.Now;
        }
    }

}
// </auto-generated>
