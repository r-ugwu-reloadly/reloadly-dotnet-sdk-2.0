// <copyright file="GiftCardsTransactionsController.cs" company="APIMatic">
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
    /// GiftCardsTransactionsController.
    /// </summary>
    public class GiftCardsTransactionsController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GiftCardsTransactionsController"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        internal GiftCardsTransactionsController(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers)
            : base(config, httpClient, authManagers)
        {
        }

        /// <summary>
        /// reloadly-gift-cards-transactions EndPoint.
        /// </summary>
        /// <param name="accept">Required parameter: Example: .</param>
        /// <param name="authorization">Required parameter: Example: .</param>
        /// <param name="size">Optional parameter: This indicates the number of transactions to be retrieved on a page..</param>
        /// <param name="page">Optional parameter: This indicates the page of the transactions list being retrieved..</param>
        /// <param name="startDate">Optional parameter: Indicates the start date for the range of transactions to be retrieved..</param>
        /// <param name="endDate">Optional parameter: Indicates the end date for the range of transactions to be retrieved..</param>
        /// <returns>Returns the dynamic response from the API call.</returns>
        public dynamic ReloadlyGiftCardsTransactions(
                string accept,
                string authorization,
                string size = null,
                string page = null,
                string startDate = null,
                string endDate = null)
        {
            Task<dynamic> t = this.ReloadlyGiftCardsTransactionsAsync(accept, authorization, size, page, startDate, endDate);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// reloadly-gift-cards-transactions EndPoint.
        /// </summary>
        /// <param name="accept">Required parameter: Example: .</param>
        /// <param name="authorization">Required parameter: Example: .</param>
        /// <param name="size">Optional parameter: This indicates the number of transactions to be retrieved on a page..</param>
        /// <param name="page">Optional parameter: This indicates the page of the transactions list being retrieved..</param>
        /// <param name="startDate">Optional parameter: Indicates the start date for the range of transactions to be retrieved..</param>
        /// <param name="endDate">Optional parameter: Indicates the end date for the range of transactions to be retrieved..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the dynamic response from the API call.</returns>
        public async Task<dynamic> ReloadlyGiftCardsTransactionsAsync(
                string accept,
                string authorization,
                string size = null,
                string page = null,
                string startDate = null,
                string endDate = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri(Server.GiftCards);

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/reports/transactions");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "size", size },
                { "page", page },
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
                throw new ApiException("Could not retrieve/update resources at the moment, please try again later", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<dynamic>(response.Body);
        }

        /// <summary>
        /// reloadly-gift-cards-transaction-by-id EndPoint.
        /// </summary>
        /// <param name="accept">Required parameter: Example: .</param>
        /// <param name="authorization">Required parameter: Example: .</param>
        /// <param name="transactionid">Required parameter: Indicates the identification number of the transaction to be retrieved..</param>
        /// <returns>Returns the dynamic response from the API call.</returns>
        public dynamic ReloadlyGiftCardsTransactionById(
                string accept,
                string authorization,
                string transactionid)
        {
            Task<dynamic> t = this.ReloadlyGiftCardsTransactionByIdAsync(accept, authorization, transactionid);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// reloadly-gift-cards-transaction-by-id EndPoint.
        /// </summary>
        /// <param name="accept">Required parameter: Example: .</param>
        /// <param name="authorization">Required parameter: Example: .</param>
        /// <param name="transactionid">Required parameter: Indicates the identification number of the transaction to be retrieved..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the dynamic response from the API call.</returns>
        public async Task<dynamic> ReloadlyGiftCardsTransactionByIdAsync(
                string accept,
                string authorization,
                string transactionid,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri(Server.GiftCards);

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/reports/transactions/{transactionid}");

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
                throw new ApiException("Indicates the identification number of the transaction to be retrieved.", context);
            }

            if (response.StatusCode == 404)
            {
                throw new ApiException("Could not retrieve/update resources at the moment, please try again later", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<dynamic>(response.Body);
        }
    }
}