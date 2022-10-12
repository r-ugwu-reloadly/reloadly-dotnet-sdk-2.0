// <copyright file="GiftCardsProductsController.cs" company="APIMatic">
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
    /// GiftCardsProductsController.
    /// </summary>
    public class GiftCardsProductsController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GiftCardsProductsController"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        internal GiftCardsProductsController(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers)
            : base(config, httpClient, authManagers)
        {
        }

        /// <summary>
        /// reloadly-gift-cards-products EndPoint.
        /// </summary>
        /// <param name="accept">Required parameter: Example: .</param>
        /// <param name="authorization">Required parameter: Example: .</param>
        /// <param name="includeRange">Optional parameter: Indicates the list of gift card products with the denominationType property specified as RANGE are to be retrieved..</param>
        /// <param name="includeFixed">Optional parameter: Indicates the list of gift card products with the denominationType property specified as FIXED are to be retrieved..</param>
        /// <param name="size">Optional parameter: This indicates the number of gift card products to be retrieved on a page..</param>
        /// <param name="page">Optional parameter: This indicates the page of the product list being retrieved..</param>
        /// <param name="productName">Optional parameter: Indicates the name of the gift card product..</param>
        /// <param name="countryCode">Optional parameter: Indicates the ISO code of the country whose gift card products are to be retrieved..</param>
        /// <returns>Returns the dynamic response from the API call.</returns>
        public dynamic ReloadlyGiftCardsProducts(
                string accept,
                string authorization,
                bool? includeRange = null,
                bool? includeFixed = null,
                int? size = null,
                string page = null,
                string productName = null,
                string countryCode = null)
        {
            Task<dynamic> t = this.ReloadlyGiftCardsProductsAsync(accept, authorization, includeRange, includeFixed, size, page, productName, countryCode);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// reloadly-gift-cards-products EndPoint.
        /// </summary>
        /// <param name="accept">Required parameter: Example: .</param>
        /// <param name="authorization">Required parameter: Example: .</param>
        /// <param name="includeRange">Optional parameter: Indicates the list of gift card products with the denominationType property specified as RANGE are to be retrieved..</param>
        /// <param name="includeFixed">Optional parameter: Indicates the list of gift card products with the denominationType property specified as FIXED are to be retrieved..</param>
        /// <param name="size">Optional parameter: This indicates the number of gift card products to be retrieved on a page..</param>
        /// <param name="page">Optional parameter: This indicates the page of the product list being retrieved..</param>
        /// <param name="productName">Optional parameter: Indicates the name of the gift card product..</param>
        /// <param name="countryCode">Optional parameter: Indicates the ISO code of the country whose gift card products are to be retrieved..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the dynamic response from the API call.</returns>
        public async Task<dynamic> ReloadlyGiftCardsProductsAsync(
                string accept,
                string authorization,
                bool? includeRange = null,
                bool? includeFixed = null,
                int? size = null,
                string page = null,
                string productName = null,
                string countryCode = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri(Server.GiftCards);

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/products");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "includeRange", includeRange },
                { "includeFixed", includeFixed },
                { "size", size },
                { "page", page },
                { "productName", productName },
                { "countryCode", countryCode },
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
        /// reloadly-gift-cards-product-by-id EndPoint.
        /// </summary>
        /// <param name="accept">Required parameter: Example: .</param>
        /// <param name="authorization">Required parameter: Example: .</param>
        /// <param name="productid">Required parameter: The product's identification number..</param>
        /// <returns>Returns the dynamic response from the API call.</returns>
        public dynamic ReloadlyGiftCardsProductById(
                string accept,
                string authorization,
                int productid)
        {
            Task<dynamic> t = this.ReloadlyGiftCardsProductByIdAsync(accept, authorization, productid);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// reloadly-gift-cards-product-by-id EndPoint.
        /// </summary>
        /// <param name="accept">Required parameter: Example: .</param>
        /// <param name="authorization">Required parameter: Example: .</param>
        /// <param name="productid">Required parameter: The product's identification number..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the dynamic response from the API call.</returns>
        public async Task<dynamic> ReloadlyGiftCardsProductByIdAsync(
                string accept,
                string authorization,
                int productid,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri(Server.GiftCards);

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/products/{productid}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "productid", productid },
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

            if (response.StatusCode == 400)
            {
                throw new ApiException("The product was either not found or is no longer available, Please contact support", context);
            }

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

        /// <summary>
        /// reloadly-gift-cards-product-by-iso EndPoint.
        /// </summary>
        /// <param name="accept">Required parameter: Example: .</param>
        /// <param name="authorization">Required parameter: Example: .</param>
        /// <param name="countrycode">Required parameter: The ISO code of the country you want to display available gift cards for..</param>
        /// <returns>Returns the dynamic response from the API call.</returns>
        public dynamic ReloadlyGiftCardsProductByIso(
                string accept,
                string authorization,
                string countrycode)
        {
            Task<dynamic> t = this.ReloadlyGiftCardsProductByIsoAsync(accept, authorization, countrycode);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// reloadly-gift-cards-product-by-iso EndPoint.
        /// </summary>
        /// <param name="accept">Required parameter: Example: .</param>
        /// <param name="authorization">Required parameter: Example: .</param>
        /// <param name="countrycode">Required parameter: The ISO code of the country you want to display available gift cards for..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the dynamic response from the API call.</returns>
        public async Task<dynamic> ReloadlyGiftCardsProductByIsoAsync(
                string accept,
                string authorization,
                string countrycode,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri(Server.GiftCards);

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/countries/{countrycode}/products");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "countrycode", countrycode },
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
                throw new ApiException("Country not found and/or not currently supported", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<dynamic>(response.Body);
        }
    }
}