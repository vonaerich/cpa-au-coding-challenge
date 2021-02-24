using NSubstitute;
using System.IO;
using System.Linq;
using Xunit;

namespace CPA.Part1.Tests
{
    public class PrinterTests
    {
        [Fact]
        public void ShouldPrintResults()
        {
            var results = new (int year, string subject)[]
            {
                new (2020, "Subject"),
            }
            .GroupBy(a => a.year, a => a.subject);

            var textWriter = Substitute.For<TextWriter>();
            
            new Printer(textWriter).Print(results);

            textWriter.Received().WriteLine(Arg.Is<string>(a => a.Contains("2020")));
            textWriter.Received().WriteLine(Arg.Is<string>(a => a.Contains("Subject")));
        }
    }
}
