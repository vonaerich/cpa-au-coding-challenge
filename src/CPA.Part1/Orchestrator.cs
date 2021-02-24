using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPA.Part1
{
    public class Orchestrator : IOrchestrator
    {
        private readonly IExtractor _extractor;
        private readonly ITransformer _transformer;
        private readonly ILogger<Orchestrator> _logger;

        public Orchestrator(
            IExtractor extractor,
            ITransformer transformer,
            ILogger<Orchestrator> logger = null)
        {
            _extractor = extractor;
            _transformer = transformer;
            _logger = logger;
        }


        public async Task Start()
        {
            // Extract
            var results = await _extractor.FetchResults();

            if (!results.Any())
                return;

            // Transform
            var transformedResults = _transformer.TransformResults(results);

            // Print
            // _printer.PrintResults();
        }
    }

    public interface IOrchestrator
    {
        Task Start();
    }
}
