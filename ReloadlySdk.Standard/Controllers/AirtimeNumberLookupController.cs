// <copyright file="AirtimeNumberLookupController.cs" company="APIMatic">
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
    /// AirtimeNumberLookupController.
    /// </summary>
    public class AirtimeNumberLookupController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AirtimeNumberLookupController"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        internal AirtimeNumberLookupController(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers)
            : base(config, httpClient, authManagers)
        {
        }

        /// <summary>
        /// reloadly-number-lookup-get EndPoint.
        /// </summary>
        /// <param name="accept">Required parameter: Example: .</param>
        /// <param name="authorization">Required parameter: Example: .</param>
        /// <param name="phone">Required parameter: This is the mobile number whose details are to be retrieved..</param>
        /// <param name="countrycode">Required parameter: This is the ISO code of the country where the mobile number is registered..</param>
        /// <param name="suggestedAmountsMap">Optional parameter: Indicates if this field should be returned as a response. Default value is false..</param>
        /// <param name="suggestedAmounts">Optional parameter: Indicates if this field should be returned as a response. Default value is false..</param>
        /// <returns>Returns the dynamic response from the API call.</returns>
        public dynamic ReloadlyNumberLookupGet(
                string accept,
                string authorization,
                int phone,
                string countrycode,
                string suggestedAmountsMap = null,
                string suggestedAmounts = null)
        {
            Task<dynamic> t = this.ReloadlyNumberLookupGetAsync(accept, authorization, phone, countrycode, suggestedAmountsMap, suggestedAmounts);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// reloadly-number-lookup-get EndPoint.
        /// </summary>
        /// <param name="accept">Required parameter: Example: .</param>
        /// <param name="authorization">Required parameter: Example: .</param>
        /// <param name="phone">Required parameter: This is the mobile number whose details are to be retrieved..</param>
        /// <param name="countrycode">Required parameter: This is the ISO code of the country where the mobile number is registered..</param>
        /// <param name="suggestedAmountsMap">Optional parameter: Indicates if this field should be returned as a response. Default value is false..</param>
        /// <param name="suggestedAmounts">Optional parameter: Indicates if this field should be returned as a response. Default value is false..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the dynamic response from the API call.</returns>
        public async Task<dynamic> ReloadlyNumberLookupGetAsync(
                string accept,
                string authorization,
                int phone,
                string countrycode,
                string suggestedAmountsMap = null,
                string suggestedAmounts = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri(Server.Airtime);

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/operators/mnp-lookup/phone/{phone}/countries/{countrycode}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "phone", phone },
                { "countrycode", countrycode },
            });

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "suggestedAmountsMap", suggestedAmountsMap },
                { "suggestedAmounts", suggestedAmounts },
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "Accept", accept },
                { "Authorization", authorization },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers, queryParameters: queryParams);

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

        /// <summary>
        /// reloadly-number-lookup-post EndPoint.
        /// </summary>
        /// <param name="accept">Required parameter: Example: .</param>
        /// <param name="authorization">Required parameter: Example: .</param>
        /// <param name="contentType">Required parameter: Example: .</param>
        /// <param name="body">Required parameter: Request Payload.</param>
        /// <returns>Returns the dynamic response from the API call.</returns>
        public dynamic ReloadlyNumberLookupPost(
                string accept,
                string authorization,
                string contentType,
                object body)
        {
            Task<dynamic> t = this.ReloadlyNumberLookupPostAsync(accept, authorization, contentType, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// reloadly-number-lookup-post EndPoint.
        /// </summary>
        /// <param name="accept">Required parameter: Example: .</param>
        /// <param name="authorization">Required parameter: Example: .</param>
        /// <param name="contentType">Required parameter: Example: .</param>
        /// <param name="body">Required parameter: Request Payload.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the dynamic response from the API call.</returns>
        public async Task<dynamic> ReloadlyNumberLookupPostAsync(
                string accept,
                string authorization,
                string contentType,
                object body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri(Server.Airtime);

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/mnp-lookup/operators");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "Accept", accept },
                { "Authorization", authorization },
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