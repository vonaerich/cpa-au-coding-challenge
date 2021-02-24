using CPA.Models;
using CPA.Part2.Controllers;
using CPA.Part2.Services;
using NSubstitute;
using System.Linq;
using Xunit;

namespace CPA.Part2.Tests.Controllers
{
    public class ResultsControllerTests
    {
        [Fact]
        public void Get_ReturnsResults()
        {
            var service = Substitute.For<IResultsService>();
            service.GetResults().Returns(new[]
            {
                new SubjectResult
                {
                    Subject = "Subject",
                    Results = new[] { new Result { Year = 2020, Grade = "Pass" } }
                }
            });

            var controller = new ResultsController(service);

            var result = controller.Get();

            Assert.NotEmpty(result);
            Assert.Contains(result, item => item.Subject == "Subject" 
                && item.Results.Any());
        }
    }
}
