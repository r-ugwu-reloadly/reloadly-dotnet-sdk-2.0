// <copyright file="ReloadlyGiftCardsOrdersRequest.cs" company="APIMatic">
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
    /// ReloadlyGiftCardsOrdersRequest.
    /// </summary>
    public class ReloadlyGiftCardsOrdersRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReloadlyGiftCardsOrdersRequest"/> class.
        /// </summary>
        public ReloadlyGiftCardsOrdersRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReloadlyGiftCardsOrdersRequest"/> class.
        /// </summary>
        /// <param name="productId">productId.</param>
        /// <param name="countryCode">countryCode.</param>
        /// <param name="quantity">quantity.</param>
        /// <param name="unitPrice">unitPrice.</param>
        /// <param name="customIdentifier">customIdentifier.</param>
        /// <param name="senderName">senderName.</param>
        /// <param name="recipientEmail">recipientEmail.</param>
        /// <param name="recipientPhoneDetails">recipientPhoneDetails.</param>
        public ReloadlyGiftCardsOrdersRequest(
            int productId,
            string countryCode,
            int quantity,
            int unitPrice,
            string customIdentifier,
            string senderName,
            string recipientEmail,
            Models.RecipientPhoneDetails recipientPhoneDetails)
        {
            this.ProductId = productId;
            this.CountryCode = countryCode;
            this.Quantity = quantity;
            this.UnitPrice = unitPrice;
            this.CustomIdentifier = customIdentifier;
            this.SenderName = senderName;
            this.RecipientEmail = recipientEmail;
            this.RecipientPhoneDetails = recipientPhoneDetails;
        }

        /// <summary>
        /// Gets or sets ProductId.
        /// </summary>
        [JsonProperty("productId")]
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets CountryCode.
        /// </summary>
        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }

        /// <summary>
        /// Gets or sets Quantity.
        /// </summary>
        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets UnitPrice.
        /// </summary>
        [JsonProperty("unitPrice")]
        public int UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets CustomIdentifier.
        /// </summary>
        [JsonProperty("customIdentifier")]
        public string CustomIdentifier { get; set; }

        /// <summary>
        /// Gets or sets SenderName.
        /// </summary>
        [JsonProperty("senderName")]
        public string SenderName { get; set; }

        /// <summary>
        /// Gets or sets RecipientEmail.
        /// </summary>
        [JsonProperty("recipientEmail")]
        public string RecipientEmail { get; set; }

        /// <summary>
        /// Gets or sets RecipientPhoneDetails.
        /// </summary>
        [JsonProperty("recipientPhoneDetails")]
        public Models.RecipientPhoneDetails RecipientPhoneDetails { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ReloadlyGiftCardsOrdersRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is ReloadlyGiftCardsOrdersRequest other &&
                this.ProductId.Equals(other.ProductId) &&
                ((this.CountryCode == null && other.CountryCode == null) || (this.CountryCode?.Equals(other.CountryCode) == true)) &&
                this.Quantity.Equals(other.Quantity) &&
                this.UnitPrice.Equals(other.UnitPrice) &&
                ((this.CustomIdentifier == null && other.CustomIdentifier == null) || (this.CustomIdentifier?.Equals(other.CustomIdentifier) == true)) &&
                ((this.SenderName == null && other.SenderName == null) || (this.SenderName?.Equals(other.SenderName) == true)) &&
                ((this.RecipientEmail == null && other.RecipientEmail == null) || (this.RecipientEmail?.Equals(other.RecipientEmail) == true)) &&
                ((this.RecipientPhoneDetails == null && other.RecipientPhoneDetails == null) || (this.RecipientPhoneDetails?.Equals(other.RecipientPhoneDetails) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.ProductId = {this.ProductId}");
            toStringOutput.Add($"this.CountryCode = {(this.CountryCode == null ? "null" : this.CountryCode == string.Empty ? "" : this.CountryCode)}");
            toStringOutput.Add($"this.Quantity = {this.Quantity}");
            toStringOutput.Add($"this.UnitPrice = {this.UnitPrice}");
            toStringOutput.Add($"this.CustomIdentifier = {(this.CustomIdentifier == null ? "null" : this.CustomIdentifier == string.Empty ? "" : this.CustomIdentifier)}");
            toStringOutput.Add($"this.SenderName = {(this.SenderName == null ? "null" : this.SenderName == string.Empty ? "" : this.SenderName)}");
            toStringOutput.Add($"this.RecipientEmail = {(this.RecipientEmail == null ? "null" : this.RecipientEmail == string.Empty ? "" : this.RecipientEmail)}");
            toStringOutput.Add($"this.RecipientPhoneDetails = {(this.RecipientPhoneDetails == null ? "null" : this.RecipientPhoneDetails.ToString())}");
        }
    }
}