using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoExchange.Net.Objects.Options
{
    public class SocketApiOptionsBuilder
    {
        internal readonly SocketApiOptions _options;

        public SocketApiOptionsBuilder()
        {
            _options = new SocketApiOptions();
        }

        /// <summary>
        /// Create ExchangeOptions from the builder
        /// </summary>
        /// <returns></returns>
        public SocketApiOptions Build() => _options;
    }

    public static class SocketApiOptionsBuilderExtensions
    {
        public static SocketApiOptionsBuilder WithAutoReconnect(this SocketApiOptionsBuilder builder)
        {
            builder._options.AutoReconnect = true;
            return builder;
        }

        public static SocketApiOptionsBuilder WithoutAutoReconnect(this SocketApiOptionsBuilder builder)
        {
            builder._options.AutoReconnect = false;
            return builder;
        }

        public static SocketApiOptionsBuilder WithReconnectInterval(this SocketApiOptionsBuilder builder, TimeSpan reconnectInterval)
        {
            builder._options.ReconnectInterval = reconnectInterval;
            return builder;
        }

        public static SocketApiOptionsBuilder WithMaxConcurrentResubscriptionsPerSocket(this SocketApiOptionsBuilder builder, int max)
        {
            builder._options.MaxConcurrentResubscriptionsPerSocket = max;
            return builder;
        }

        public static SocketApiOptionsBuilder WithSocketResponseTimeout(this SocketApiOptionsBuilder builder, TimeSpan socketResponseTimeout)
        {
            builder._options.SocketResponseTimeout = socketResponseTimeout;
            return builder;
        }

        public static SocketApiOptionsBuilder WithSocketNoDataTimeout(this SocketApiOptionsBuilder builder, TimeSpan socketNoDataTimeout)
        {
            builder._options.SocketNoDataTimeout = socketNoDataTimeout;
            return builder;
        }

        public static SocketApiOptionsBuilder WithSocketSubscriptionsCombineTarget(this SocketApiOptionsBuilder builder, int target)
        {
            builder._options.SocketSubscriptionsCombineTarget = target;
            return builder;
        }

        public static SocketApiOptionsBuilder WithMaxSocketConnections(this SocketApiOptionsBuilder builder, int maxSocketConnections)
        {
            builder._options.MaxSocketConnections = maxSocketConnections;
            return builder;
        }

        public static SocketApiOptionsBuilder WithDelayAfterConnect(this SocketApiOptionsBuilder builder, TimeSpan delayAfterConnect)
        {
            builder._options.DelayAfterConnect = delayAfterConnect;
            return builder;
        }
    }
}
