using CPA.Models;
using CPA.Part2.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CPA.Part2.Services
{
    public class ResultsService : IResultsService
    {
        private readonly IResultsContext _resultsContext;

        public ResultsService(IResultsContext resultsContext)
        {
            _resultsContext = resultsContext;
        }

        public IEnumerable<SubjectResult> GetResults()
        {
            return _resultsContext
                .Subjects
                .Include(a => a.Results)
                .Select(MapToSubjectResult);
        }

        private SubjectResult MapToSubjectResult(Subject subject)
        {
            return new SubjectResult 
            {
                Subject = subject.Name,
                Results = subject.Results?.Select(MapToResult).ToList() 
                    ?? new List<Models.Result>()
            };
        }

        private Models.Result MapToResult(Entities.Result result)
        {
            return new Models.Result
            {
                Year = result.Year,
                Grade = result.Grade.ToString().ToUpper()
            };
        }
    }

    public interface IResultsService
    {
        IEnumerable<SubjectResult> GetResults();
    }
}
