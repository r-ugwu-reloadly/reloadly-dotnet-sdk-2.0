// <copyright file="ReloadlyNumberLookupPostRequest.cs" company="APIMatic">
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
    /// ReloadlyNumberLookupPostRequest.
    /// </summary>
    public class ReloadlyNumberLookupPostRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReloadlyNumberLookupPostRequest"/> class.
        /// </summary>
        public ReloadlyNumberLookupPostRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReloadlyNumberLookupPostRequest"/> class.
        /// </summary>
        /// <param name="number">number.</param>
        /// <param name="countryCode">countryCode.</param>
        public ReloadlyNumberLookupPostRequest(
            string number,
            string countryCode)
        {
            this.Number = number;
            this.CountryCode = countryCode;
        }

        /// <summary>
        /// Gets or sets Number.
        /// </summary>
        [JsonProperty("number")]
        public string Number { get; set; }

        /// <summary>
        /// Gets or sets CountryCode.
        /// </summary>
        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ReloadlyNumberLookupPostRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is ReloadlyNumberLookupPostRequest other &&
                ((this.Number == null && other.Number == null) || (this.Number?.Equals(other.Number) == true)) &&
                ((this.CountryCode == null && other.CountryCode == null) || (this.CountryCode?.Equals(other.CountryCode) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Number = {(this.Number == null ? "null" : this.Number == string.Empty ? "" : this.Number)}");
            toStringOutput.Add($"this.CountryCode = {(this.CountryCode == null ? "null" : this.CountryCode == string.Empty ? "" : this.CountryCode)}");
        }
    }
}