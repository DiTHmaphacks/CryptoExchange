namespace CryptoExchange.Net.Objects.Options
{
    /// <summary>
    /// Base for order book options
    /// </summary>
    public class OrderBookOptions : ExchangeOptions
    {
        /// <summary>
        /// Whether or not checksum validation is enabled. Default is true, disabling will ignore checksum messages.
        /// </summary>
        public bool ChecksumValidationEnabled { get; set; } = true;
    }
}
