using CPA.Part2.Entities;
using Microsoft.EntityFrameworkCore;

namespace CPA.Part2
{
    public class ResultsContext : DbContext, IResultsContext
    {
        public ResultsContext(DbContextOptions<ResultsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Subject> Subjects { get; set; }

        public virtual DbSet<Result> Results { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var resultsToAdd = new Result[]
            { 
                new Result { Id = 1, SubjectId = 1, Grade = Grade.Fail, Year = 2015 },
                new Result { Id = 2, SubjectId = 1, Grade = Grade.Pass, Year = 2016 },
                new Result { Id = 3, SubjectId = 2, Grade = Grade.Fail, Year = 2015 },
                new Result { Id = 4, SubjectId = 2, Grade = Grade.Pass, Year = 2016 },
                new Result { Id = 5, SubjectId = 3, Grade = Grade.Pass, Year = 2016 },
                new Result { Id = 6, SubjectId = 4, Grade = Grade.Pass, Year = 2015 },
                new Result { Id = 7, SubjectId = 5, Grade = Grade.Pass, Year = 2015 }
            };

            var subjectsToAdd = new Subject[]
            {
                new Subject { Id = 1, Name = "Strategic Management Accounting" },
                new Subject { Id = 2, Name = "Financial Reporting" },
                new Subject { Id = 3, Name = "Advanced Taxation" },
                new Subject { Id = 4, Name = "Financial Risk Management" },
                new Subject { Id = 5, Name = "Advanced Audit and Assurance" }
            };

            modelBuilder.Entity<Subject>().HasData(subjectsToAdd);
            modelBuilder.Entity<Result>().HasData(resultsToAdd);

            base.OnModelCreating(modelBuilder);
        }
    }

    public interface IResultsContext
    {
        DbSet<Subject> Subjects { get; set; }

        DbSet<Result> Results { get; set; }
    }
}
