// <copyright file="ReloadlyUtilityPaymentsPayBillRequest.cs" company="APIMatic">
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
    /// ReloadlyUtilityPaymentsPayBillRequest.
    /// </summary>
    public class ReloadlyUtilityPaymentsPayBillRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReloadlyUtilityPaymentsPayBillRequest"/> class.
        /// </summary>
        public ReloadlyUtilityPaymentsPayBillRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReloadlyUtilityPaymentsPayBillRequest"/> class.
        /// </summary>
        /// <param name="subscriberAccountNumber">subscriberAccountNumber.</param>
        /// <param name="amount">amount.</param>
        /// <param name="billerId">billerId.</param>
        /// <param name="useLocalAmount">useLocalAmount.</param>
        public ReloadlyUtilityPaymentsPayBillRequest(
            string subscriberAccountNumber,
            int amount,
            int billerId,
            bool useLocalAmount)
        {
            this.SubscriberAccountNumber = subscriberAccountNumber;
            this.Amount = amount;
            this.BillerId = billerId;
            this.UseLocalAmount = useLocalAmount;
        }

        /// <summary>
        /// Gets or sets SubscriberAccountNumber.
        /// </summary>
        [JsonProperty("subscriberAccountNumber")]
        public string SubscriberAccountNumber { get; set; }

        /// <summary>
        /// Gets or sets Amount.
        /// </summary>
        [JsonProperty("amount")]
        public int Amount { get; set; }

        /// <summary>
        /// Gets or sets BillerId.
        /// </summary>
        [JsonProperty("billerId")]
        public int BillerId { get; set; }

        /// <summary>
        /// Gets or sets UseLocalAmount.
        /// </summary>
        [JsonProperty("useLocalAmount")]
        public bool UseLocalAmount { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ReloadlyUtilityPaymentsPayBillRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is ReloadlyUtilityPaymentsPayBillRequest other &&
                ((this.SubscriberAccountNumber == null && other.SubscriberAccountNumber == null) || (this.SubscriberAccountNumber?.Equals(other.SubscriberAccountNumber) == true)) &&
                this.Amount.Equals(other.Amount) &&
                this.BillerId.Equals(other.BillerId) &&
                this.UseLocalAmount.Equals(other.UseLocalAmount);
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.SubscriberAccountNumber = {(this.SubscriberAccountNumber == null ? "null" : this.SubscriberAccountNumber == string.Empty ? "" : this.SubscriberAccountNumber)}");
            toStringOutput.Add($"this.Amount = {this.Amount}");
            toStringOutput.Add($"this.BillerId = {this.BillerId}");
            toStringOutput.Add($"this.UseLocalAmount = {this.UseLocalAmount}");
        }
    }
}