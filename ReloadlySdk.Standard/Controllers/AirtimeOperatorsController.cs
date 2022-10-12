// <copyright file="AirtimeOperatorsController.cs" company="APIMatic">
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
    /// AirtimeOperatorsController.
    /// </summary>
    public class AirtimeOperatorsController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AirtimeOperatorsController"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        internal AirtimeOperatorsController(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers)
            : base(config, httpClient, authManagers)
        {
        }

        /// <summary>
        /// reloadly-airtime-operators EndPoint.
        /// </summary>
        /// <param name="accept">Required parameter: Example: application/com.reloadly.topups-v1+json.</param>
        /// <param name="authorization">Required parameter: Example: .</param>
        /// <param name="includeBundles">Optional parameter: Indicates if any airtime and data bundles being offered by the operator should be included in the API response. Default value is true..</param>
        /// <param name="includeData">Optional parameter: Indicates if any airtime or data plans being offered by the operator should be included in the API response. Default value is true..</param>
        /// <param name="suggestedAmountsMap">Optional parameter: Indicates if this field should be returned as a response. Default value is false..</param>
        /// <param name="size">Optional parameter: This indicates the number of operators to be retrieved on a page. Default value is 200..</param>
        /// <param name="page">Optional parameter: This indicates the page of the operator list being retrieved. Default value is 1..</param>
        /// <returns>Returns the dynamic response from the API call.</returns>
        public dynamic ReloadlyAirtimeOperators(
                string accept,
                string authorization,
                string includeBundles = null,
                string includeData = null,
                string suggestedAmountsMap = null,
                string size = null,
                string page = null)
        {
            Task<dynamic> t = this.ReloadlyAirtimeOperatorsAsync(accept, authorization, includeBundles, includeData, suggestedAmountsMap, size, page);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// reloadly-airtime-operators EndPoint.
        /// </summary>
        /// <param name="accept">Required parameter: Example: application/com.reloadly.topups-v1+json.</param>
        /// <param name="authorization">Required parameter: Example: .</param>
        /// <param name="includeBundles">Optional parameter: Indicates if any airtime and data bundles being offered by the operator should be included in the API response. Default value is true..</param>
        /// <param name="includeData">Optional parameter: Indicates if any airtime or data plans being offered by the operator should be included in the API response. Default value is true..</param>
        /// <param name="suggestedAmountsMap">Optional parameter: Indicates if this field should be returned as a response. Default value is false..</param>
        /// <param name="size">Optional parameter: This indicates the number of operators to be retrieved on a page. Default value is 200..</param>
        /// <param name="page">Optional parameter: This indicates the page of the operator list being retrieved. Default value is 1..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the dynamic response from the API call.</returns>
        public async Task<dynamic> ReloadlyAirtimeOperatorsAsync(
                string accept,
                string authorization,
                string includeBundles = null,
                string includeData = null,
                string suggestedAmountsMap = null,
                string size = null,
                string page = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri(Server.Airtime);

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/operators");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "includeBundles", includeBundles },
                { "includeData", includeData },
                { "suggestedAmountsMap", suggestedAmountsMap },
                { "size", size },
                { "page", page },
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
        /// reloadly-airtime-operator-autodetect EndPoint.
        /// </summary>
        /// <param name="accept">Required parameter: Example: application/com.reloadly.topups-v1+json.</param>
        /// <param name="authorization">Required parameter: Example: .</param>
        /// <param name="phone">Required parameter: The mobile number whose details are to be retrieved..</param>
        /// <param name="countryisocode">Required parameter: The ISO code of the country where the mobile number is registered..</param>
        /// <param name="countrycode">Required parameter: Example: .</param>
        /// <param name="suggestedAmounts">Optional parameter: Indicates if this field should be returned as a response. Default value is false..</param>
        /// <param name="suggestedAmountsMap">Optional parameter: Indicates if this field should be returned as a response. Default value is false..</param>
        /// <returns>Returns the dynamic response from the API call.</returns>
        public dynamic ReloadlyAirtimeOperatorAutodetect(
                string accept,
                string authorization,
                string phone,
                string countryisocode,
                string countrycode,
                bool? suggestedAmounts = null,
                bool? suggestedAmountsMap = null)
        {
            Task<dynamic> t = this.ReloadlyAirtimeOperatorAutodetectAsync(accept, authorization, phone, countryisocode, countrycode, suggestedAmounts, suggestedAmountsMap);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// reloadly-airtime-operator-autodetect EndPoint.
        /// </summary>
        /// <param name="accept">Required parameter: Example: application/com.reloadly.topups-v1+json.</param>
        /// <param name="authorization">Required parameter: Example: .</param>
        /// <param name="phone">Required parameter: The mobile number whose details are to be retrieved..</param>
        /// <param name="countryisocode">Required parameter: The ISO code of the country where the mobile number is registered..</param>
        /// <param name="countrycode">Required parameter: Example: .</param>
        /// <param name="suggestedAmounts">Optional parameter: Indicates if this field should be returned as a response. Default value is false..</param>
        /// <param name="suggestedAmountsMap">Optional parameter: Indicates if this field should be returned as a response. Default value is false..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the dynamic response from the API call.</returns>
        public async Task<dynamic> ReloadlyAirtimeOperatorAutodetectAsync(
                string accept,
                string authorization,
                string phone,
                string countryisocode,
                string countrycode,
                bool? suggestedAmounts = null,
                bool? suggestedAmountsMap = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri(Server.Airtime);

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/operators/auto-detect/phone/{phone}/countries/{countrycode}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "phone", phone },
                { "countryisocode", countryisocode },
                { "countrycode", countrycode },
            });

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "suggestedAmounts", suggestedAmounts },
                { "suggestedAmountsMap", suggestedAmountsMap },
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
                throw new ApiException("Country code must be 2 characters ISO-Alpha-2 country code. See https://www.iban.com/country-codes", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<dynamic>(response.Body);
        }

        /// <summary>
        /// reloadly-airtime-operator-by-id EndPoint.
        /// </summary>
        /// <param name="accept">Required parameter: Example: application/com.reloadly.topups-v1+json.</param>
        /// <param name="authorization">Required parameter: Example: .</param>
        /// <param name="operatorid">Required parameter: The operator's identification number..</param>
        /// <returns>Returns the dynamic response from the API call.</returns>
        public dynamic ReloadlyAirtimeOperatorById(
                string accept,
                string authorization,
                string operatorid)
        {
            Task<dynamic> t = this.ReloadlyAirtimeOperatorByIdAsync(accept, authorization, operatorid);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// reloadly-airtime-operator-by-id EndPoint.
        /// </summary>
        /// <param name="accept">Required parameter: Example: application/com.reloadly.topups-v1+json.</param>
        /// <param name="authorization">Required parameter: Example: .</param>
        /// <param name="operatorid">Required parameter: The operator's identification number..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the dynamic response from the API call.</returns>
        public async Task<dynamic> ReloadlyAirtimeOperatorByIdAsync(
                string accept,
                string authorization,
                string operatorid,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri(Server.Airtime);

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/operators/{operatorid}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "operatorid", operatorid },
            });

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
                throw new ApiException("Operator not found for given id", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<dynamic>(response.Body);
        }

        /// <summary>
        /// reloadly-airtime-operator-by-iso EndPoint.
        /// </summary>
        /// <param name="accept">Required parameter: Example: application/com.reloadly.topups-v1+json.</param>
        /// <param name="authorization">Required parameter: Example: .</param>
        /// <param name="countrycode">Required parameter: The ISO code of the country where the operator is registered..</param>
        /// <param name="includeBundles">Required parameter: Indicates if any airtime and data bundles being offered by the operator should be returned as a response. Default value is true..</param>
        /// <param name="suggestedAmountsMap">Optional parameter: Indicates if this field should be returned as a response. Default value is false..</param>
        /// <param name="suggestedAmounts">Optional parameter: Indicates if this field should be returned as a response. Default value is false..</param>
        /// <param name="includePin">Optional parameter: Indicates if PIN details if applicable to the operator, should be returned as a response. Default value is true..</param>
        /// <param name="includeData">Optional parameter: Indicates if any data plans being offered by the operator should be returned as a response. Default value is true..</param>
        /// <returns>Returns the dynamic response from the API call.</returns>
        public dynamic ReloadlyAirtimeOperatorByIso(
                string accept,
                string authorization,
                string countrycode,
                bool includeBundles,
                bool? suggestedAmountsMap = null,
                string suggestedAmounts = null,
                bool? includePin = null,
                bool? includeData = null)
        {
            Task<dynamic> t = this.ReloadlyAirtimeOperatorByIsoAsync(accept, authorization, countrycode, includeBundles, suggestedAmountsMap, suggestedAmounts, includePin, includeData);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// reloadly-airtime-operator-by-iso EndPoint.
        /// </summary>
        /// <param name="accept">Required parameter: Example: application/com.reloadly.topups-v1+json.</param>
        /// <param name="authorization">Required parameter: Example: .</param>
        /// <param name="countrycode">Required parameter: The ISO code of the country where the operator is registered..</param>
        /// <param name="includeBundles">Required parameter: Indicates if any airtime and data bundles being offered by the operator should be returned as a response. Default value is true..</param>
        /// <param name="suggestedAmountsMap">Optional parameter: Indicates if this field should be returned as a response. Default value is false..</param>
        /// <param name="suggestedAmounts">Optional parameter: Indicates if this field should be returned as a response. Default value is false..</param>
        /// <param name="includePin">Optional parameter: Indicates if PIN details if applicable to the operator, should be returned as a response. Default value is true..</param>
        /// <param name="includeData">Optional parameter: Indicates if any data plans being offered by the operator should be returned as a response. Default value is true..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the dynamic response from the API call.</returns>
        public async Task<dynamic> ReloadlyAirtimeOperatorByIsoAsync(
                string accept,
                string authorization,
                string countrycode,
                bool includeBundles,
                bool? suggestedAmountsMap = null,
                string suggestedAmounts = null,
                bool? includePin = null,
                bool? includeData = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri(Server.Airtime);

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/operators/countries/{countrycode}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "countrycode", countrycode },
            });

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "Authorization", authorization },
                { "includeBundles", includeBundles },
                { "suggestedAmountsMap", suggestedAmountsMap },
                { "suggestedAmounts", suggestedAmounts },
                { "includePin", includePin },
                { "includeData", includeData },
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "Accept", accept },
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
                throw new ApiException("Country not found and/or not currently supported", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<dynamic>(response.Body);
        }
    }
}