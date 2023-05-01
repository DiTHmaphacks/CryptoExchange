using System;

namespace CryptoExchange.Net.Objects.Options
{
    /// <summary>
    /// Socket api options
    /// </summary>
    public class SocketApiOptions : ApiOptions
    {
        /// <summary>
        /// Proxy settings
        /// </summary>
        public ApiProxy? Proxy { get; set; }

        /// <summary>
        /// Whether or not the socket should automatically reconnect when losing connection
        /// </summary>
        public bool AutoReconnect { get; set; } = true;

        /// <summary>
        /// Time to wait between reconnect attempts
        /// </summary>
        public TimeSpan ReconnectInterval { get; set; } = TimeSpan.FromSeconds(5);

        /// <summary>
        /// Max number of concurrent resubscription tasks per socket after reconnecting a socket
        /// </summary>
        public int MaxConcurrentResubscriptionsPerSocket { get; set; } = 5;

        /// <summary>
        /// The max time to wait for a response after sending a request on the socket before giving a timeout
        /// </summary>
        public TimeSpan SocketResponseTimeout { get; set; } = TimeSpan.FromSeconds(10);

        /// <summary>
        /// The max time of not receiving any data after which the connection is assumed to be dropped. This can only be used for socket connections where a steady flow of data is expected,
        /// for example when the server sends intermittent ping requests
        /// </summary>
        public TimeSpan SocketNoDataTimeout { get; set; }

        /// <summary>
        /// The amount of subscriptions that should be made on a single socket connection. Not all API's support multiple subscriptions on a single socket.
        /// Setting this to a higher number increases subscription speed because not every subscription needs to connect to the server, but having more subscriptions on a 
        /// single connection will also increase the amount of traffic on that single connection, potentially leading to issues.
        /// </summary>
        public int? SocketSubscriptionsCombineTarget { get; set; }

        /// <summary>
        /// The max amount of connections to make to the server. Can be used for API's which only allow a certain number of connections. Changing this to a high value might cause issues.
        /// </summary>
        public int? MaxSocketConnections { get; set; }

        /// <summary>
        /// The time to wait after connecting a socket before sending messages. Can be used for API's which will rate limit if you subscribe directly after connecting.
        /// </summary>
        public TimeSpan DelayAfterConnect { get; set; } = TimeSpan.Zero;

        /// <summary>
        /// Create a copy of this options
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Copy<T>() where T : SocketApiOptions, new()
        {
            return new T
            {
                ApiCredentials = ApiCredentials?.Copy(),
                OutputOriginalData = OutputOriginalData,
                AutoReconnect = AutoReconnect,
                DelayAfterConnect = DelayAfterConnect,
                MaxConcurrentResubscriptionsPerSocket = MaxConcurrentResubscriptionsPerSocket,
                SocketResponseTimeout = SocketResponseTimeout,
                ReconnectInterval = ReconnectInterval,
                SocketNoDataTimeout = SocketNoDataTimeout,
                SocketSubscriptionsCombineTarget = SocketSubscriptionsCombineTarget,
                MaxSocketConnections = MaxSocketConnections,
                TradeEnvironment = TradeEnvironment
            };
        }
    }
}
