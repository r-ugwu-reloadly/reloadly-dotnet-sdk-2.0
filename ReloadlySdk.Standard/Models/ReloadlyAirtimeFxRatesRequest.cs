// <copyright file="ReloadlyAirtimeFxRatesRequest.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace ReloadlySdk.Standard.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using ReloadlySdk.Standard;
    using ReloadlySdk.Standard.Utilities;

    /// <summary>
    /// ReloadlyAirtimeFxRatesRequest.
    /// </summary>
    public class ReloadlyAirtimeFxRatesRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReloadlyAirtimeFxRatesRequest"/> class.
        /// </summary>
        public ReloadlyAirtimeFxRatesRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReloadlyAirtimeFxRatesRequest"/> class.
        /// </summary>
        /// <param name="operatorId">operatorId.</param>
        /// <param name="amount">amount.</param>
        public ReloadlyAirtimeFxRatesRequest(
            string operatorId,
            string amount)
        {
            this.OperatorId = operatorId;
            this.Amount = amount;
        }

        /// <summary>
        /// Gets or sets OperatorId.
        /// </summary>
        [JsonProperty("operatorId")]
        public string OperatorId { get; set; }

        /// <summary>
        /// Gets or sets Amount.
        /// </summary>
        [JsonProperty("amount")]
        public string Amount { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ReloadlyAirtimeFxRatesRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }

            return obj is ReloadlyAirtimeFxRatesRequest other &&
                ((this.OperatorId == null && other.OperatorId == null) || (this.OperatorId?.Equals(other.OperatorId) == true)) &&
                ((this.Amount == null && other.Amount == null) || (this.Amount?.Equals(other.Amount) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.OperatorId = {(this.OperatorId == null ? "null" : this.OperatorId == string.Empty ? "" : this.OperatorId)}");
            toStringOutput.Add($"this.Amount = {(this.Amount == null ? "null" : this.Amount == string.Empty ? "" : this.Amount)}");
        }
    }
}