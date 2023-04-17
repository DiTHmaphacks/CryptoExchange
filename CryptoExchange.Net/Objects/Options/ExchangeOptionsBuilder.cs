using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Logging;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace CryptoExchange.Net.Objects.Options
{
    /// <summary>
    /// Exchange options builder
    /// </summary>
    public class ExchangeOptionsBuilder
    {
        internal readonly ExchangeOptions _options;

        /// <summary>
        /// Start an options builder
        /// </summary>
        public ExchangeOptionsBuilder()
        {
            _options = new ExchangeOptions();
        }

        /// <summary>
        /// Create ExchangeOptions from the builder
        /// </summary>
        /// <returns></returns>
        public ExchangeOptions Build() => _options;
    }

    public static class ExchangeOptionsBuilderExtensions
    {
        public static ApiOptionsBuilder OutputOriginalData(this ApiOptionsBuilder builder, bool outputOriginalData)
        {
            builder._options.OutputOriginalData = outputOriginalData;
            return builder;
        }

        public static ExchangeOptionsBuilder WithMinimalLogLevel(this ExchangeOptionsBuilder builder, LogLevel level)
        {
            builder._options.LogLevel = level;
            return builder;
        }

        public static ExchangeOptionsBuilder WithLogger(this ExchangeOptionsBuilder builder, ILogger logger)
        {
            builder._options.LogWriters = new List<ILogger>() { logger };
            return builder;
        }

        public static ExchangeOptionsBuilder WithLoggers(this ExchangeOptionsBuilder builder, IEnumerable<ILogger> loggers)
        {
            builder._options.LogWriters = loggers.ToList();
            return builder;
        }

        public static ExchangeOptionsBuilder ViaProxy(this ExchangeOptionsBuilder builder, ApiProxy proxy)
        {
            builder._options.Proxy = proxy;
            return builder;
        }

        public static ExchangeOptionsBuilder WithCredentials(this ExchangeOptionsBuilder builder, ApiCredentials credentials)
        {
            builder._options.ApiCredentials = credentials;
            return builder;
        }
    }
}
