﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoExchange.Net.ComonObjects
{
    /// <summary>
    /// Order type
    /// </summary>
    public enum OrderType
    {
        /// <summary>
        /// Limit type
        /// </summary>
        Limit,
        /// <summary>
        /// Market type
        /// </summary>
        Market,
        /// <summary>
        /// Other order type
        /// </summary>
        Other
    }

    /// <summary>
    /// Order side
    /// </summary>
    public enum OrderSide
    {
        /// <summary>
        /// Buy order
        /// </summary>
        Buy,
        /// <summary>
        /// Sell order
        /// </summary>
        Sell
    }
    /// <summary>
    /// Order status
    /// </summary>
    public enum OrderStatus
    {
        /// <summary>
        /// placed and not fully filled order
        /// </summary>
        Active,
        /// <summary>
        /// canceled order
        /// </summary>
        Canceled,
        /// <summary>
        /// filled order
        /// </summary>
        Filled
    }
    
    /// <summary>
    /// Position side
    /// </summary>
    public enum PositionSide
    {
        /// <summary>
        /// Long position
        /// </summary>
        Long,
        /// <summary>
        /// Short position
        /// </summary>
        Short,
        /// <summary>
        /// Both
        /// </summary>
        Both
    }
}
