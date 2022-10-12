// <copyright file="RecipientPhoneDetails.cs" company="APIMatic">
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
    /// RecipientPhoneDetails.
    /// </summary>
    public class RecipientPhoneDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RecipientPhoneDetails"/> class.
        /// </summary>
        public RecipientPhoneDetails()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RecipientPhoneDetails"/> class.
        /// </summary>
        /// <param name="countryCode">countryCode.</param>
        /// <param name="phoneNumber">phoneNumber.</param>
        public RecipientPhoneDetails(
            string countryCode,
            string phoneNumber)
        {
            this.CountryCode = countryCode;
            this.PhoneNumber = phoneNumber;
        }

        /// <summary>
        /// Gets or sets CountryCode.
        /// </summary>
        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }

        /// <summary>
        /// Gets or sets PhoneNumber.
        /// </summary>
        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"RecipientPhoneDetails : ({string.Join(", ", toStringOutput)})";
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

            return obj is RecipientPhoneDetails other &&
                ((this.CountryCode == null && other.CountryCode == null) || (this.CountryCode?.Equals(other.CountryCode) == true)) &&
                ((this.PhoneNumber == null && other.PhoneNumber == null) || (this.PhoneNumber?.Equals(other.PhoneNumber) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.CountryCode = {(this.CountryCode == null ? "null" : this.CountryCode == string.Empty ? "" : this.CountryCode)}");
            toStringOutput.Add($"this.PhoneNumber = {(this.PhoneNumber == null ? "null" : this.PhoneNumber == string.Empty ? "" : this.PhoneNumber)}");
        }
    }
}