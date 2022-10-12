# Airtime-FX Rates

```csharp
AirtimeFXRatesController airtimeFXRatesController = client.AirtimeFXRatesController;
```

## Class Name

`AirtimeFXRatesController`


# Reloadly-Airtime-Fx-Rates

```csharp
ReloadlyAirtimeFxRatesAsync(
    string accept,
    string authorization,
    object body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `accept` | `string` | Header, Required | - |
| `authorization` | `string` | Header, Required | - |
| `body` | `object` | Body, Required | Payload description |

## Response Type

`Task<dynamic>`

## Example Usage

```csharp
string accept = "application/com.reloadly.topups-v1+json";
string authorization = "Bearer <YOUR_TOKEN_HERE>";
object body = ApiHelper.JsonDeserialize<Object>("{\"operatorId\":\"1\",\"amount\":\"1\"}");

try
{
    dynamic result = await airtimeFXRatesController.ReloadlyAirtimeFxRatesAsync(accept, authorization, body);
}
catch (ApiException e){};
```

## Example Response

```
{
  "id": 174,
  "name": "Natcom Haiti",
  "fxRate": 465,
  "currencyCode": "HTG"
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Full authentication is required to access this resource | `ApiException` |
| 404 | Not Found | `ApiException` |
| 500 | Fx rate is currently not available for this operator, please try again later or contact support. | `ApiException` |

