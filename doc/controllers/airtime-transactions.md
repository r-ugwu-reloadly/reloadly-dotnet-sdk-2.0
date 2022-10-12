# Airtime-Transactions

```csharp
AirtimeTransactionsController airtimeTransactionsController = client.AirtimeTransactionsController;
```

## Class Name

`AirtimeTransactionsController`

## Methods

* [Reloadly-Airtime-Transactions](../../doc/controllers/airtime-transactions.md#reloadly-airtime-transactions)
* [Reloadly-Airtime-Transaction-by-Id](../../doc/controllers/airtime-transactions.md#reloadly-airtime-transaction-by-id)


# Reloadly-Airtime-Transactions

```csharp
ReloadlyAirtimeTransactionsAsync(
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
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `accept` | `string` | Header, Required | - |
| `authorization` | `string` | Header, Required | - |
| `size` | `int?` | Query, Optional | This indicates the number of transactions to be retrieved on a page. Default value is 200. |
| `page` | `int?` | Query, Optional | This indicates the page of the transactions list being retrieved. Default value is 1. |
| `countrycode` | `int?` | Query, Optional | Indicates the ISO code of the country assigned to the top-up's receiver at the time the top-up transaction was made. |
| `operatorid` | `string` | Query, Optional | Indicates the operator identification number assigned to the top-up transaction at the time it was made. |
| `operatorName` | `string` | Query, Optional | Indicates the operator name assigned to the top-up transaction at the time it was made. |
| `customIdentifier` | `string` | Query, Optional | Indicates the unique reference assigned to the top-up transaction at the time it was made. |
| `startDate` | `string` | Query, Optional | Indicates the beginning of the timeframe range for the transactions to be retrieved. |
| `endDate` | `string` | Query, Optional | String  Indicates the end of the timeframe range for the transactions to be retrieved. |

## Response Type

`Task<dynamic>`

## Example Usage

```csharp
string accept = "application/com.reloadly.topups-v1+json";
string authorization = "Bearer <YOUR_TOKEN_HERE>";
int? size = 10;
int? page = 1;
string operatorid = "341";
string operatorName = "MTN Nigeria";
string customIdentifier = "april-top-up";
string startDate = "2021-04-30 00:00:00";
string endDate = "2021-07-30 00:00:00";

try
{
    dynamic result = await airtimeTransactionsController.ReloadlyAirtimeTransactionsAsync(accept, authorization, size, page, null, operatorid, operatorName, customIdentifier, startDate, endDate);
}
catch (ApiException e){};
```

## Example Response

```
{
  "content": [
    {
      "transactionId": 4602843,
      "status": "SUCCESSFUL",
      "operatorTransactionId": "7297929551:OrderConfirmed",
      "customIdentifier": "This is example identifier 130",
      "recipientPhone": 447951631337,
      "recipientEmail": null,
      "senderPhone": 11231231231,
      "countryCode": "GB",
      "operatorId": 535,
      "operatorName": "EE PIN England",
      "discount": 63.37,
      "discountCurrencyCode": "NGN",
      "requestedAmount": 3168.4,
      "requestedAmountCurrencyCode": "NGN",
      "deliveredAmount": 4.9985,
      "deliveredAmountCurrencyCode": "GBP",
      "transactionDate": "2021-12-06 08:13:39",
      "pinDetail": {
        "serial": 558111,
        "info1": "DIAL *611",
        "info2": "DIAL *611",
        "info3": "DIAL *611",
        "value": null,
        "code": 773709733097662,
        "ivr": "1-888-888-8888",
        "validity": "30 days"
      },
      "balanceInfo": null
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


# Reloadly-Airtime-Transaction-by-Id

```csharp
ReloadlyAirtimeTransactionByIdAsync(
    string accept,
    string authorization,
    int transactionid)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `accept` | `string` | Header, Required | - |
| `authorization` | `string` | Header, Required | - |
| `transactionid` | `int` | Template, Required | This indicates the identification number of the transaction to be retrieved. |

## Response Type

`Task<dynamic>`

## Example Usage

```csharp
string accept = "application/com.reloadly.topups-v1+json";
string authorization = "Bearer <YOUR_TOKEN_HERE>";
int transactionid = 101;

try
{
    dynamic result = await airtimeTransactionsController.ReloadlyAirtimeTransactionByIdAsync(accept, authorization, transactionid);
}
catch (ApiException e){};
```

## Example Response

```
{
  "transactionId": 4602843,
  "status": "SUCCESSFUL",
  "operatorTransactionId": "7297929551:OrderConfirmed",
  "customIdentifier": "This is example identifier 130",
  "recipientPhone": 447951631337,
  "recipientEmail": null,
  "senderPhone": 11231231231,
  "countryCode": "GB",
  "operatorId": 535,
  "operatorName": "EE PIN England",
  "discount": 63.37,
  "discountCurrencyCode": "NGN",
  "requestedAmount": 3168.4,
  "requestedAmountCurrencyCode": "NGN",
  "deliveredAmount": 4.9985,
  "deliveredAmountCurrencyCode": "GBP",
  "transactionDate": "2021-12-06 08:13:39",
  "pinDetail": {
    "serial": 558111,
    "info1": "DIAL *611",
    "info2": "DIAL *611",
    "info3": "DIAL *611",
    "value": null,
    "code": 773709733097662,
    "ivr": "1-888-888-8888",
    "validity": "30 days"
  },
  "balanceInfo": null
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Full authentication is required to access this resource | `ApiException` |
| 404 | Airtime transaction not found | `ApiException` |

