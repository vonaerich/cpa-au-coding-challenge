using System.Collections.Generic;

namespace CPA.Part2.Entities
{
    public class Subject
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Result> Results { get; set; }
    }
}
