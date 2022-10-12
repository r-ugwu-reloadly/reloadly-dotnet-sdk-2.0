// <copyright file="AirtimeTransactionsController.cs" company="APIMatic">
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
    /// AirtimeTransactionsController.
    /// </summary>
    public class AirtimeTransactionsController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AirtimeTransactionsController"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        internal AirtimeTransactionsController(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers)
            : base(config, httpClient, authManagers)
        {
        }

        /// <summary>
        /// reloadly-airtime-transactions EndPoint.
        /// </summary>
        /// <param name="accept">Required parameter: Example: .</param>
        /// <param name="authorization">Required parameter: Example: .</param>
        /// <param name="size">Optional parameter: This indicates the number of transactions to be retrieved on a page. Default value is 200..</param>
        /// <param name="page">Optional parameter: This indicates the page of the transactions list being retrieved. Default value is 1..</param>
        /// <param name="countrycode">Optional parameter: Indicates the ISO code of the country assigned to the top-up's receiver at the time the top-up transaction was made..</param>
        /// <param name="operatorid">Optional parameter: Indicates the operator identification number assigned to the top-up transaction at the time it was made..</param>
        /// <param name="operatorName">Optional parameter: Indicates the operator name assigned to the top-up transaction at the time it was made..</param>
        /// <param name="customIdentifier">Optional parameter: Indicates the unique reference assigned to the top-up transaction at the time it was made..</param>
        /// <param name="startDate">Optional parameter: Indicates the beginning of the timeframe range for the transactions to be retrieved..</param>
        /// <param name="endDate">Optional parameter: String  Indicates the end of the timeframe range for the transactions to be retrieved..</param>
        /// <returns>Returns the dynamic response from the API call.</returns>
        public dynamic ReloadlyAirtimeTransactions(
                string accept,
                string authorization,
                int? size = null,
                int? page = null,
                int? countrycode = null,
                string operatorid = null,
                string operatorName = null,
                string customIdentifier = null,
                string startDate = null,
                string endDate = null)
        {
            Task<dynamic> t = this.ReloadlyAirtimeTransactionsAsync(accept, authorization, size, page, countrycode, operatorid, operatorName, customIdentifier, startDate, endDate);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// reloadly-airtime-transactions EndPoint.
        /// </summary>
        /// <param name="accept">Required parameter: Example: .</param>
        /// <param name="authorization">Required parameter: Example: .</param>
        /// <param name="size">Optional parameter: This indicates the number of transactions to be retrieved on a page. Default value is 200..</param>
        /// <param name="page">Optional parameter: This indicates the page of the transactions list being retrieved. Default value is 1..</param>
        /// <param name="countrycode">Optional parameter: Indicates the ISO code of the country assigned to the top-up's receiver at the time the top-up transaction was made..</param>
        /// <param name="operatorid">Optional parameter: Indicates the operator identification number assigned to the top-up transaction at the time it was made..</param>
        /// <param name="operatorName">Optional parameter: Indicates the operator name assigned to the top-up transaction at the time it was made..</param>
        /// <param name="customIdentifier">Optional parameter: Indicates the unique reference assigned to the top-up transaction at the time it was made..</param>
        /// <param name="startDate">Optional parameter: Indicates the beginning of the timeframe range for the transactions to be retrieved..</param>
        /// <param name="endDate">Optional parameter: String  Indicates the end of the timeframe range for the transactions to be retrieved..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the dynamic response from the API call.</returns>
        public async Task<dynamic> ReloadlyAirtimeTransactionsAsync(
                string accept,
                string authorization,
                int? size = null,
                int? page = null,
                int? countrycode = null,
                string operatorid = null,
                string operatorName = null,
                string customIdentifier = null,
                string startDate = null,
                string endDate = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri(Server.Airtime);

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/topups/reports/transactions");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "size", size },
                { "page", page },
                { "countrycode", countrycode },
                { "operatorid", operatorid },
                { "operatorName", operatorName },
                { "customIdentifier", customIdentifier },
                { "startDate", startDate },
                { "endDate", endDate },
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
        /// reloadly-airtime-transaction-by-id EndPoint.
        /// </summary>
        /// <param name="accept">Required parameter: Example: .</param>
        /// <param name="authorization">Required parameter: Example: .</param>
        /// <param name="transactionid">Required parameter: This indicates the identification number of the transaction to be retrieved..</param>
        /// <returns>Returns the dynamic response from the API call.</returns>
        public dynamic ReloadlyAirtimeTransactionById(
                string accept,
                string authorization,
                int transactionid)
        {
            Task<dynamic> t = this.ReloadlyAirtimeTransactionByIdAsync(accept, authorization, transactionid);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// reloadly-airtime-transaction-by-id EndPoint.
        /// </summary>
        /// <param name="accept">Required parameter: Example: .</param>
        /// <param name="authorization">Required parameter: Example: .</param>
        /// <param name="transactionid">Required parameter: This indicates the identification number of the transaction to be retrieved..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the dynamic response from the API call.</returns>
        public async Task<dynamic> ReloadlyAirtimeTransactionByIdAsync(
                string accept,
                string authorization,
                int transactionid,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri(Server.Airtime);

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/topups/reports/transactions/{transactionid}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "transactionid", transactionid },
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
                throw new ApiException("Airtime transaction not found", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<dynamic>(response.Body);
        }
    }
}