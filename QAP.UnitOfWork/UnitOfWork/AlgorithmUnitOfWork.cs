using QAP.Core.DTO.Algorithm;
using QAP.UnitOfWork.Factories;
using QAP.UnitOfWork.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAP.UnitOfWork.UnitOfWork
{
    public class AlgorithmUnitOfWork : BaseUnitOfWork
    {
        public AlgorithmUnitOfWork(UoWFactory _parentFactory) : base(_parentFactory) { }

        public List<AlgorithmDTO> GetAllAlgorithms()
        {
            var result = parentFactory.RepositoryFactory.AlgorithmRepo.GetAlgorithmsWithVersions();
            return ConversionHelpers.GetAlgorithmDTOs(result);
        }
    }
}
