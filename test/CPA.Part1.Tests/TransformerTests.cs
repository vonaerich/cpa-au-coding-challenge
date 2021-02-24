using CPA.Models;
using System.Linq;
using Xunit;

namespace CPA.Part1.Tests
{
    public class TransformerTests
    {
        private readonly SubjectResult[] _originalResults = BuildOriginalResults();
        private readonly Transformer _transformer;

        public TransformerTests()
        {
            _transformer = new Transformer();
        }

        [Fact]
        public void TransformResults_RemovesFailResults()
        {
            var result = _transformer.TransformResults(_originalResults);

            Assert.DoesNotContain(result, item => item.All(a => a.ToUpper() == "PASS"));
        }

        [Fact]
        public void TransformResults_ArrangesResultsByYear()
        {
            var result = _transformer.TransformResults(_originalResults);

            var firstResult = result.First();
            Assert.NotNull(firstResult);
            Assert.True(firstResult.Key == 2015);

            var lastResult = result.Last();
            Assert.NotNull(lastResult);
            Assert.True(lastResult.Key == 2020);
        }

        [Fact]
        public void TransformResults_ArrangesSubjectsAscending()
        {
            var result = _transformer.TransformResults(_originalResults);

            var firstResult = result.First();
            Assert.True(firstResult.First().ToUpper() == "FIRST FOR 2015");
        }

        private static SubjectResult[] BuildOriginalResults()
        {
            return new[]
            {
                new SubjectResult
                {
                    Subject = "Subject 2020",
                    Results = new[]
                    {
                        new Result { Year = 2019, Grade = "Fail" },
                        new Result { Year = 2020, Grade = "PASS" }
                    }
                },
                new SubjectResult
                {
                    Subject = "Subject 1",
                    Results = new[]
                    {
                        new Result { Year = 2015, Grade = "FAIL" }
                    }
                },
                new SubjectResult
                {
                    Subject = "Subject 2015",
                    Results = new[]
                    {
                        new Result { Year = 2015, Grade = "Pass" }
                    }
                },
                new SubjectResult
                {
                    Subject = "First for 2015",
                    Results = new[]
                    {
                        new Result { Year = 2015, Grade = "Pass" }
                    }
                }
            };
        }
    }
}
