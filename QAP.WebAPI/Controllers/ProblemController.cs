using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using QAP.Core.DTO.Base.Answer;
using QAP.Core.DTO.Problem;
using QAP.Core.Models.Problem;
using QAP.UnitOfWork.Factories;
using QAP.UnitOfWork.UnitOfWork;

namespace QAP.WebAPI.Controllers;

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

    [HttpGet]
    public async Task<GenericAnswer<List<ProblemRecordDTO>>> GetAliases()
    {
        return new GenericAnswer<List<ProblemRecordDTO>>()
        {
            Result = uoWFactory.ProblemUnitOfWork.GetAliases()
        };
    }

    [HttpGet]
    [Route("{alias}")]
    public async Task<GenericAnswer<ProblemModel>> GetProblem(string alias)
    {
        return new GenericAnswer<ProblemModel>()
        {
            Result = uoWFactory.ProblemUnitOfWork.GetProblemByAlias(alias)
        };
    }
}
