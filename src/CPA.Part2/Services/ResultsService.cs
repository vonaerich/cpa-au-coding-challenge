using CPA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPA.Part2.Services
{
    public class ResultsService : IResultsService
    {
        public IEnumerable<SubjectResult> GetResults()
        {
            throw new NotImplementedException();
        }
    }

    public interface IResultsService
    {
        IEnumerable<SubjectResult> GetResults();
    }
}
