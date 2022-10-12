// <copyright file="AirtimeFXRatesController.cs" company="APIMatic">
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
    /// AirtimeFXRatesController.
    /// </summary>
    public class AirtimeFXRatesController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AirtimeFXRatesController"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        internal AirtimeFXRatesController(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers)
            : base(config, httpClient, authManagers)
        {
        }

        /// <summary>
        /// reloadly-airtime-fx-rates EndPoint.
        /// </summary>
        /// <param name="accept">Required parameter: Example: application/com.reloadly.topups-v1+json.</param>
        /// <param name="authorization">Required parameter: Example: .</param>
        /// <param name="body">Required parameter: Payload description.</param>
        /// <returns>Returns the dynamic response from the API call.</returns>
        public dynamic ReloadlyAirtimeFxRates(
                string accept,
                string authorization,
                object body)
        {
            Task<dynamic> t = this.ReloadlyAirtimeFxRatesAsync(accept, authorization, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// reloadly-airtime-fx-rates EndPoint.
        /// </summary>
        /// <param name="accept">Required parameter: Example: application/com.reloadly.topups-v1+json.</param>
        /// <param name="authorization">Required parameter: Example: .</param>
        /// <param name="body">Required parameter: Payload description.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the dynamic response from the API call.</returns>
        public async Task<dynamic> ReloadlyAirtimeFxRatesAsync(
                string accept,
                string authorization,
                object body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri(Server.Airtime);

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/operators/fx-rate");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "Accept", accept },
                { "Authorization", authorization },
                { "Content-Type", "application/json" },
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
                throw new ApiException("Full authentication is required to access this resource", context);
            }

            if (response.StatusCode == 404)
            {
                throw new ApiException("Not Found", context);
            }

            if (response.StatusCode == 500)
            {
                throw new ApiException("Fx rate is currently not available for this operator, please try again later or contact support.", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<dynamic>(response.Body);
        }
    }
}