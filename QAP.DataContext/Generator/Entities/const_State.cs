// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace QAP.DataContext
{
    // State
    public class const_State
    {
        public int Id { get; set; } // Id (Primary key)
        public string Alias { get; set; } // Alias (length: 255)
        public string Title { get; set; } // Title (length: 1073741823)
        public string Description { get; set; } // Description (length: 1073741823)

        // Reverse navigation

        /// <summary>
        /// Child SessionAlgorithmVariations where [SessionAlgorithmVariation].[StateId] point to this entity (FK_SessionAlgorithmVariation_State)
        /// </summary>
        public virtual ICollection<SessionAlgorithmVariation> SessionAlgorithmVariations { get; set; } // SessionAlgorithmVariation.FK_SessionAlgorithmVariation_State

        public const_State()
        {
            SessionAlgorithmVariations = new List<SessionAlgorithmVariation>();
        }
    }

}
// </auto-generated>
