using CryptoExchange.Net.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace CryptoExchange.Net.Objects.Options
{
    public class HttpApiOptionsBuilder
    {
        internal readonly HttpApiOptions _options;

        public HttpApiOptionsBuilder()
        {
            _options = new HttpApiOptions();
        }

        /// <summary>
        /// Create ExchangeOptions from the builder
        /// </summary>
        /// <returns></returns>
        public HttpApiOptions Build() => _options;
    }

    public static class HttpApiOptionsBuilderExtensions
    {
        public static HttpApiOptionsBuilder WithRequestTimeout(this HttpApiOptionsBuilder builder, TimeSpan requestTimeout)
        {
            builder._options.RequestTimeout = requestTimeout;
            return builder;
        }

        public static HttpApiOptionsBuilder UsingHttpClient(this HttpApiOptionsBuilder builder, HttpClient httpClient)
        {
            builder._options.HttpClient = httpClient;
            return builder;
        }

        public static HttpApiOptionsBuilder WithRateLimiting(this HttpApiOptionsBuilder builder, List<IRateLimiter> limiters, RateLimitingBehaviour limitBehaviour)
        {
            builder._options.RateLimiters = limiters;
            builder._options.RateLimitingBehaviour = limitBehaviour;
            return builder;
        }

        public static HttpApiOptionsBuilder WithoutRateLimiting(this HttpApiOptionsBuilder builder)
        { 
            builder._options.RateLimiters = new List<IRateLimiter>();
            return builder;
        }

        public static HttpApiOptionsBuilder UsingAutoTimestamping(this HttpApiOptionsBuilder builder, bool autoTimestamp)
        {
            builder._options.AutoTimestamp = autoTimestamp;
            return builder;
        }

        public static HttpApiOptionsBuilder WithTimestampRecalculationInterval(this HttpApiOptionsBuilder builder, TimeSpan timestampRecalculationInterval)
        {
            builder._options.TimestampRecalculationInterval = timestampRecalculationInterval;
            return builder;
        }
    }
}
