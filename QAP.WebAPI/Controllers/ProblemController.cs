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
        public IActionResult GetProblem(string alias)
        {
            return Ok(problemUnitOfWork.GetProblemWithSolutionsByAlias(alias));
        }
    }
}
