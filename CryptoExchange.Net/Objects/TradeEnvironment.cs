using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoExchange.Net.Objects
{
    /// <summary>
    /// Trade environment names
    /// </summary>
    public static class TradeEnvironmentNames
    {
        /// <summary>
        /// Live environment
        /// </summary>
        public const string Live = "live";
        /// <summary>
        /// Testnet environment
        /// </summary>
        public const string Testnet = "testnet";
    }

    /// <summary>
    /// Trade environment info
    /// </summary>
    public class TradeEnvironment
    {
        /// <summary>
        /// Name of the environement
        /// </summary>
        public string EnvironmentName { get; init; }
        /// <summary>
        /// Base address
        /// </summary>
        public Dictionary<string, string> Addresses { get; init; }

        /// <summary>
        /// </summary>
        /// <param name="name"></param>
        /// <param name="addresses"></param>
        public TradeEnvironment(string name, Dictionary<string, string> addresses)
        {
            EnvironmentName = name;
            Addresses = addresses;
        }
    }
}
