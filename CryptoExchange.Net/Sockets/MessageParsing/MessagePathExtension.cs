﻿namespace CryptoExchange.Net.Sockets.MessageParsing
{
    /// <summary>
    /// Message path extension methods
    /// </summary>
    public static class MessagePathExtension
    {
        /// <summary>
        /// Add a string node accessor
        /// </summary>
        /// <param name="path"></param>
        /// <param name="propName"></param>
        /// <returns></returns>
        public static MessagePath Property(this MessagePath path, string propName)
        {
            path.Add(NodeAccessor.String(propName));
            return path;
        }

        /// <summary>
        /// Add a int node accessor
        /// </summary>
        /// <param name="path"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static MessagePath Index(this MessagePath path, int index)
        {
            path.Add(NodeAccessor.Int(index));
            return path;
        }
    }
}
