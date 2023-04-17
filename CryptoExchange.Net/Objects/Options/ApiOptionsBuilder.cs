using CryptoExchange.Net.Authentication;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoExchange.Net.Objects.Options
{
    public class ApiOptionsBuilder
    {
        internal readonly ApiOptions _options;

        public ApiOptionsBuilder()
        {
            _options = new ApiOptions();
        }

        /// <summary>
        /// Create ExchangeOptions from the builder
        /// </summary>
        /// <returns></returns>
        public ApiOptions Build() => _options;
    }

    public static class ApiOptionsBuilderExtensions
    {
        public static ApiOptionsBuilder OutputOriginalData(this ApiOptionsBuilder builder, bool outputOriginalData)
        {
            builder._options.OutputOriginalData = outputOriginalData;
            return builder;
        }

        public static ApiOptionsBuilder UsingBaseAddress(this ApiOptionsBuilder builder, string baseAddress)
        {
            builder._options.BaseAddress = baseAddress;
            return builder;
        }

        public static ApiOptionsBuilder WithCredentials(this ApiOptionsBuilder builder, ApiCredentials credentials)
        {
            builder._options.ApiCredentials = credentials;
            return builder;
        }
    }
}
