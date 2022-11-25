using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using QAP.Core.DTO.Base.Answer;
using QAP.Core.Models.Problem;
using QAP.UnitOfWork.Factories;
using QAP.UnitOfWork.UnitOfWork;

namespace QAP.WebAPI.Controllers;

[EnableCors("CorsApi")]
[Route("api/ProblemSolver")]
[ApiController]
public class ProblemSolverController : ControllerBase
{
    private UoWFactory uoWFactory;
    
    public ProblemSolverController(UoWFactory _uoWFactory)
    {
        uoWFactory = _uoWFactory;
    }

    [HttpGet]
    [Route("{problemAlias}")]
    public async Task<GenericAnswer<object>> SolveProblem(string problemAlias, int repeat)
    {
        uoWFactory.ProblemSolverUnitOfWork.Solve(problemAlias, repeat);
        return new GenericAnswer<object>();
    }
}
