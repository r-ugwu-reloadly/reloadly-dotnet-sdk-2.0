// <copyright file="ReloadlySdkClient.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace ReloadlySdk.Standard
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;
    using ReloadlySdk.Standard.Authentication;
    using ReloadlySdk.Standard.Controllers;
    using ReloadlySdk.Standard.Http.Client;
    using ReloadlySdk.Standard.Utilities;

    /// <summary>
    /// The gateway for the SDK. This class acts as a factory for Controller and
    /// holds the configuration of the SDK.
    /// </summary>
    public sealed class ReloadlySdkClient : IConfiguration
    {
        // A map of environments and their corresponding servers/baseurls
        private static readonly Dictionary<Environment, Dictionary<Server, string>> EnvironmentsMap =
            new Dictionary<Environment, Dictionary<Server, string>>
        {
            {
                Environment.Production, new Dictionary<Server, string>
                {
                    { Server.Authentication, "https://auth.reloadly.com/oauth" },
                    { Server.GiftCards, "https://giftcards.reloadly.com" },
                    { Server.UtilityPayments, "https://utilities.reloadly.com" },
                    { Server.Airtime, "https://topups.reloadly.com" },
                }
            },
        };

        private readonly IDictionary<string, IAuthManager> authManagers;
        private readonly IHttpClient httpClient;

        private readonly Lazy<AuthenticationController> authentication;
        private readonly Lazy<AirtimeAccountBalanceController> airtimeAccountBalance;
        private readonly Lazy<AirtimeCountriesController> airtimeCountries;
        private readonly Lazy<AirtimeOperatorsController> airtimeOperators;
        private readonly Lazy<AirtimeFXRatesController> airtimeFXRates;
        private readonly Lazy<AirtimeCommissionsController> airtimeCommissions;
        private readonly Lazy<AirtimePromotionsController> airtimePromotions;
        private readonly Lazy<AirtimeTopupsController> airtimeTopups;
        private readonly Lazy<AirtimeTransactionsController> airtimeTransactions;
        private readonly Lazy<GiftCardsAccountBalanceController> giftCardsAccountBalance;
        private readonly Lazy<GiftCardsCountriesController> giftCardsCountries;
        private readonly Lazy<GiftCardsProductsController> giftCardsProducts;
        private readonly Lazy<GiftCardsRedeemInstructionsController> giftCardsRedeemInstructions;
        private readonly Lazy<GiftCardsDiscountsController> giftCardsDiscounts;
        private readonly Lazy<GiftCardsTransactionsController> giftCardsTransactions;
        private readonly Lazy<GiftCardsOrdersController> giftCardsOrders;
        private readonly Lazy<AirtimeNumberLookupController> airtimeNumberLookup;
        private readonly Lazy<UtilityPaymentsAccountBalanceController> utilityPaymentsAccountBalance;
        private readonly Lazy<UtilityPaymentsUtilityBillersController> utilityPaymentsUtilityBillers;
        private readonly Lazy<UtilityPaymentsPayBillController> utilityPaymentsPayBill;
        private readonly Lazy<UtilityPaymentsTransactionsController> utilityPaymentsTransactions;

        private ReloadlySdkClient(
            Environment environment,
            IDictionary<string, IAuthManager> authManagers,
            IHttpClient httpClient,
            IHttpClientConfiguration httpClientConfiguration)
        {
            this.Environment = environment;
            this.httpClient = httpClient;
            this.authManagers = (authManagers == null) ? new Dictionary<string, IAuthManager>() : new Dictionary<string, IAuthManager>(authManagers);
            this.HttpClientConfiguration = httpClientConfiguration;

            this.authentication = new Lazy<AuthenticationController>(
                () => new AuthenticationController(this, this.httpClient, this.authManagers));
            this.airtimeAccountBalance = new Lazy<AirtimeAccountBalanceController>(
                () => new AirtimeAccountBalanceController(this, this.httpClient, this.authManagers));
            this.airtimeCountries = new Lazy<AirtimeCountriesController>(
                () => new AirtimeCountriesController(this, this.httpClient, this.authManagers));
            this.airtimeOperators = new Lazy<AirtimeOperatorsController>(
                () => new AirtimeOperatorsController(this, this.httpClient, this.authManagers));
            this.airtimeFXRates = new Lazy<AirtimeFXRatesController>(
                () => new AirtimeFXRatesController(this, this.httpClient, this.authManagers));
            this.airtimeCommissions = new Lazy<AirtimeCommissionsController>(
                () => new AirtimeCommissionsController(this, this.httpClient, this.authManagers));
            this.airtimePromotions = new Lazy<AirtimePromotionsController>(
                () => new AirtimePromotionsController(this, this.httpClient, this.authManagers));
            this.airtimeTopups = new Lazy<AirtimeTopupsController>(
                () => new AirtimeTopupsController(this, this.httpClient, this.authManagers));
            this.airtimeTransactions = new Lazy<AirtimeTransactionsController>(
                () => new AirtimeTransactionsController(this, this.httpClient, this.authManagers));
            this.giftCardsAccountBalance = new Lazy<GiftCardsAccountBalanceController>(
                () => new GiftCardsAccountBalanceController(this, this.httpClient, this.authManagers));
            this.giftCardsCountries = new Lazy<GiftCardsCountriesController>(
                () => new GiftCardsCountriesController(this, this.httpClient, this.authManagers));
            this.giftCardsProducts = new Lazy<GiftCardsProductsController>(
                () => new GiftCardsProductsController(this, this.httpClient, this.authManagers));
            this.giftCardsRedeemInstructions = new Lazy<GiftCardsRedeemInstructionsController>(
                () => new GiftCardsRedeemInstructionsController(this, this.httpClient, this.authManagers));
            this.giftCardsDiscounts = new Lazy<GiftCardsDiscountsController>(
                () => new GiftCardsDiscountsController(this, this.httpClient, this.authManagers));
            this.giftCardsTransactions = new Lazy<GiftCardsTransactionsController>(
                () => new GiftCardsTransactionsController(this, this.httpClient, this.authManagers));
            this.giftCardsOrders = new Lazy<GiftCardsOrdersController>(
                () => new GiftCardsOrdersController(this, this.httpClient, this.authManagers));
            this.airtimeNumberLookup = new Lazy<AirtimeNumberLookupController>(
                () => new AirtimeNumberLookupController(this, this.httpClient, this.authManagers));
            this.utilityPaymentsAccountBalance = new Lazy<UtilityPaymentsAccountBalanceController>(
                () => new UtilityPaymentsAccountBalanceController(this, this.httpClient, this.authManagers));
            this.utilityPaymentsUtilityBillers = new Lazy<UtilityPaymentsUtilityBillersController>(
                () => new UtilityPaymentsUtilityBillersController(this, this.httpClient, this.authManagers));
            this.utilityPaymentsPayBill = new Lazy<UtilityPaymentsPayBillController>(
                () => new UtilityPaymentsPayBillController(this, this.httpClient, this.authManagers));
            this.utilityPaymentsTransactions = new Lazy<UtilityPaymentsTransactionsController>(
                () => new UtilityPaymentsTransactionsController(this, this.httpClient, this.authManagers));
        }

        /// <summary>
        /// Gets AuthenticationController controller.
        /// </summary>
        public AuthenticationController AuthenticationController => this.authentication.Value;

        /// <summary>
        /// Gets AirtimeAccountBalanceController controller.
        /// </summary>
        public AirtimeAccountBalanceController AirtimeAccountBalanceController => this.airtimeAccountBalance.Value;

        /// <summary>
        /// Gets AirtimeCountriesController controller.
        /// </summary>
        public AirtimeCountriesController AirtimeCountriesController => this.airtimeCountries.Value;

        /// <summary>
        /// Gets AirtimeOperatorsController controller.
        /// </summary>
        public AirtimeOperatorsController AirtimeOperatorsController => this.airtimeOperators.Value;

        /// <summary>
        /// Gets AirtimeFXRatesController controller.
        /// </summary>
        public AirtimeFXRatesController AirtimeFXRatesController => this.airtimeFXRates.Value;

        /// <summary>
        /// Gets AirtimeCommissionsController controller.
        /// </summary>
        public AirtimeCommissionsController AirtimeCommissionsController => this.airtimeCommissions.Value;

        /// <summary>
        /// Gets AirtimePromotionsController controller.
        /// </summary>
        public AirtimePromotionsController AirtimePromotionsController => this.airtimePromotions.Value;

        /// <summary>
        /// Gets AirtimeTopupsController controller.
        /// </summary>
        public AirtimeTopupsController AirtimeTopupsController => this.airtimeTopups.Value;

        /// <summary>
        /// Gets AirtimeTransactionsController controller.
        /// </summary>
        public AirtimeTransactionsController AirtimeTransactionsController => this.airtimeTransactions.Value;

        /// <summary>
        /// Gets GiftCardsAccountBalanceController controller.
        /// </summary>
        public GiftCardsAccountBalanceController GiftCardsAccountBalanceController => this.giftCardsAccountBalance.Value;

        /// <summary>
        /// Gets GiftCardsCountriesController controller.
        /// </summary>
        public GiftCardsCountriesController GiftCardsCountriesController => this.giftCardsCountries.Value;

        /// <summary>
        /// Gets GiftCardsProductsController controller.
        /// </summary>
        public GiftCardsProductsController GiftCardsProductsController => this.giftCardsProducts.Value;

        /// <summary>
        /// Gets GiftCardsRedeemInstructionsController controller.
        /// </summary>
        public GiftCardsRedeemInstructionsController GiftCardsRedeemInstructionsController => this.giftCardsRedeemInstructions.Value;

        /// <summary>
        /// Gets GiftCardsDiscountsController controller.
        /// </summary>
        public GiftCardsDiscountsController GiftCardsDiscountsController => this.giftCardsDiscounts.Value;

        /// <summary>
        /// Gets GiftCardsTransactionsController controller.
        /// </summary>
        public GiftCardsTransactionsController GiftCardsTransactionsController => this.giftCardsTransactions.Value;

        /// <summary>
        /// Gets GiftCardsOrdersController controller.
        /// </summary>
        public GiftCardsOrdersController GiftCardsOrdersController => this.giftCardsOrders.Value;

        /// <summary>
        /// Gets AirtimeNumberLookupController controller.
        /// </summary>
        public AirtimeNumberLookupController AirtimeNumberLookupController => this.airtimeNumberLookup.Value;

        /// <summary>
        /// Gets UtilityPaymentsAccountBalanceController controller.
        /// </summary>
        public UtilityPaymentsAccountBalanceController UtilityPaymentsAccountBalanceController => this.utilityPaymentsAccountBalance.Value;

        /// <summary>
        /// Gets UtilityPaymentsUtilityBillersController controller.
        /// </summary>
        public UtilityPaymentsUtilityBillersController UtilityPaymentsUtilityBillersController => this.utilityPaymentsUtilityBillers.Value;

        /// <summary>
        /// Gets UtilityPaymentsPayBillController controller.
        /// </summary>
        public UtilityPaymentsPayBillController UtilityPaymentsPayBillController => this.utilityPaymentsPayBill.Value;

        /// <summary>
        /// Gets UtilityPaymentsTransactionsController controller.
        /// </summary>
        public UtilityPaymentsTransactionsController UtilityPaymentsTransactionsController => this.utilityPaymentsTransactions.Value;

        /// <summary>
        /// Gets the configuration of the Http Client associated with this client.
        /// </summary>
        public IHttpClientConfiguration HttpClientConfiguration { get; }

        /// <summary>
        /// Gets Environment.
        /// Current API environment.
        /// </summary>
        public Environment Environment { get; }

        /// <summary>
        /// Gets auth managers.
        /// </summary>
        internal IDictionary<string, IAuthManager> AuthManagers => this.authManagers;

        /// <summary>
        /// Gets http client.
        /// </summary>
        internal IHttpClient HttpClient => this.httpClient;

        /// <summary>
        /// Gets the URL for a particular alias in the current environment and appends
        /// it with template parameters.
        /// </summary>
        /// <param name="alias">Default value:AUTHENTICATION.</param>
        /// <returns>Returns the baseurl.</returns>
        public string GetBaseUri(Server alias = Server.Authentication)
        {
            StringBuilder url = new StringBuilder(EnvironmentsMap[this.Environment][alias]);
            ApiHelper.AppendUrlWithTemplateParameters(url, this.GetBaseUriParameters());

            return url.ToString();
        }

        /// <summary>
        /// Creates an object of the ReloadlySdkClient using the values provided for the builder.
        /// </summary>
        /// <returns>Builder.</returns>
        public Builder ToBuilder()
        {
            Builder builder = new Builder()
                .Environment(this.Environment)
                .HttpClient(this.httpClient)
                .AuthManagers(this.authManagers)
                .HttpClientConfig(config => config.Build());

            return builder;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return
                $"Environment = {this.Environment}, " +
                $"HttpClientConfiguration = {this.HttpClientConfiguration}, ";
        }

        /// <summary>
        /// Creates the client using builder.
        /// </summary>
        /// <returns> ReloadlySdkClient.</returns>
        internal static ReloadlySdkClient CreateFromEnvironment()
        {
            var builder = new Builder();

            string environment = System.Environment.GetEnvironmentVariable("RELOADLY_SDK_STANDARD_ENVIRONMENT");

            if (environment != null)
            {
                builder.Environment(ApiHelper.JsonDeserialize<Environment>($"\"{environment}\""));
            }

            return builder.Build();
        }

        /// <summary>
        /// Makes a list of the BaseURL parameters.
        /// </summary>
        /// <returns>Returns the parameters list.</returns>
        private List<KeyValuePair<string, object>> GetBaseUriParameters()
        {
            List<KeyValuePair<string, object>> kvpList = new List<KeyValuePair<string, object>>()
            {
            };
            return kvpList;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Environment environment = ReloadlySdk.Standard.Environment.Production;
            private IDictionary<string, IAuthManager> authManagers = new Dictionary<string, IAuthManager>();
            private HttpClientConfiguration.Builder httpClientConfig = new HttpClientConfiguration.Builder();
            private IHttpClient httpClient;

            /// <summary>
            /// Sets Environment.
            /// </summary>
            /// <param name="environment"> Environment. </param>
            /// <returns> Builder. </returns>
            public Builder Environment(Environment environment)
            {
                this.environment = environment;
                return this;
            }

            /// <summary>
            /// Sets HttpClientConfig.
            /// </summary>
            /// <param name="action"> Action. </param>
            /// <returns>Builder.</returns>
            public Builder HttpClientConfig(Action<HttpClientConfiguration.Builder> action)
            {
                if (action is null)
                {
                    throw new ArgumentNullException(nameof(action));
                }

                action(this.httpClientConfig);
                return this;
            }

            /// <summary>
            /// Sets the IHttpClient for the Builder.
            /// </summary>
            /// <param name="httpClient"> http client. </param>
            /// <returns>Builder.</returns>
            internal Builder HttpClient(IHttpClient httpClient)
            {
                this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
                return this;
            }

            /// <summary>
            /// Sets the authentication managers for the Builder.
            /// </summary>
            /// <param name="authManagers"> auth managers. </param>
            /// <returns>Builder.</returns>
            internal Builder AuthManagers(IDictionary<string, IAuthManager> authManagers)
            {
                this.authManagers = authManagers ?? throw new ArgumentNullException(nameof(authManagers));
                return this;
            }

            /// <summary>
            /// Creates an object of the ReloadlySdkClient using the values provided for the builder.
            /// </summary>
            /// <returns>ReloadlySdkClient.</returns>
            public ReloadlySdkClient Build()
            {
                this.httpClient = new HttpClientWrapper(this.httpClientConfig.Build());

                return new ReloadlySdkClient(
                    this.environment,
                    this.authManagers,
                    this.httpClient,
                    this.httpClientConfig.Build());
            }
        }
    }
}
