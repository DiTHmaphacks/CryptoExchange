using CryptoExchange.Net.Authentication;

namespace CryptoExchange.Net.Objects.Options
{
    /// <summary>
    /// Exchange options
    /// </summary>
    public class ExchangeOptions
    {
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
                OutputOriginalData = OutputOriginalData
            };
        }
    }
}
