
# Client Class Documentation

The following parameters are configurable for the API Client:

| Parameter | Type | Description |
|  --- | --- | --- |
| `Environment` | Environment | The API environment. <br> **Default: `Environment.Production`** |
| `Timeout` | `TimeSpan` | Http client timeout.<br>*Default*: `TimeSpan.FromSeconds(100)` |

The API client can be initialized as follows:

```csharp
ReloadlySdk.Standard.ReloadlySdkClient client = new ReloadlySdk.Standard.ReloadlySdkClient.Builder()
    .Environment(ReloadlySdk.Standard.Environment.Production)
    .HttpClientConfig(config => config.NumberOfRetries(0))
    .Build();
```

## reloadly-sdkClient Class

The gateway for the SDK. This class acts as a factory for the Controllers and also holds the configuration of the SDK.

### Controllers

| Name | Description |
|  --- | --- |
| AuthenticationController | Gets AuthenticationController controller. |
| AirtimeAccountBalanceController | Gets AirtimeAccountBalanceController controller. |
| AirtimeCountriesController | Gets AirtimeCountriesController controller. |
| AirtimeOperatorsController | Gets AirtimeOperatorsController controller. |
| AirtimeFXRatesController | Gets AirtimeFXRatesController controller. |
| AirtimeCommissionsController | Gets AirtimeCommissionsController controller. |
| AirtimePromotionsController | Gets AirtimePromotionsController controller. |
| AirtimeTopupsController | Gets AirtimeTopupsController controller. |
| AirtimeTransactionsController | Gets AirtimeTransactionsController controller. |
| GiftCardsAccountBalanceController | Gets GiftCardsAccountBalanceController controller. |
| GiftCardsCountriesController | Gets GiftCardsCountriesController controller. |
| GiftCardsProductsController | Gets GiftCardsProductsController controller. |
| GiftCardsRedeemInstructionsController | Gets GiftCardsRedeemInstructionsController controller. |
| GiftCardsDiscountsController | Gets GiftCardsDiscountsController controller. |
| GiftCardsTransactionsController | Gets GiftCardsTransactionsController controller. |
| GiftCardsOrdersController | Gets GiftCardsOrdersController controller. |
| AirtimeNumberLookupController | Gets AirtimeNumberLookupController controller. |
| UtilityPaymentsAccountBalanceController | Gets UtilityPaymentsAccountBalanceController controller. |
| UtilityPaymentsUtilityBillersController | Gets UtilityPaymentsUtilityBillersController controller. |
| UtilityPaymentsPayBillController | Gets UtilityPaymentsPayBillController controller. |
| UtilityPaymentsTransactionsController | Gets UtilityPaymentsTransactionsController controller. |

### Properties

| Name | Description | Type |
|  --- | --- | --- |
| HttpClientConfiguration | Gets the configuration of the Http Client associated with this client. | `IHttpClientConfiguration` |
| Timeout | Http client timeout. | `TimeSpan` |
| Environment | Current API environment. | `Environment` |

### Methods

| Name | Description | Return Type |
|  --- | --- | --- |
| `GetBaseUri(Server alias = Server.Authentication)` | Gets the URL for a particular alias in the current environment and appends it with template parameters. | `string` |
| `ToBuilder()` | Creates an object of the reloadly-sdkClient using the values provided for the builder. | `Builder` |

## reloadly-sdkClient Builder Class

Class to build instances of reloadly-sdkClient.

### Methods

| Name | Description | Return Type |
|  --- | --- | --- |
| `HttpClientConfiguration(Action<HttpClientConfiguration.Builder> action)` | Gets the configuration of the Http Client associated with this client. | `Builder` |
| `Timeout(TimeSpan timeout)` | Http client timeout. | `Builder` |
| `Environment(Environment environment)` | Current API environment. | `Builder` |

