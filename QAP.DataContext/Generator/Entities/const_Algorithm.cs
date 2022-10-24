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

    // Algorithm
    public class const_Algorithm
    {
        public short Id { get; set; } // Id (Primary key)
        public string Alias { get; set; } // Alias (length: 255)
        public string Title { get; set; } // Title (length: 1073741823)
        public string Description { get; set; } // Description (length: 1073741823)

        // Reverse navigation

        /// <summary>
        /// Child SessionAlgorithms where [SessionAlgorithm].[AlgorithmId] point to this entity (FK_SessionAlgorithm_Algorithm)
        /// </summary>
        public virtual ICollection<SessionAlgorithm> SessionAlgorithms { get; set; } // SessionAlgorithm.FK_SessionAlgorithm_Algorithm

        public const_Algorithm()
        {
            SessionAlgorithms = new List<SessionAlgorithm>();
        }
    }

}
// </auto-generated>
