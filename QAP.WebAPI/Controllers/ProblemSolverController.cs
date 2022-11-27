using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using QAP.Core.DTO.Base.Answer;
using QAP.Core.DTO.Solve;
using QAP.Core.Models.Problem;
using QAP.UnitOfWork.Factories;
using QAP.UnitOfWork.UnitOfWork;

namespace QAP.WebAPI.Controllers;

[EnableCors("CorsApi")]
[Route("api/problemSolver")]
[ApiController]
public class ProblemSolverController : ControllerBase
{
    private UoWFactory uoWFactory;
    
    public ProblemSolverController(UoWFactory _uoWFactory)
    {
        uoWFactory = _uoWFactory;
    }

    [HttpPost]
    public async Task<GenericAnswer<SolveRequestResponseDTO>> Solve(SolveRequestDTO solveRequest)
    {
        return new GenericAnswer<SolveRequestResponseDTO>() 
        { 
            Result = uoWFactory.ProblemSolverUnitOfWork.EnqueueSessions(solveRequest) 
        };
    }
}
