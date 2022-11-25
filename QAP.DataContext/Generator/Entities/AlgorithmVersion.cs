// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace QAP.DataContext
{
    // ****************************************************************************************************
    // This is not a commercial licence, therefore only a few tables/views/stored procedures are generated.
    // ****************************************************************************************************

    // AlgorithmVersion
    public class AlgorithmVersion
    {
        public int Id { get; set; } // Id (Primary key)
        public int Version { get; set; } // Version
        public int AlgorithmId { get; set; } // AlgorithmId
        public string Alias { get; set; } // Alias (length: 255)
        public string Title { get; set; } // Title (length: 1073741823)
        public string Description { get; set; } // Description (length: 1073741823)
        public string DefaultConfiguration { get; set; } // DefaultConfiguration (length: 1073741823)
        public int? UserId { get; set; } // UserId

        // Reverse navigation

        /// <summary>
        /// Child SessionAlgorithmVersions where [SessionAlgorithmVersion].[AlgorithmVersionId] point to this entity (FK_SessionAlgorithmVersion_AlgorithmVersion)
        /// </summary>
        public virtual ICollection<SessionAlgorithmVersion> SessionAlgorithmVersions { get; set; } // SessionAlgorithmVersion.FK_SessionAlgorithmVersion_AlgorithmVersion

        // Foreign keys

        /// <summary>
        /// Parent auth_User pointed by [AlgorithmVersion].([UserId]) (FK_AlgorithmVersion_User)
        /// </summary>
        public virtual auth_User auth_User { get; set; } // FK_AlgorithmVersion_User

        /// <summary>
        /// Parent const_Algorithm pointed by [AlgorithmVersion].([AlgorithmId]) (FK_AlgorithmVersion_Algorithm)
        /// </summary>
        public virtual const_Algorithm const_Algorithm { get; set; } // FK_AlgorithmVersion_Algorithm

        public AlgorithmVersion()
        {
            SessionAlgorithmVersions = new List<SessionAlgorithmVersion>();
        }
    }

}
// </auto-generated>
