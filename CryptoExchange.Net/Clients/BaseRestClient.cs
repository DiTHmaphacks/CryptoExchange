using System;
using System.Linq;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Options;
using Microsoft.Extensions.Logging;

namespace CryptoExchange.Net
{
    /// <summary>
    /// Base rest client
    /// </summary>
    public abstract class BaseRestClient : BaseClient, IRestClient
    {
        /// <inheritdoc />
        public int TotalRequestsMade => ApiClients.OfType<RestApiClient>().Sum(s => s.TotalRequestsMade);

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="logger">Logger</param>
        /// <param name="name">The name of the API this client is for</param>
        protected BaseRestClient(ILogger? logger, string name) : base(logger, name)
        {
        }
    }
}
