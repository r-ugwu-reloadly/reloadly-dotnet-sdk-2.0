// <copyright file="UtilityPaymentsAccountBalanceController.cs" company="APIMatic">
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
    /// UtilityPaymentsAccountBalanceController.
    /// </summary>
    public class UtilityPaymentsAccountBalanceController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UtilityPaymentsAccountBalanceController"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        internal UtilityPaymentsAccountBalanceController(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers)
            : base(config, httpClient, authManagers)
        {
        }

        /// <summary>
        /// reloadly-utility-payments-account-balance EndPoint.
        /// </summary>
        /// <param name="accept">Required parameter: Example: .</param>
        /// <param name="authorization">Required parameter: Example: .</param>
        /// <returns>Returns the dynamic response from the API call.</returns>
        public dynamic ReloadlyUtilityPaymentsAccountBalance(
                string accept,
                string authorization)
        {
            Task<dynamic> t = this.ReloadlyUtilityPaymentsAccountBalanceAsync(accept, authorization);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// reloadly-utility-payments-account-balance EndPoint.
        /// </summary>
        /// <param name="accept">Required parameter: Example: .</param>
        /// <param name="authorization">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the dynamic response from the API call.</returns>
        public async Task<dynamic> ReloadlyUtilityPaymentsAccountBalanceAsync(
                string accept,
                string authorization,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri(Server.UtilityPayments);

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/accounts/balance");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "Accept", accept },
                { "Authorization", authorization },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers);

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

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<dynamic>(response.Body);
        }
    }
}