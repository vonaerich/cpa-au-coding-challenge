using CPA.Models;
using CPA.Part2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CPA.Part2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResultsController : ControllerBase
    {
        private readonly IResultsService _resultsService;

        public ResultsController(IResultsService resultsService)
        {
            _resultsService = resultsService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<SubjectResult> Get()
        {
            return _resultsService.GetResults();
        }
    }
}
