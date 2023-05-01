using CryptoExchange.Net.Authentication;

namespace CryptoExchange.Net.Objects.Options
{
    /// <summary>
    /// Options for API usage
    /// </summary>
    public class ApiOptions
    {
        /// <summary>
        /// If true, the CallResult and DataEvent objects will also include the originally received json data in the OriginalData property
        /// </summary>
        public bool OutputOriginalData { get; set; } = false;

        /// <summary>
        /// The environment of the API
        /// </summary>
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public TradeEnvironment TradeEnvironment { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        /// <summary>
        /// The api credentials used for signing requests to this API. Overrides API credentials provided in the client options
        /// </summary>        
        public ApiCredentials? ApiCredentials { get; set; }
    }
}
