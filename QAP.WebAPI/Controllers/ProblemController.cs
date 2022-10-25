using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using QAP.UnitOfWork.UnitOfWork;

namespace QAP.WebAPI.Controllers
{
    [EnableCors("CorsApi")]
    [Route("api/problem")]
    [ApiController]
    public class ProblemController : ControllerBase
    {
        private readonly ProblemUnitOfWork problemUnitOfWork;
        public ProblemController(IConfiguration configuration, ProblemUnitOfWork problemUnitOfWork)
        {
            this.problemUnitOfWork = problemUnitOfWork;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(problemUnitOfWork.GetAliases());
        }

        [HttpGet]
        [Route("{alias}")]
        public IActionResult GetProblemByAlias(string alias)
        {
            return Ok(problemUnitOfWork.GetProblem(alias));
        }

        [HttpPost]
        public IActionResult LocalSearch(string problemAlias, int iterations)
        {
            return Ok(problemUnitOfWork.LocalSearch(problemAlias, iterations));
        }


    }
}
