using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using QAP.UnitOfWork.Factories;
using QAP.UnitOfWork.UnitOfWork;

namespace QAP.WebAPI.Controllers
{
    [EnableCors("CorsApi")]
    [Route("api/problem")]
    [ApiController]
    public class ProblemController : ControllerBase
    {
        private UoWFactory uoWFactory;
        
        public ProblemController(UoWFactory _uoWFactory)
        {
            uoWFactory = _uoWFactory;
        }      
    }
}
