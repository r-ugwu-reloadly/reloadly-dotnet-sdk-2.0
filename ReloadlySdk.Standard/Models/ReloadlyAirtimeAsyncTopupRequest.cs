// <copyright file="ReloadlyAirtimeAsyncTopupRequest.cs" company="APIMatic">
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
    /// ReloadlyAirtimeAsyncTopupRequest.
    /// </summary>
    public class ReloadlyAirtimeAsyncTopupRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReloadlyAirtimeAsyncTopupRequest"/> class.
        /// </summary>
        public ReloadlyAirtimeAsyncTopupRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReloadlyAirtimeAsyncTopupRequest"/> class.
        /// </summary>
        /// <param name="operatorId">operatorId.</param>
        /// <param name="amount">amount.</param>
        /// <param name="useLocalAmount">useLocalAmount.</param>
        /// <param name="customIdentifier">customIdentifier.</param>
        /// <param name="recipientPhone">recipientPhone.</param>
        /// <param name="senderPhone">senderPhone.</param>
        public ReloadlyAirtimeAsyncTopupRequest(
            string operatorId,
            string amount,
            bool useLocalAmount,
            string customIdentifier,
            Models.RecipientPhone recipientPhone,
            Models.SenderPhone senderPhone)
        {
            this.OperatorId = operatorId;
            this.Amount = amount;
            this.UseLocalAmount = useLocalAmount;
            this.CustomIdentifier = customIdentifier;
            this.RecipientPhone = recipientPhone;
            this.SenderPhone = senderPhone;
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

        /// <summary>
        /// Gets or sets UseLocalAmount.
        /// </summary>
        [JsonProperty("useLocalAmount")]
        public bool UseLocalAmount { get; set; }

        /// <summary>
        /// Gets or sets CustomIdentifier.
        /// </summary>
        [JsonProperty("customIdentifier")]
        public string CustomIdentifier { get; set; }

        /// <summary>
        /// Gets or sets RecipientPhone.
        /// </summary>
        [JsonProperty("recipientPhone")]
        public Models.RecipientPhone RecipientPhone { get; set; }

        /// <summary>
        /// Gets or sets SenderPhone.
        /// </summary>
        [JsonProperty("senderPhone")]
        public Models.SenderPhone SenderPhone { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ReloadlyAirtimeAsyncTopupRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is ReloadlyAirtimeAsyncTopupRequest other &&
                ((this.OperatorId == null && other.OperatorId == null) || (this.OperatorId?.Equals(other.OperatorId) == true)) &&
                ((this.Amount == null && other.Amount == null) || (this.Amount?.Equals(other.Amount) == true)) &&
                this.UseLocalAmount.Equals(other.UseLocalAmount) &&
                ((this.CustomIdentifier == null && other.CustomIdentifier == null) || (this.CustomIdentifier?.Equals(other.CustomIdentifier) == true)) &&
                ((this.RecipientPhone == null && other.RecipientPhone == null) || (this.RecipientPhone?.Equals(other.RecipientPhone) == true)) &&
                ((this.SenderPhone == null && other.SenderPhone == null) || (this.SenderPhone?.Equals(other.SenderPhone) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.OperatorId = {(this.OperatorId == null ? "null" : this.OperatorId == string.Empty ? "" : this.OperatorId)}");
            toStringOutput.Add($"this.Amount = {(this.Amount == null ? "null" : this.Amount == string.Empty ? "" : this.Amount)}");
            toStringOutput.Add($"this.UseLocalAmount = {this.UseLocalAmount}");
            toStringOutput.Add($"this.CustomIdentifier = {(this.CustomIdentifier == null ? "null" : this.CustomIdentifier == string.Empty ? "" : this.CustomIdentifier)}");
            toStringOutput.Add($"this.RecipientPhone = {(this.RecipientPhone == null ? "null" : this.RecipientPhone.ToString())}");
            toStringOutput.Add($"this.SenderPhone = {(this.SenderPhone == null ? "null" : this.SenderPhone.ToString())}");
        }
    }
}