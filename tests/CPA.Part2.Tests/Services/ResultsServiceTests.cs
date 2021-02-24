using CPA.Part2.Entities;
using CPA.Part2.Services;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CPA.Part2.Tests.Services
{
    public class ResultsServiceTests
    {
        private readonly IResultsContext _context;

        public ResultsServiceTests()
        {
            _context = SetupContext();
        }

        [Fact]
        public void CanRetrieveResults()
        {
            var resultsService = new ResultsService(_context);

            var result = resultsService.GetResults().ToList();

            Assert.NotEmpty(result);
            Assert.Contains(result, item => item.Subject == "Subject" 
                && item.Results.Any(a => a.Grade == "PASS" && a.Year == 2010));
        }

        private static IResultsContext SetupContext()
        {
            var context = Substitute.For<IResultsContext>();

            var subjects = new List<Subject>
            { 
                new Subject 
                {   
                    Name = "Subject",
                    Results = new List<Result>
                    {
                        new Result { Year = 2010, Grade = Grade.Pass }
                    }
                }
            }
            .AsQueryable()
            .AsDbSet();

            context.Subjects.Returns(subjects);

            return context;
        }
    }

    public static class Extensions
    {
        public static DbSet<T> AsDbSet<T>(this IQueryable<T> queryable)
           where T : class
        {
            var mockSet = Substitute.For<DbSet<T>, IQueryable<T>>();
            ((IQueryable<T>)mockSet).Provider.Returns(queryable.Provider);
            ((IQueryable<T>)mockSet).Expression.Returns(queryable.Expression);
            ((IQueryable<T>)mockSet).ElementType.Returns(queryable.ElementType);
            ((IQueryable<T>)mockSet).GetEnumerator().Returns(queryable.GetEnumerator());

            return mockSet;
        }
    }
}
