// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace QAP.DataContext
{
    // Problem
    public class Problem
    {
        public int Id { get; set; } // Id (Primary key)
        public int Size { get; set; } // Size
        public byte[] MatrixA { get; set; } // MatrixA
        public byte[] MatrixB { get; set; } // MatrixB
        public byte[] Hash { get; set; } // Hash (length: 20)
        public string Alias { get; set; } // Alias (length: 255)
        public string Title { get; set; } // Title (length: 1073741823)
        public string Description { get; set; } // Description (length: 1073741823)
        public long? InitialBestKnownCost { get; set; } // InitialBestKnownCost
        public int? UserId { get; set; } // UserId
        public DateTime Timestamp { get; set; } // Timestamp
        public long? PermutationId { get; set; } // PermutationId

        // Reverse navigation

        /// <summary>
        /// Child Sessions where [Session].[ProblemId] point to this entity (FK_Session_Problem)
        /// </summary>
        public virtual ICollection<Session> Sessions { get; set; } // Session.FK_Session_Problem

        // Foreign keys

        /// <summary>
        /// Parent auth_User pointed by [Problem].([UserId]) (FK_Problem_User)
        /// </summary>
        public virtual auth_User auth_User { get; set; } // FK_Problem_User

        /// <summary>
        /// Parent Permutation pointed by [Problem].([PermutationId]) (FK_Problem_Permutation)
        /// </summary>
        public virtual Permutation Permutation { get; set; } // FK_Problem_Permutation

        public Problem()
        {
            Timestamp = DateTime.Now;
            Sessions = new List<Session>();
        }
    }

}
// </auto-generated>