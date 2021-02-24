using NSubstitute;
using System.Threading.Tasks;
using Xunit;

namespace CPA.Part1.Tests
{
    public class OrchestratorTests
    {
        [Fact]
        public async Task RunsWithoutErrors()
        {
            var extractor = Substitute.For<IExtractor>();
            var transformer = Substitute.For<ITransformer>();
            var orchestrator = new Orchestrator(extractor, transformer);

            await orchestrator.Start();
        }
    }
}
