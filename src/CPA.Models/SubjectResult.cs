using System.Collections.Generic;

namespace CPA.Models
{
    public class SubjectResult
    {
        public string Subject { get; set; }

        public IList<Result> Results { get; set; }
    }

    public class Result
    {
        public int Year { get; set; }

        public string Grade { get; set; }
    }
}
