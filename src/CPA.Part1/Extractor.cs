using CPA.Part1.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CPA.Part1
{
    public class Extractor : IExtractor
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger _logger;

        public Extractor(IHttpClientFactory httpClientFactory, ILogger<Extractor> logger = null)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<IEnumerable<SubjectResult>> FetchResults()
        {
            var httpClient = _httpClientFactory.CreateClient("ResultsClient");
            var response = await httpClient.GetAsync("api/results");

            if (!response.IsSuccessStatusCode)
            {
                _logger?.LogError($"Cannot fetch results. Status Code - {response.StatusCode}");
                return new List<SubjectResult>();
            }

            return await response.Content.ReadFromJsonAsync<IEnumerable<SubjectResult>>();
        }
    }

    public interface IExtractor
    {
        Task<IEnumerable<SubjectResult>> FetchResults();
    }
}
