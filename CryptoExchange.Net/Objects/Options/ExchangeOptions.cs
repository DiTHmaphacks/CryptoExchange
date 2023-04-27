using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Logging;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace CryptoExchange.Net.Objects.Options
{
    /// <summary>
    /// Exchange options
    /// </summary>
    public class ExchangeOptions
    {
        internal event Action? OnLoggingChanged;

        private LogLevel _logLevel = LogLevel.Information;
        /// <summary>
        /// The minimum log level to output
        /// </summary>
        public LogLevel LogLevel
        {
            get => _logLevel;
            set
            {
                _logLevel = value;
                OnLoggingChanged?.Invoke();
            }
        }

        private List<ILogger> _logWriters = new List<ILogger> { new DebugLogger() };
        /// <summary>
        /// The log writers
        /// </summary>
        public List<ILogger> LogWriters
        {
            get => _logWriters;
            set
            {
                _logWriters = value;
                OnLoggingChanged?.Invoke();
            }
        }

        /// <summary>
        /// Proxy to use when connecting
        /// </summary>
        public ApiProxy? Proxy { get; set; }

        /// <summary>
        /// The api credentials used for signing requests to this API.
        /// </summary>        
        public ApiCredentials? ApiCredentials { get; set; }

        /// <summary>
        /// If true, the CallResult and DataEvent objects will also include the originally received json data in the OriginalData property
        /// </summary>
        public bool OutputOriginalData { get; set; } = false;

        /// <summary>
        /// Create a copy of this options
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected T Copy<T>() where T: ExchangeOptions, new()
        {
            return new T
            {
                ApiCredentials = ApiCredentials?.Copy(),
                LogLevel = _logLevel,
                Proxy = Proxy,
                LogWriters = LogWriters,
                OutputOriginalData = OutputOriginalData
            };
        }
    }
}
