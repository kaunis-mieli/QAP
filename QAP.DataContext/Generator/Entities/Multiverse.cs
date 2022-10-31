// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace QAP.DataContext
{
    // Multiverse
    public class Multiverse
    {
        public int Id { get; set; } // Id (Primary key)
        public string Alias { get; set; } // Alias (length: 255)
        public string Title { get; set; } // Title (length: 1073741823)
        public string Description { get; set; } // Description (length: 1073741823)
        public int UserId { get; set; } // UserId
        public DateTime Timestamp { get; set; } // Timestamp

        // Reverse navigation

        /// <summary>
        /// Child Sessions where [Session].[MultiverseId] point to this entity (FK_Session_Multiverse)
        /// </summary>
        public virtual ICollection<Session> Sessions { get; set; } // Session.FK_Session_Multiverse

        // Foreign keys

        /// <summary>
        /// Parent auth_User pointed by [Multiverse].([UserId]) (FK_Multiverse_User)
        /// </summary>
        public virtual auth_User auth_User { get; set; } // FK_Multiverse_User

        public Multiverse()
        {
            Timestamp = DateTime.Now;
            Sessions = new List<Session>();
        }
    }

}
// </auto-generated>
