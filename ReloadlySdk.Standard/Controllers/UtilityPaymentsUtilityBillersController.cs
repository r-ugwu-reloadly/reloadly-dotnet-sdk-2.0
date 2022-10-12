// <copyright file="UtilityPaymentsUtilityBillersController.cs" company="APIMatic">
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
    /// UtilityPaymentsUtilityBillersController.
    /// </summary>
    public class UtilityPaymentsUtilityBillersController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UtilityPaymentsUtilityBillersController"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        internal UtilityPaymentsUtilityBillersController(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers)
            : base(config, httpClient, authManagers)
        {
        }

        /// <summary>
        /// reloadly-utility-payments-billers EndPoint.
        /// </summary>
        /// <param name="accept">Required parameter: Example: .</param>
        /// <param name="authorization">Required parameter: Example: .</param>
        /// <param name="id">Optional parameter: This is the unique identification number of each biller. It uniquely identifies the biller servicing the utility..</param>
        /// <param name="name">Optional parameter: This indicates the biller's name. In situations where the biller's name is exceptionally long, partial names are used..</param>
        /// <param name="type">Optional parameter: This indicates the type of utility payment handled by the biller. Values included are ELECTRICITY_BILL_PAYMENT, WATER_BILL_PAYMENT, TV_BILL_PAYMENT and INTERNET_BILL_PAYMENT..</param>
        /// <param name="serviceType">Optional parameter: This indicates the payment service type being rendered by the utility biller service. Examples are PREPAID and POSTPAID..</param>
        /// <param name="countryISOCode">Optional parameter: This indicates the ISO code of the country where the utility biller is operating in..</param>
        /// <param name="page">Optional parameter: This indicates the page of the billers list being retrieved. Default value is 1..</param>
        /// <param name="size">Optional parameter: This indicates the number of billers to be retrieved on a page. Default value is 200..</param>
        /// <returns>Returns the dynamic response from the API call.</returns>
        public dynamic ReloadlyUtilityPaymentsBillers(
                string accept,
                string authorization,
                int? id = null,
                string name = null,
                string type = null,
                string serviceType = null,
                string countryISOCode = null,
                int? page = null,
                int? size = null)
        {
            Task<dynamic> t = this.ReloadlyUtilityPaymentsBillersAsync(accept, authorization, id, name, type, serviceType, countryISOCode, page, size);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// reloadly-utility-payments-billers EndPoint.
        /// </summary>
        /// <param name="accept">Required parameter: Example: .</param>
        /// <param name="authorization">Required parameter: Example: .</param>
        /// <param name="id">Optional parameter: This is the unique identification number of each biller. It uniquely identifies the biller servicing the utility..</param>
        /// <param name="name">Optional parameter: This indicates the biller's name. In situations where the biller's name is exceptionally long, partial names are used..</param>
        /// <param name="type">Optional parameter: This indicates the type of utility payment handled by the biller. Values included are ELECTRICITY_BILL_PAYMENT, WATER_BILL_PAYMENT, TV_BILL_PAYMENT and INTERNET_BILL_PAYMENT..</param>
        /// <param name="serviceType">Optional parameter: This indicates the payment service type being rendered by the utility biller service. Examples are PREPAID and POSTPAID..</param>
        /// <param name="countryISOCode">Optional parameter: This indicates the ISO code of the country where the utility biller is operating in..</param>
        /// <param name="page">Optional parameter: This indicates the page of the billers list being retrieved. Default value is 1..</param>
        /// <param name="size">Optional parameter: This indicates the number of billers to be retrieved on a page. Default value is 200..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the dynamic response from the API call.</returns>
        public async Task<dynamic> ReloadlyUtilityPaymentsBillersAsync(
                string accept,
                string authorization,
                int? id = null,
                string name = null,
                string type = null,
                string serviceType = null,
                string countryISOCode = null,
                int? page = null,
                int? size = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri(Server.UtilityPayments);

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/billers");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "id", id },
                { "name", name },
                { "type", type },
                { "serviceType", serviceType },
                { "countryISOCode", countryISOCode },
                { "page", page },
                { "size", size },
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
    }
}