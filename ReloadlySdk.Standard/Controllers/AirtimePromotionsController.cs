// <copyright file="AirtimePromotionsController.cs" company="APIMatic">
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
    /// AirtimePromotionsController.
    /// </summary>
    public class AirtimePromotionsController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AirtimePromotionsController"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        internal AirtimePromotionsController(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers)
            : base(config, httpClient, authManagers)
        {
        }

        /// <summary>
        /// reloadly-airtime-promotions EndPoint.
        /// </summary>
        /// <param name="accept">Required parameter: Example: .</param>
        /// <param name="authorization">Required parameter: Example: .</param>
        /// <param name="size">Optional parameter: This indicates the number of promotions to be retrieved on a page. Default value is 200..</param>
        /// <param name="page">Optional parameter: This indicates the page of the promotions list being retrieved. Default value is 1..</param>
        /// <param name="languageCode">Optional parameter: This indicates the language you want the promotion information to be displayed in. The language code is to be specified in the ISO 639-1 format. Choices are 'EN', 'ES', 'FR', 'IT', 'PT', 'ZH', 'AR', 'HI', 'HT', 'JA' and 'DE'. Default is 'EN'. This is a case-insensitive field. The promotion information is returned in your requested language irrespective of the original language in which the promotion was launched..</param>
        /// <returns>Returns the dynamic response from the API call.</returns>
        public dynamic ReloadlyAirtimePromotions(
                string accept,
                string authorization,
                int? size = null,
                int? page = null,
                int? languageCode = null)
        {
            Task<dynamic> t = this.ReloadlyAirtimePromotionsAsync(accept, authorization, size, page, languageCode);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// reloadly-airtime-promotions EndPoint.
        /// </summary>
        /// <param name="accept">Required parameter: Example: .</param>
        /// <param name="authorization">Required parameter: Example: .</param>
        /// <param name="size">Optional parameter: This indicates the number of promotions to be retrieved on a page. Default value is 200..</param>
        /// <param name="page">Optional parameter: This indicates the page of the promotions list being retrieved. Default value is 1..</param>
        /// <param name="languageCode">Optional parameter: This indicates the language you want the promotion information to be displayed in. The language code is to be specified in the ISO 639-1 format. Choices are 'EN', 'ES', 'FR', 'IT', 'PT', 'ZH', 'AR', 'HI', 'HT', 'JA' and 'DE'. Default is 'EN'. This is a case-insensitive field. The promotion information is returned in your requested language irrespective of the original language in which the promotion was launched..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the dynamic response from the API call.</returns>
        public async Task<dynamic> ReloadlyAirtimePromotionsAsync(
                string accept,
                string authorization,
                int? size = null,
                int? page = null,
                int? languageCode = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri(Server.Airtime);

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/promotions");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "size", size },
                { "page", page },
                { "languageCode", languageCode },
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
        /// reloadly-airtime-promotion-by-id EndPoint.
        /// </summary>
        /// <param name="accept">Required parameter: Example: .</param>
        /// <param name="authorization">Required parameter: Example: .</param>
        /// <param name="promotionid">Required parameter: The promotion's identification number..</param>
        /// <param name="languageCode">Optional parameter: This indicates the language you want the promotion information to be displayed in. The language code is to be specified in the ISO 639-1 format. Choices are 'EN', 'ES', 'FR', 'IT', 'PT', 'ZH', 'AR', 'HI', 'HT', 'JA' and 'DE'. Default is 'EN'. This is a case-insensitive field. The promotion information is returned in your requested language irrespective of the original language in which the promotion was launched..</param>
        /// <returns>Returns the dynamic response from the API call.</returns>
        public dynamic ReloadlyAirtimePromotionById(
                string accept,
                string authorization,
                string promotionid,
                string languageCode = null)
        {
            Task<dynamic> t = this.ReloadlyAirtimePromotionByIdAsync(accept, authorization, promotionid, languageCode);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// reloadly-airtime-promotion-by-id EndPoint.
        /// </summary>
        /// <param name="accept">Required parameter: Example: .</param>
        /// <param name="authorization">Required parameter: Example: .</param>
        /// <param name="promotionid">Required parameter: The promotion's identification number..</param>
        /// <param name="languageCode">Optional parameter: This indicates the language you want the promotion information to be displayed in. The language code is to be specified in the ISO 639-1 format. Choices are 'EN', 'ES', 'FR', 'IT', 'PT', 'ZH', 'AR', 'HI', 'HT', 'JA' and 'DE'. Default is 'EN'. This is a case-insensitive field. The promotion information is returned in your requested language irrespective of the original language in which the promotion was launched..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the dynamic response from the API call.</returns>
        public async Task<dynamic> ReloadlyAirtimePromotionByIdAsync(
                string accept,
                string authorization,
                string promotionid,
                string languageCode = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri(Server.Airtime);

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/promotions/{promotionid}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "promotionid", promotionid },
            });

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "languageCode", languageCode },
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
                throw new ApiException("Promotion not found", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<dynamic>(response.Body);
        }

        /// <summary>
        /// reloadly-airtime-promotion-by-iso EndPoint.
        /// </summary>
        /// <param name="accept">Required parameter: Example: .</param>
        /// <param name="authorization">Required parameter: Example: .</param>
        /// <param name="countrycode">Required parameter: Example: .</param>
        /// <returns>Returns the dynamic response from the API call.</returns>
        public dynamic ReloadlyAirtimePromotionByIso(
                string accept,
                string authorization,
                string countrycode)
        {
            Task<dynamic> t = this.ReloadlyAirtimePromotionByIsoAsync(accept, authorization, countrycode);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// reloadly-airtime-promotion-by-iso EndPoint.
        /// </summary>
        /// <param name="accept">Required parameter: Example: .</param>
        /// <param name="authorization">Required parameter: Example: .</param>
        /// <param name="countrycode">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the dynamic response from the API call.</returns>
        public async Task<dynamic> ReloadlyAirtimePromotionByIsoAsync(
                string accept,
                string authorization,
                string countrycode,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri(Server.Airtime);

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/promotions/country-codes/{countrycode}");

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
                throw new ApiException("Not Found", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<dynamic>(response.Body);
        }

        /// <summary>
        /// reloadly-airtime-promotion-by-operator-id EndPoint.
        /// </summary>
        /// <param name="accept">Required parameter: Example: .</param>
        /// <param name="authorization">Required parameter: Example: .</param>
        /// <param name="operatorid">Required parameter: Example: .</param>
        /// <returns>Returns the dynamic response from the API call.</returns>
        public dynamic ReloadlyAirtimePromotionByOperatorId(
                string accept,
                string authorization,
                string operatorid)
        {
            Task<dynamic> t = this.ReloadlyAirtimePromotionByOperatorIdAsync(accept, authorization, operatorid);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// reloadly-airtime-promotion-by-operator-id EndPoint.
        /// </summary>
        /// <param name="accept">Required parameter: Example: .</param>
        /// <param name="authorization">Required parameter: Example: .</param>
        /// <param name="operatorid">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the dynamic response from the API call.</returns>
        public async Task<dynamic> ReloadlyAirtimePromotionByOperatorIdAsync(
                string accept,
                string authorization,
                string operatorid,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri(Server.Airtime);

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/promotions/operators/{operatorid}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "Authorization", authorization },
                { "operatorid", operatorid },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "Accept", accept },
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