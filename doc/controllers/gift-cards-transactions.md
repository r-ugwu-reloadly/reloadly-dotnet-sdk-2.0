# Gift Cards-Transactions

```csharp
GiftCardsTransactionsController giftCardsTransactionsController = client.GiftCardsTransactionsController;
```

## Class Name

`GiftCardsTransactionsController`

## Methods

* [Reloadly-Gift-Cards-Transactions](../../doc/controllers/gift-cards-transactions.md#reloadly-gift-cards-transactions)
* [Reloadly-Gift-Cards-Transaction-by-Id](../../doc/controllers/gift-cards-transactions.md#reloadly-gift-cards-transaction-by-id)


# Reloadly-Gift-Cards-Transactions

```csharp
ReloadlyGiftCardsTransactionsAsync(
    string accept,
    string authorization,
    string size = null,
    string page = null,
    string startDate = null,
    string endDate = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `accept` | `string` | Header, Required | - |
| `authorization` | `string` | Header, Required | - |
| `size` | `string` | Query, Optional | This indicates the number of transactions to be retrieved on a page. |
| `page` | `string` | Query, Optional | This indicates the page of the transactions list being retrieved. |
| `startDate` | `string` | Query, Optional | Indicates the start date for the range of transactions to be retrieved. |
| `endDate` | `string` | Query, Optional | Indicates the end date for the range of transactions to be retrieved. |

## Response Type

`Task<dynamic>`

## Example Usage

```csharp
string accept = "application/com.reloadly.giftcards-v1+json";
string authorization = "Bearer <YOUR_TOKEN_HERE>";
string size = "10";
string page = "1";
string startDate = "2021-06-01 10:00:00";
string endDate = "2021-07-20 19:17:02";

try
{
    dynamic result = await giftCardsTransactionsController.ReloadlyGiftCardsTransactionsAsync(accept, authorization, size, page, startDate, endDate);
}
catch (ApiException e){};
```

## Example Response

```
[
  {
    "transactionId": 1,
    "amount": 60553.3575,
    "discount": 0,
    "currencyCode": "NGN",
    "fee": 198.35026,
    "customIdentifier": "obucks3",
    "status": "SUCCESSFUL",
    "product": {
      "productId": 4,
      "productName": "Amazon Spain",
      "countryCode": "ES",
      "quantity": 5,
      "unitPrice": 25,
      "totalPrice": 125,
      "currencyCode": "EUR",
      "brand": {
        "brandId": 2,
        "brandName": "Amazon"
      }
    },
    "smsFee": 56.91,
    "receipientPhone": 34657829900,
    "transactionCreatedTime": "2022-02-28 13:46:00"
  },
  {},
  {}
]
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Full authentication is required to access this resource | `ApiException` |
| 404 | Could not retrieve/update resources at the moment, please try again later | `ApiException` |


# Reloadly-Gift-Cards-Transaction-by-Id

```csharp
ReloadlyGiftCardsTransactionByIdAsync(
    string accept,
    string authorization,
    string transactionid)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `accept` | `string` | Header, Required | - |
| `authorization` | `string` | Header, Required | - |
| `transactionid` | `string` | Template, Required | Indicates the identification number of the transaction to be retrieved. |

## Response Type

`Task<dynamic>`

## Example Usage

```csharp
string accept = "application/com.reloadly.giftcards-v1+json";
string authorization = "Bearer <YOUR_TOKEN_HERE>";
string transactionid = "2";

try
{
    dynamic result = await giftCardsTransactionsController.ReloadlyGiftCardsTransactionByIdAsync(accept, authorization, transactionid);
}
catch (ApiException e){};
```

## Example Response

```
[
  {
    "transactionId": 1,
    "amount": 60553.3575,
    "discount": 0,
    "currencyCode": "NGN",
    "fee": 198.35026,
    "customIdentifier": "obucks3",
    "status": "SUCCESSFUL",
    "product": {
      "productId": 4,
      "productName": "Amazon Spain",
      "countryCode": "ES",
      "quantity": 5,
      "unitPrice": 25,
      "totalPrice": 125,
      "currencyCode": "EUR",
      "brand": {
        "brandId": 2,
        "brandName": "Amazon"
      }
    },
    "smsFee": 56.91,
    "receipientPhone": 34657829900,
    "transactionCreatedTime": "2022-02-28 13:46:00"
  }
]
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Indicates the identification number of the transaction to be retrieved. | `ApiException` |
| 404 | Could not retrieve/update resources at the moment, please try again later | `ApiException` |

