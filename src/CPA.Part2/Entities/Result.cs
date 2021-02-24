namespace CPA.Part2.Entities
{
    public class Result
    {
        public int Id { get; set; }

        public int SubjectId { get; set; }

        public int Year { get; set; }

        public Grade Grade { get; set; }

        public virtual Subject Subject { get; set; }
    }

    public enum Grade
    {
        Pass,
        Fail
    }
}
