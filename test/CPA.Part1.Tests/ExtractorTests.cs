using CPA.Part1.Models;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CPA.Part1.Tests
{
    public class ExtractorTests
    {
        [Fact]
        public async Task CanFetchResultsFromApi()
        {
            var httpClient = CreateHttpClient(new FakeHttpMessageHandler());
            var httpClientFactory = Substitute.For<IHttpClientFactory>();
            httpClientFactory.CreateClient(Arg.Any<string>()).Returns(httpClient);

            var results = await new Extractor(httpClientFactory).FetchResults();

            Assert.NotEmpty(results);
            Assert.Contains(results, result => result.Subject == "Subject1");
        }

        [Fact]
        public async Task ReturnsEmptyListWhenFaulty()
        {
            var httpClient = CreateHttpClient(new FaultyMessageHandler());
            var httpClientFactory = Substitute.For<IHttpClientFactory>();
            httpClientFactory.CreateClient(Arg.Any<string>()).Returns(httpClient);

            var results = await new Extractor(httpClientFactory).FetchResults();

            Assert.Empty(results);
        }

        private static HttpClient CreateHttpClient(HttpMessageHandler handler)
        {
            return new HttpClient(handler)
            {
                BaseAddress = new Uri("http://something")
            };
        }
    }

    public class FakeHttpMessageHandler : HttpMessageHandler
    {
        private static IEnumerable<SubjectResult> Result =>
            new List<SubjectResult>
            {
                new SubjectResult
                {
                    Subject = "Subject1",
                    Results = new[] { new Result { Year = 2020, Grade = "Pass" } }
                }
            };

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonSerializer.Serialize(Result))
            });
        }
    }

    public class FaultyMessageHandler : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new HttpResponseMessage { StatusCode = HttpStatusCode.InternalServerError });
        }
    }
}
