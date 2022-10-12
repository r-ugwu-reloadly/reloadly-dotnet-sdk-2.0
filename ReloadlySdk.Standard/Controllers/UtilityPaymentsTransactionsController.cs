// <copyright file="UtilityPaymentsTransactionsController.cs" company="APIMatic">
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
    /// UtilityPaymentsTransactionsController.
    /// </summary>
    public class UtilityPaymentsTransactionsController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UtilityPaymentsTransactionsController"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        internal UtilityPaymentsTransactionsController(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers)
            : base(config, httpClient, authManagers)
        {
        }

        /// <summary>
        /// reloadly-utility-payments-transactions EndPoint.
        /// </summary>
        /// <param name="accept">Required parameter: Example: .</param>
        /// <param name="authorization">Required parameter: Example: .</param>
        /// <param name="referenceId">Optional parameter: The reference ID you may have specified while placing the transaction..</param>
        /// <param name="page">Optional parameter: The page to be retrieved from the transaction list..</param>
        /// <param name="size">Optional parameter: Number of items to include in a single page..</param>
        /// <param name="startDate">Optional parameter: Indicates the start date for the range of transactions to be retrieved..</param>
        /// <param name="endDate">Optional parameter: Indicates the end date for the range of transactions to be retrieved..</param>
        /// <param name="status">Optional parameter: The transaction's status. Can be either PROCESSING, SUCCESSFUL, FAILED, or REFUNDED..</param>
        /// <param name="serviceType">Optional parameter: The biller's service type. Can be either PREPAID or POSTPAID..</param>
        /// <param name="billerType">Optional parameter: The biller's type. Can be either ELECTRICITY_BILL_PAYMENT, WATER_BILL_PAYMENT, TV_BILL_PAYMENT, or INTERNET_BILL_PAYMENT.</param>
        /// <param name="billerCountryCode">Optional parameter: Indicates the ISO code of the country where the biller is located..</param>
        /// <returns>Returns the dynamic response from the API call.</returns>
        public dynamic ReloadlyUtilityPaymentsTransactions(
                string accept,
                string authorization,
                string referenceId = null,
                int? page = null,
                int? size = null,
                string startDate = null,
                string endDate = null,
                string status = null,
                string serviceType = null,
                string billerType = null,
                string billerCountryCode = null)
        {
            Task<dynamic> t = this.ReloadlyUtilityPaymentsTransactionsAsync(accept, authorization, referenceId, page, size, startDate, endDate, status, serviceType, billerType, billerCountryCode);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// reloadly-utility-payments-transactions EndPoint.
        /// </summary>
        /// <param name="accept">Required parameter: Example: .</param>
        /// <param name="authorization">Required parameter: Example: .</param>
        /// <param name="referenceId">Optional parameter: The reference ID you may have specified while placing the transaction..</param>
        /// <param name="page">Optional parameter: The page to be retrieved from the transaction list..</param>
        /// <param name="size">Optional parameter: Number of items to include in a single page..</param>
        /// <param name="startDate">Optional parameter: Indicates the start date for the range of transactions to be retrieved..</param>
        /// <param name="endDate">Optional parameter: Indicates the end date for the range of transactions to be retrieved..</param>
        /// <param name="status">Optional parameter: The transaction's status. Can be either PROCESSING, SUCCESSFUL, FAILED, or REFUNDED..</param>
        /// <param name="serviceType">Optional parameter: The biller's service type. Can be either PREPAID or POSTPAID..</param>
        /// <param name="billerType">Optional parameter: The biller's type. Can be either ELECTRICITY_BILL_PAYMENT, WATER_BILL_PAYMENT, TV_BILL_PAYMENT, or INTERNET_BILL_PAYMENT.</param>
        /// <param name="billerCountryCode">Optional parameter: Indicates the ISO code of the country where the biller is located..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the dynamic response from the API call.</returns>
        public async Task<dynamic> ReloadlyUtilityPaymentsTransactionsAsync(
                string accept,
                string authorization,
                string referenceId = null,
                int? page = null,
                int? size = null,
                string startDate = null,
                string endDate = null,
                string status = null,
                string serviceType = null,
                string billerType = null,
                string billerCountryCode = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri(Server.UtilityPayments);

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/transactions");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "referenceId", referenceId },
                { "page", page },
                { "size", size },
                { "startDate", startDate },
                { "endDate", endDate },
                { "status", status },
                { "serviceType", serviceType },
                { "billerType", billerType },
                { "billerCountryCode", billerCountryCode },
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
        /// reloadly-utility-payments-transaction-by-id EndPoint.
        /// </summary>
        /// <param name="accept">Required parameter: Example: .</param>
        /// <param name="authorization">Required parameter: Example: .</param>
        /// <param name="id">Required parameter: The utility payment's identification number..</param>
        /// <returns>Returns the dynamic response from the API call.</returns>
        public dynamic ReloadlyUtilityPaymentsTransactionById(
                string accept,
                string authorization,
                int id)
        {
            Task<dynamic> t = this.ReloadlyUtilityPaymentsTransactionByIdAsync(accept, authorization, id);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// reloadly-utility-payments-transaction-by-id EndPoint.
        /// </summary>
        /// <param name="accept">Required parameter: Example: .</param>
        /// <param name="authorization">Required parameter: Example: .</param>
        /// <param name="id">Required parameter: The utility payment's identification number..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the dynamic response from the API call.</returns>
        public async Task<dynamic> ReloadlyUtilityPaymentsTransactionByIdAsync(
                string accept,
                string authorization,
                int id,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri(Server.UtilityPayments);

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/transactions/{id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "id", id },
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
                throw new ApiException("Not found", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<dynamic>(response.Body);
        }
    }
}