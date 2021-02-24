using CPA.Part1.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CPA.Part1
{
    public class Transformer : ITransformer
    {
        public IEnumerable<IGrouping<int, string>> TransformResults(IEnumerable<SubjectResult> originalResults)
        {
            return originalResults
                .SelectMany(a => a.Results, 
                    (item, result) => new { item.Subject, result.Year, result.Grade })
                .Where(a => a.Grade.Equals("pass", StringComparison.OrdinalIgnoreCase))
                .OrderBy(a => a.Year)
                .ThenBy(a => a.Subject)
                .GroupBy(a => a.Year, a => a.Subject);
        }
    }

    public interface ITransformer
    {
        IEnumerable<IGrouping<int, string>> TransformResults(IEnumerable<SubjectResult> originalResults);
    }
}
