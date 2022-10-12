# Airtime-Account Balance

```csharp
AirtimeAccountBalanceController airtimeAccountBalanceController = client.AirtimeAccountBalanceController;
```

## Class Name

`AirtimeAccountBalanceController`


# Reloadly-Airtime-Account-Balance

```csharp
ReloadlyAirtimeAccountBalanceAsync(
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
string accept = "application/com.reloadly.topups-v1+json";
string authorization = "Bearer <YOUR_TOKEN_HERE>";

try
{
    dynamic result = await airtimeAccountBalanceController.ReloadlyAirtimeAccountBalanceAsync(accept, authorization);
}
catch (ApiException e){};
```

## Example Response

```
{
  "balance": 5000,
  "currencyCode": "USD",
  "currencyName": "US Dollar",
  "updatedAt": "2021-12-04 08:45:51"
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Full authentication is required to access this resource | `ApiException` |
| 404 | Not Found | `ApiException` |

