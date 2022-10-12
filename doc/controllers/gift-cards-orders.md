# Gift Cards-Orders

```csharp
GiftCardsOrdersController giftCardsOrdersController = client.GiftCardsOrdersController;
```

## Class Name

`GiftCardsOrdersController`

## Methods

* [Reloadly-Gift-Cards-Redeem-Codes](../../doc/controllers/gift-cards-orders.md#reloadly-gift-cards-redeem-codes)
* [Reloadly-Gift-Cards-Orders](../../doc/controllers/gift-cards-orders.md#reloadly-gift-cards-orders)


# Reloadly-Gift-Cards-Redeem-Codes

```csharp
ReloadlyGiftCardsRedeemCodesAsync(
    string accept,
    string authorization,
    int transactionid)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `accept` | `string` | Header, Required | - |
| `authorization` | `string` | Header, Required | - |
| `transactionid` | `int` | Template, Required | Indicates the transaction identification number of the gift card's redeem code to be retrieved. |

## Response Type

`Task<dynamic>`

## Example Usage

```csharp
string accept = "application/com.reloadly.giftcards-v1+json";
string authorization = "Bearer <YOUR_TOKEN_HERE>";
int transactionid = 2;

try
{
    dynamic result = await giftCardsOrdersController.ReloadlyGiftCardsRedeemCodesAsync(accept, authorization, transactionid);
}
catch (ApiException e){};
```

## Example Response

```
{
  "cardNumber": 6120200345149064,
  "pinCode": 5821
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Full authentication is required to access this resource | `ApiException` |
| 404 | Invalid transaction ID | `ApiException` |


# Reloadly-Gift-Cards-Orders

```csharp
ReloadlyGiftCardsOrdersAsync(
    string accept,
    string authorization,
    object body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `accept` | `string` | Header, Required | - |
| `authorization` | `string` | Header, Required | - |
| `body` | `object` | Body, Required | Request Payload |

## Response Type

`Task<dynamic>`

## Example Usage

```csharp
string accept = "application/com.reloadly.giftcards-v1+json";
string authorization = "Bearer <YOUR_TOKEN_HERE>";
object body = ApiHelper.JsonDeserialize<Object>("{\"productId\":120,\"countryCode\":\"US\",\"quantity\":1,\"unitPrice\":1,\"customIdentifier\":\"obucks10\",\"senderName\":\"John Doe\",\"recipientEmail\":\"anyone@email.com\",\"recipientPhoneDetails\":{\"countryCode\":\"ES\",\"phoneNumber\":\"657228901\"}}");

try
{
    dynamic result = await giftCardsOrdersController.ReloadlyGiftCardsOrdersAsync(accept, authorization, body);
}
catch (ApiException e){};
```

## Example Response

```
{
  "transactionId": 1,
  "amount": 34536.21,
  "discount": 1709.72,
  "currencyCode": "NGN",
  "fee": 285,
  "recipientEmail": "anyone@email.com",
  "customIdentifier": "obucks1dime0",
  "status": "SUCCESSFUL",
  "product": {
    "productId": 1,
    "productName": "1-800-PetSupplies",
    "countryCode": "PS",
    "quantity": 1,
    "unitPrice": 59.99,
    "totalPrice": 59.99,
    "currencyCode": "USD",
    "brand": {
      "brandId": 6,
      "brandName": "1-800-PetSupplies"
    }
  },
  "smsFee": 56.91,
  "recipientPhone": 34657829900,
  "transactionCreatedTime": "2022-02-28 13:46:00"
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Invalid price, please ensure you selected the right price | `ApiException` |
| 401 | Full authentication is required to access this resource | `ApiException` |
| 404 | Not found | `ApiException` |

