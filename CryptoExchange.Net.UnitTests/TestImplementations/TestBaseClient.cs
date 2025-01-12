﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Options;
using CryptoExchange.Net.UnitTests.TestImplementations;
using Microsoft.Extensions.Logging;

namespace CryptoExchange.Net.UnitTests
{
    public class TestBaseClient: BaseClient
    {       
        public TestSubClient SubClient { get; }

        public TestBaseClient(): base(null, "Test")
        {
            var options = TestClientOptions.Default.Copy();
            Initialize(options);
            SubClient = AddApiClient(new TestSubClient(options, new RestApiOptions()));
        }

        public TestBaseClient(TestClientOptions exchangeOptions) : base(null, "Test")
        {
            Initialize(exchangeOptions);
            SubClient = AddApiClient(new TestSubClient(exchangeOptions, new RestApiOptions()));
        }

        public void Log(LogLevel verbosity, string data)
        {
            _logger.Log(verbosity, data);
        }
    }

    public class TestSubClient : RestApiClient
    {
        public TestSubClient(RestExchangeOptions<TestEnvironment> options, RestApiOptions apiOptions) : base(new TraceLogger(), null, "https://localhost:123", options, apiOptions)
        {
        }

        public CallResult<T> Deserialize<T>(string data) => Deserialize<T>(data, null, null);

        public override TimeSpan? GetTimeOffset() => null;
        public override TimeSyncInfo GetTimeSyncInfo() => null;
        protected override AuthenticationProvider CreateAuthenticationProvider(ApiCredentials credentials) => throw new NotImplementedException();
        protected override Task<WebCallResult<DateTime>> GetServerTimestampAsync() => throw new NotImplementedException();
    }

    public class TestAuthProvider : AuthenticationProvider
    {
        public TestAuthProvider(ApiCredentials credentials) : base(credentials)
        {
        }

        public override void AuthenticateRequest(RestApiClient apiClient, Uri uri, HttpMethod method, Dictionary<string, object> providedParameters, bool auth, ArrayParametersSerialization arraySerialization, HttpMethodParameterPosition parameterPosition, out SortedDictionary<string, object> uriParameters, out SortedDictionary<string, object> bodyParameters, out Dictionary<string, string> headers)
        {
            bodyParameters = new SortedDictionary<string, object>();
            uriParameters = new SortedDictionary<string, object>();
            headers = new Dictionary<string, string>();
        }

        public string GetKey() => _credentials.Key.GetString();
        public string GetSecret() => _credentials.Secret.GetString();
    }
}
