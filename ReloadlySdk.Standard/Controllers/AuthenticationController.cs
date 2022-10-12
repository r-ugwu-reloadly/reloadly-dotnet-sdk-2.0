// <copyright file="AuthenticationController.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace ReloadlySdk.Standard.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Newtonsoft.Json.Converters;
    using ReloadlySdk.Standard;
    using ReloadlySdk.Standard.Authentication;
    using ReloadlySdk.Standard.Exceptions;
    using ReloadlySdk.Standard.Http.Client;
    using ReloadlySdk.Standard.Http.Request;
    using ReloadlySdk.Standard.Http.Request.Configuration;
    using ReloadlySdk.Standard.Http.Response;
    using ReloadlySdk.Standard.Utilities;

    /// <summary>
    /// AuthenticationController.
    /// </summary>
    public class AuthenticationController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationController"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        internal AuthenticationController(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers)
            : base(config, httpClient, authManagers)
        {
        }

        /// <summary>
        /// reloadly-auth EndPoint.
        /// </summary>
        /// <param name="contentType">Required parameter: Example: application/json.</param>
        /// <param name="body">Required parameter: Request Payload.</param>
        /// <returns>Returns the dynamic response from the API call.</returns>
        public dynamic ReloadlyAuth(
                string contentType,
                object body)
        {
            Task<dynamic> t = this.ReloadlyAuthAsync(contentType, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// reloadly-auth EndPoint.
        /// </summary>
        /// <param name="contentType">Required parameter: Example: application/json.</param>
        /// <param name="body">Required parameter: Request Payload.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the dynamic response from the API call.</returns>
        public async Task<dynamic> ReloadlyAuthAsync(
                string contentType,
                object body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri(Server.Authentication);

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/token");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Content-Type", contentType },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);

            if (response.StatusCode == 401)
            {
                throw new ApiException("Access Denied", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<dynamic>(response.Body);
        }
    }
}