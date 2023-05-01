using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace CryptoExchange.Net.Objects
{
    /// <summary>
    /// Trace logger provider for creating trace loggers
    /// </summary>
    public class TraceLoggerProvider : ILoggerProvider
    {
        /// <inheritdoc />
        public ILogger CreateLogger(string categoryName) => new TraceLogger();
        /// <inheritdoc />
        public void Dispose() { }
    }

    /// <summary>
    /// Trace logger
    /// </summary>
    public class TraceLogger : ILogger
    {
        /// <inheritdoc />
        public IDisposable BeginScope<TState>(TState state) => null!;
        /// <inheritdoc />
        public bool IsEnabled(LogLevel logLevel) => true;
        /// <inheritdoc />
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            var logMessage = $"{DateTime.Now:yyyy/MM/dd HH:mm:ss:fff} | {logLevel} | {formatter(state, exception)}";
            Trace.WriteLine(logMessage);
        }
    }
}
