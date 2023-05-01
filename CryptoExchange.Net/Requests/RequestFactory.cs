using System;
using System.Net;
using System.Net.Http;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;

namespace CryptoExchange.Net.Requests
{
    /// <summary>
    /// Request factory
    /// </summary>
    public class RequestFactory : IRequestFactory
    {
        private HttpClient? httpClient;        

        /// <inheritdoc />
        public void Configure(TimeSpan requestTimeout, HttpClient? client = null)
        {
            if (client == null)
            {
                httpClient = new HttpClient() { Timeout = requestTimeout };
            }
            else
            {
                httpClient = client;
                httpClient.Timeout = requestTimeout;
            }
        }

        /// <inheritdoc />
        public IRequest Create(HttpMethod method, Uri uri, int requestId)
        {
            if (httpClient == null)
                throw new InvalidOperationException("Cant create request before configuring http client");

            return new Request(new HttpRequestMessage(method, uri), httpClient, requestId);
        }
    }
}
