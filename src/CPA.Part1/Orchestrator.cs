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
        private readonly ILogger<Orchestrator> _logger;

        public Orchestrator(
            IExtractor extractor,
            ILogger<Orchestrator> logger = null)
        {
            _extractor = extractor;
            _logger = logger;
        }


        public async Task Start()
        {
            // Extract

            // Transform

            // Print
        }
    }

    public interface IOrchestrator
    {
        Task Start();
    }
}
