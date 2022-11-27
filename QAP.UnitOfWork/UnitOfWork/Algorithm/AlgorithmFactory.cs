using QAP.DataContext;
using QAP.UnitOfWork.Factories;
using QAP.UnitOfWork.UnitOfWork.Algorithm.LocalSearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAP.UnitOfWork.UnitOfWork.Algorithm
{
    public static class AlgorithmFactory
    {
        public static IAlgorithm Resolve(SessionAlgorithmVersion sessionAlgorithmVersion, UoWFactory uoWFactory)
        {
            IAlgorithm toReturn;

            switch (sessionAlgorithmVersion.AlgorithmVersion.const_Algorithm.Alias)
            {
                case "ClassicLocalSearchAlgorithm":
                    toReturn = ResolveLocalSearchAlgorithmVersion(sessionAlgorithmVersion, uoWFactory);
                    break;
                default:
                    throw new ArgumentException("Unknown algorithm");
            }

            return toReturn;
        }

        private static IAlgorithm ResolveLocalSearchAlgorithmVersion(SessionAlgorithmVersion sessionAlgorithmVersion, UoWFactory uoWFactory)
        {
            switch (sessionAlgorithmVersion.AlgorithmVersion.Alias)
            {
                case "v0.0.1":
                    return new LocalSearch001(sessionAlgorithmVersion, uoWFactory);
                default:
                    throw new ArgumentException("Unknown algorithm version");
            }
        }
    }
}
