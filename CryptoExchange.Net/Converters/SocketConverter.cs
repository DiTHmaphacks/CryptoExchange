﻿using CryptoExchange.Net.Objects.Sockets;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CryptoExchange.Net.Converters
{
    public abstract class SocketConverter
    {
        public virtual string[]? SubscriptionIdFields => null;
        public abstract string[] TypeIdFields { get; }

        public abstract Type? GetDeserializationType(Dictionary<string, string> idValues, List<MessageListener> listeners);

        /// <inheritdoc />
        public ParsedMessage? ReadJson(Stream stream, List<MessageListener> listeners, bool outputOriginalData)
        {
            // Start reading the data
            // Once we reach the properties that identify the message we save those in a dict
            // Once all id properties have been read callback to see what the deserialization type should be
            // Deserialize to the correct type
            var result = new ParsedMessage();

            using var sr = new StreamReader(stream, Encoding.UTF8, false, (int)stream.Length, true);
            if (outputOriginalData)
            {
                result.OriginalData = sr.ReadToEnd();
                stream.Position = 0;
            }

            using var jsonTextReader = new JsonTextReader(sr);
            JToken token;
            try
            {
                token = JToken.Load(jsonTextReader);
            }
            catch(Exception ex)
            {
                return null;
            }

            if (token.Type == JTokenType.Array)
            {
                // Received array, take first item as reference
                token = token.First!;
            }

            var typeIdDict = new Dictionary<string, string>();
            foreach(var idField in TypeIdFields)
            {
                var splitTokens = idField.Split(new char[] { ':' });
                var accessToken = token;
                foreach (var splitToken in splitTokens)
                {
                    accessToken = accessToken[splitToken];

                    if (accessToken == null)
                        break;

                    if (accessToken.Type == JTokenType.Array)
                    {
                        // Received array, take first item as reference
                        accessToken = accessToken.First!;
                    }
                }

                typeIdDict[idField] = accessToken?.ToString();
            }

            string idString = "";
            if (SubscriptionIdFields != null)
            {
                foreach (var idField in SubscriptionIdFields)
                {
                    var splitTokens = idField.Split(new char[] { ':' });
                    var accessToken = token;
                    foreach (var splitToken in splitTokens)
                    {
                        accessToken = accessToken[splitToken];
                        if (accessToken == null)
                            break;
                    }
                    idString += accessToken?.ToString();
                }
            }
            else
            {
                foreach (var item in typeIdDict)
                    idString += item.Value;
            }

            result.Identifier = idString;
            var resultType = GetDeserializationType(typeIdDict, listeners);
            result.Data = resultType == null ? null : token.ToObject(resultType);

            return result;
        }
    }

    public class ParsedMessage
    {
        public string Identifier { get; set; } = null!;
        public string? OriginalData { get; set; }
        public object? Data { get; set; }
    }
}
