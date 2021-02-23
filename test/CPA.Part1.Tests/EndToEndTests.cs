using System;
using Xunit;

namespace CPA.Part1.Tests
{
    public class EndToEndTests
    {
        [Fact]
        public void RunsWithoutErrors()
        {
            var result = Program.Main(Array.Empty<string>());

            Assert.Equal(0, result);
        }
    }
}
