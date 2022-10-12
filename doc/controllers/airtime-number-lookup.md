# Airtime-Number Lookup

```csharp
AirtimeNumberLookupController airtimeNumberLookupController = client.AirtimeNumberLookupController;
```

## Class Name

`AirtimeNumberLookupController`

## Methods

* [Reloadly-Number-Lookup-Get](../../doc/controllers/airtime-number-lookup.md#reloadly-number-lookup-get)
* [Reloadly-Number-Lookup-Post](../../doc/controllers/airtime-number-lookup.md#reloadly-number-lookup-post)


# Reloadly-Number-Lookup-Get

```csharp
ReloadlyNumberLookupGetAsync(
    string accept,
    string authorization,
    int phone,
    string countrycode,
    string suggestedAmountsMap = null,
    string suggestedAmounts = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `accept` | `string` | Header, Required | - |
| `authorization` | `string` | Header, Required | - |
| `phone` | `int` | Template, Required | This is the mobile number whose details are to be retrieved. |
| `countrycode` | `string` | Template, Required | This is the ISO code of the country where the mobile number is registered. |
| `suggestedAmountsMap` | `string` | Query, Optional | Indicates if this field should be returned as a response. Default value is false. |
| `suggestedAmounts` | `string` | Query, Optional | Indicates if this field should be returned as a response. Default value is false. |

## Response Type

`Task<dynamic>`

## Example Usage

```csharp
string accept = "application/com.reloadly.topups-v1+json";
string authorization = "Bearer <YOUR_TOKEN_HERE>";
int phone = 18;
string countrycode = "NG";
string suggestedAmountsMap = "false";
string suggestedAmounts = "false";

try
{
    dynamic result = await airtimeNumberLookupController.ReloadlyNumberLookupGetAsync(accept, authorization, phone, countrycode, suggestedAmountsMap, suggestedAmounts);
}
catch (ApiException e){};
```

## Example Response

```
{
  "id": 88,
  "operatorId": 88,
  "name": "Movistar Colombia",
  "bundle": false,
  "data": false,
  "pin": false,
  "supportsLocalAmounts": false,
  "denominationType": "RANGE",
  "senderCurrencyCode": "USD",
  "senderCurrencySymbol": "$",
  "destinationCurrencyCode": "COP",
  "destinationCurrencySymbol": "$",
  "commission": 4.42,
  "internationalDiscount": 4.42,
  "localDiscount": 0,
  "mostPopularAmount": null,
  "minAmount": 5,
  "maxAmount": 5,
  "localMinAmount": null,
  "localMaxAmount": null,
  "country": {
    "isoName": "CO",
    "name": "Colombia"
  },
  "fx": {
    "rate": 2192.1867,
    "currencyCode": "COP"
  },
  "logoUrls": [
    "https://s3.amazonaws.com/rld-operator/3f4a8bcd3268-size-1.png",
    "https://s3.amazonaws.com/rld-operator/3f4a8bcd3268-size-2.png",
    "https://s3.amazonaws.com/rld-operator/3f4a8bcd3268-size-3.png"
  ],
  "fixedAmounts": [],
  "fixedAmountsDescriptions": [],
  "localFixedAmounts": [],
  "localFixedAmountsDescriptions": [],
  "suggestedAmounts": [
    7,
    10,
    15
  ],
  "suggestedAmountsMap": {
    "7": 19482.51,
    "10": 27832.16,
    "15": 41748.23
  },
  "promotions": []
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Full authentication is required to access this resource | `ApiException` |
| 404 | Not Found | `ApiException` |


# Reloadly-Number-Lookup-Post

```csharp
ReloadlyNumberLookupPostAsync(
    string accept,
    string authorization,
    string contentType,
    object body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `accept` | `string` | Header, Required | - |
| `authorization` | `string` | Header, Required | - |
| `contentType` | `string` | Header, Required | - |
| `body` | `object` | Body, Required | Request Payload |

## Response Type

`Task<dynamic>`

## Example Usage

```csharp
string accept = "application/com.reloadly.topups-v1+json";
string authorization = "Bearer <YOUR_TOKEN_HERE>";
string contentType = "application/json";
object body = ApiHelper.JsonDeserialize<Object>("{\"number\":\"03238582221\",\"countryCode\":\"PK\"}");

try
{
    dynamic result = await airtimeNumberLookupController.ReloadlyNumberLookupPostAsync(accept, authorization, contentType, body);
}
catch (ApiException e){};
```

## Example Response

```
{
  "id": 88,
  "operatorId": 88,
  "name": "Movistar Colombia",
  "bundle": false,
  "data": false,
  "pin": false,
  "supportsLocalAmounts": false,
  "denominationType": "RANGE",
  "senderCurrencyCode": "USD",
  "senderCurrencySymbol": "$",
  "destinationCurrencyCode": "COP",
  "destinationCurrencySymbol": "$",
  "commission": 4.42,
  "internationalDiscount": 4.42,
  "localDiscount": 0,
  "mostPopularAmount": null,
  "minAmount": 5,
  "maxAmount": 5,
  "localMinAmount": null,
  "localMaxAmount": null,
  "country": {
    "isoName": "CO",
    "name": "Colombia"
  },
  "fx": {
    "rate": 2192.1867,
    "currencyCode": "COP"
  },
  "logoUrls": [
    "https://s3.amazonaws.com/rld-operator/3f4a8bcd3268-size-1.png",
    "https://s3.amazonaws.com/rld-operator/3f4a8bcd3268-size-2.png",
    "https://s3.amazonaws.com/rld-operator/3f4a8bcd3268-size-3.png"
  ],
  "fixedAmounts": [],
  "fixedAmountsDescriptions": [],
  "localFixedAmounts": [],
  "localFixedAmountsDescriptions": [],
  "suggestedAmounts": [
    7,
    10,
    15
  ],
  "suggestedAmountsMap": {
    "7": 19482.51,
    "10": 27832.16,
    "15": 41748.23
  },
  "promotions": []
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Full authentication is required to access this resource | `ApiException` |
| 404 | Not Found | `ApiException` |

