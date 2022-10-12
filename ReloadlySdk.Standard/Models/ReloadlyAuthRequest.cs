// <copyright file="ReloadlyAuthRequest.cs" company="APIMatic">
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
    /// ReloadlyAuthRequest.
    /// </summary>
    public class ReloadlyAuthRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReloadlyAuthRequest"/> class.
        /// </summary>
        public ReloadlyAuthRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReloadlyAuthRequest"/> class.
        /// </summary>
        /// <param name="clientId">client_id.</param>
        /// <param name="clientSecret">client_secret.</param>
        /// <param name="grantType">grant_type.</param>
        /// <param name="audience">audience.</param>
        public ReloadlyAuthRequest(
            string clientId,
            string clientSecret,
            string grantType,
            string audience)
        {
            this.ClientId = clientId;
            this.ClientSecret = clientSecret;
            this.GrantType = grantType;
            this.Audience = audience;
        }

        /// <summary>
        /// Gets or sets ClientId.
        /// </summary>
        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets ClientSecret.
        /// </summary>
        [JsonProperty("client_secret")]
        public string ClientSecret { get; set; }

        /// <summary>
        /// Gets or sets GrantType.
        /// </summary>
        [JsonProperty("grant_type")]
        public string GrantType { get; set; }

        /// <summary>
        /// Gets or sets Audience.
        /// </summary>
        [JsonProperty("audience")]
        public string Audience { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ReloadlyAuthRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is ReloadlyAuthRequest other &&
                ((this.ClientId == null && other.ClientId == null) || (this.ClientId?.Equals(other.ClientId) == true)) &&
                ((this.ClientSecret == null && other.ClientSecret == null) || (this.ClientSecret?.Equals(other.ClientSecret) == true)) &&
                ((this.GrantType == null && other.GrantType == null) || (this.GrantType?.Equals(other.GrantType) == true)) &&
                ((this.Audience == null && other.Audience == null) || (this.Audience?.Equals(other.Audience) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.ClientId = {(this.ClientId == null ? "null" : this.ClientId == string.Empty ? "" : this.ClientId)}");
            toStringOutput.Add($"this.ClientSecret = {(this.ClientSecret == null ? "null" : this.ClientSecret == string.Empty ? "" : this.ClientSecret)}");
            toStringOutput.Add($"this.GrantType = {(this.GrantType == null ? "null" : this.GrantType == string.Empty ? "" : this.GrantType)}");
            toStringOutput.Add($"this.Audience = {(this.Audience == null ? "null" : this.Audience == string.Empty ? "" : this.Audience)}");
        }
    }
}