# Gift Cards-Account Balance

```csharp
GiftCardsAccountBalanceController giftCardsAccountBalanceController = client.GiftCardsAccountBalanceController;
```

## Class Name

`GiftCardsAccountBalanceController`


# Reloadly-Gift-Cards-Account-Balance

```csharp
ReloadlyGiftCardsAccountBalanceAsync(
    string accept,
    string authorization)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `accept` | `string` | Header, Required | - |
| `authorization` | `string` | Header, Required | - |

## Response Type

`Task<dynamic>`

## Example Usage

```csharp
string accept = "application/com.reloadly.giftcards-v1+json";
string authorization = "Bearer <YOUR_TOKEN_HERE>";

try
{
    dynamic result = await giftCardsAccountBalanceController.ReloadlyGiftCardsAccountBalanceAsync(accept, authorization);
}
catch (ApiException e){};
```

## Example Response

```
{
  "balance": 6000,
  "currencyCode": "USD",
  "currencyName": "US Dollar",
  "updatedAt": "2022-02-04 17:45:51"
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Full authentication is required to access this resource | `ApiException` |
| 404 | Not Found | `ApiException` |

