// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace QAP.DataContext
{
    // User
    public class auth_User
    {
        public int Id { get; set; } // Id (Primary key)
        public string Alias { get; set; } // Alias (length: 255)
        public string HashedPassword { get; set; } // HashedPassword (length: 2147483647)
        public string Email { get; set; } // Email (length: 255)
        public string FullName { get; set; } // FullName (length: 255)
        public DateTime Timestamp { get; set; } // Timestamp

        // Reverse navigation

        /// <summary>
        /// Child AlgorithmVersions where [AlgorithmVersion].[UserId] point to this entity (FK_AlgorithmVersion_User)
        /// </summary>
        public virtual ICollection<AlgorithmVersion> AlgorithmVersions { get; set; } // AlgorithmVersion.FK_AlgorithmVersion_User

        /// <summary>
        /// Child auth_UserLogins where [UserLogin].[UserId] point to this entity (FK_UserLogin_User)
        /// </summary>
        public virtual ICollection<auth_UserLogin> auth_UserLogins { get; set; } // UserLogin.FK_UserLogin_User

        /// <summary>
        /// Child Multiverses where [Multiverse].[UserId] point to this entity (FK_Multiverse_User)
        /// </summary>
        public virtual ICollection<Multiverse> Multiverses { get; set; } // Multiverse.FK_Multiverse_User

        /// <summary>
        /// Child Problems where [Problem].[UserId] point to this entity (FK_Problem_User)
        /// </summary>
        public virtual ICollection<Problem> Problems { get; set; } // Problem.FK_Problem_User

        public auth_User()
        {
            Timestamp = DateTime.Now;
            AlgorithmVersions = new List<AlgorithmVersion>();
            Multiverses = new List<Multiverse>();
            Problems = new List<Problem>();
            auth_UserLogins = new List<auth_UserLogin>();
        }
    }

}
// </auto-generated>
