using CryptoExchange.Net.Authentication;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace CryptoExchange.Net.Objects.Options
{
    public class ApiOptions
    {
        /// <summary>
        /// If true, the CallResult and DataEvent objects will also include the originally received json data in the OriginalData property
        /// </summary>
        public bool OutputOriginalData { get; set; } = false;

        /// <summary>
        /// The base address of the API
        /// </summary>
        public string BaseAddress { get; set; }

        /// <summary>
        /// The api credentials used for signing requests to this API. Overrides API credentials provided in the client options
        /// </summary>        
        public ApiCredentials? ApiCredentials { get; set; }
    }
}
