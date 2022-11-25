using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QAP.Core.DTO.Base.Answer;
using QAP.Core.DTO.Base.Request;
using QAP.UnitOfWork.Factories;
using QAP.UnitOfWork.Helpers;

namespace QAP.WebAPI.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class GenericController : ControllerBase
    {
        protected virtual UoWFactory uoWFactory { get; set; }

        public GenericController(UoWFactory _uoWFactory)
        {
            uoWFactory = _uoWFactory;
        }

        protected virtual async Task<GenericAnswer<T>> GenericRequest<T>(IQAPRequest qAPRequest) where T : class, new()
        {
            try
            {
                await IdentityHelper.Authenticate(qAPRequest, uoWFactory);
            }
            catch (Exception ex)
            {

            }

            return null;
        }
    }
}
