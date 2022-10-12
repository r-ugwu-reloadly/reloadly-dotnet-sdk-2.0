# Utility Payments-Utility Billers

```csharp
UtilityPaymentsUtilityBillersController utilityPaymentsUtilityBillersController = client.UtilityPaymentsUtilityBillersController;
```

## Class Name

`UtilityPaymentsUtilityBillersController`


# Reloadly-Utility-Payments-Billers

```csharp
ReloadlyUtilityPaymentsBillersAsync(
    string accept,
    string authorization,
    int? id = null,
    string name = null,
    string type = null,
    string serviceType = null,
    string countryISOCode = null,
    int? page = null,
    int? size = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `accept` | `string` | Header, Required | - |
| `authorization` | `string` | Header, Required | - |
| `id` | `int?` | Query, Optional | This is the unique identification number of each biller. It uniquely identifies the biller servicing the utility. |
| `name` | `string` | Query, Optional | This indicates the biller's name. In situations where the biller's name is exceptionally long, partial names are used. |
| `type` | `string` | Query, Optional | This indicates the type of utility payment handled by the biller. Values included are ELECTRICITY_BILL_PAYMENT, WATER_BILL_PAYMENT, TV_BILL_PAYMENT and INTERNET_BILL_PAYMENT. |
| `serviceType` | `string` | Query, Optional | This indicates the payment service type being rendered by the utility biller service. Examples are PREPAID and POSTPAID. |
| `countryISOCode` | `string` | Query, Optional | This indicates the ISO code of the country where the utility biller is operating in. |
| `page` | `int?` | Query, Optional | This indicates the page of the billers list being retrieved. Default value is 1. |
| `size` | `int?` | Query, Optional | This indicates the number of billers to be retrieved on a page. Default value is 200. |

## Response Type

`Task<dynamic>`

## Example Usage

```csharp
string accept = "application/com.reloadly.utilities-v1+json";
string authorization = "Bearer <YOUR TOKEN HERE>";
int? id = 12;
string name = "Eko Electricity";
string type = "ELECTRICITY_BILL_PAYMENT";
string serviceType = "PREPAID";
string countryISOCode = "KE";
int? page = 1;
int? size = 10;

try
{
    dynamic result = await utilityPaymentsUtilityBillersController.ReloadlyUtilityPaymentsBillersAsync(accept, authorization, id, name, type, serviceType, countryISOCode, page, size);
}
catch (ApiException e){};
```

## Example Response

```
{
  "content": [
    {
      "id": 1,
      "name": "Ikeja Electricity Postpaid",
      "countryIsoCode": "NG",
      "type": "ELECTRICITY_BILL_PAYMENT",
      "serviceType": "POSTPAID",
      "localAmountSupported": true,
      "localTransactionCurrencyCode": "NGN",
      "minLocalTransactionAmount": 1000,
      "maxLocalTransactionAmount": 300000,
      "localTransactionFee": 227.83997,
      "localTransactionFeeCurrencyCode": "NGN",
      "localDiscountPercentage": 0,
      "internatonalAmountSupported": true,
      "internationalTransactionCurrencyCode": "INR",
      "minInternationalTransactionAmount": 194.73483,
      "maxInternationalTransactionAmount": 45567.996,
      "internationalTransactionFee": 227.83997,
      "internationalTransactionFeeCurrencyCode": "INR",
      "internationalDiscountPercentage": 0,
      "fx": [
        {
          "rate": 5.20265
        },
        {
          "curencyCode": "INR"
        }
      ]
    },
    {},
    {}
  ]
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Full authentication is required to access this resource | `ApiException` |
| 404 | Not Found | `ApiException` |

