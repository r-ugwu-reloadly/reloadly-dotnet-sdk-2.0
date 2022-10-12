# Airtime-Operators

```csharp
AirtimeOperatorsController airtimeOperatorsController = client.AirtimeOperatorsController;
```

## Class Name

`AirtimeOperatorsController`

## Methods

* [Reloadly-Airtime-Operators](../../doc/controllers/airtime-operators.md#reloadly-airtime-operators)
* [Reloadly-Airtime-Operator-Autodetect](../../doc/controllers/airtime-operators.md#reloadly-airtime-operator-autodetect)
* [Reloadly-Airtime-Operator-by-Id](../../doc/controllers/airtime-operators.md#reloadly-airtime-operator-by-id)
* [Reloadly-Airtime-Operator-by-Iso](../../doc/controllers/airtime-operators.md#reloadly-airtime-operator-by-iso)


# Reloadly-Airtime-Operators

```csharp
ReloadlyAirtimeOperatorsAsync(
    string accept,
    string authorization,
    string includeBundles = null,
    string includeData = null,
    string suggestedAmountsMap = null,
    string size = null,
    string page = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `accept` | `string` | Header, Required | - |
| `authorization` | `string` | Header, Required | - |
| `includeBundles` | `string` | Query, Optional | Indicates if any airtime and data bundles being offered by the operator should be included in the API response. Default value is true. |
| `includeData` | `string` | Query, Optional | Indicates if any airtime or data plans being offered by the operator should be included in the API response. Default value is true. |
| `suggestedAmountsMap` | `string` | Query, Optional | Indicates if this field should be returned as a response. Default value is false. |
| `size` | `string` | Query, Optional | This indicates the number of operators to be retrieved on a page. Default value is 200. |
| `page` | `string` | Query, Optional | This indicates the page of the operator list being retrieved. Default value is 1. |

## Response Type

`Task<dynamic>`

## Example Usage

```csharp
string accept = "application/com.reloadly.topups-v1+json";
string authorization = "Bearer <YOUR_TOKEN_HERE>";
string includeBundles = "true";
string includeData = "true";
string suggestedAmountsMap = "false";
string size = "10";
string page = "2";

try
{
    dynamic result = await airtimeOperatorsController.ReloadlyAirtimeOperatorsAsync(accept, authorization, includeBundles, includeData, suggestedAmountsMap, size, page);
}
catch (ApiException e){};
```

## Example Response

```
{
  "content": [
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


# Reloadly-Airtime-Operator-Autodetect

```csharp
ReloadlyAirtimeOperatorAutodetectAsync(
    string accept,
    string authorization,
    string phone,
    string countryisocode,
    string countrycode,
    bool? suggestedAmounts = null,
    bool? suggestedAmountsMap = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `accept` | `string` | Header, Required | - |
| `authorization` | `string` | Header, Required | - |
| `phone` | `string` | Template, Required | The mobile number whose details are to be retrieved. |
| `countryisocode` | `string` | Template, Required | The ISO code of the country where the mobile number is registered. |
| `countrycode` | `string` | Template, Required | - |
| `suggestedAmounts` | `bool?` | Query, Optional | Indicates if this field should be returned as a response. Default value is false. |
| `suggestedAmountsMap` | `bool?` | Query, Optional | Indicates if this field should be returned as a response. Default value is false. |

## Response Type

`Task<dynamic>`

## Example Usage

```csharp
string accept = "application/com.reloadly.topups-v1+json";
string authorization = "Bearer <YOUR_TOKEN_HERE>";
string phone = "8147658721";
string countryisocode = "US";
string countrycode = "countrycode6";
bool? suggestedAmounts = false;
bool? suggestedAmountsMap = true;

try
{
    dynamic result = await airtimeOperatorsController.ReloadlyAirtimeOperatorAutodetectAsync(accept, authorization, phone, countryisocode, countrycode, suggestedAmounts, suggestedAmountsMap);
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
| 404 | Country code must be 2 characters ISO-Alpha-2 country code. See https://www.iban.com/country-codes | `ApiException` |


# Reloadly-Airtime-Operator-by-Id

```csharp
ReloadlyAirtimeOperatorByIdAsync(
    string accept,
    string authorization,
    string operatorid)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `accept` | `string` | Header, Required | - |
| `authorization` | `string` | Header, Required | - |
| `operatorid` | `string` | Template, Required | The operator's identification number. |

## Response Type

`Task<dynamic>`

## Example Usage

```csharp
string accept = "application/com.reloadly.topups-v1+json";
string authorization = "Bearer <YOUR_TOKEN_HERE>";
string operatorid = "88";

try
{
    dynamic result = await airtimeOperatorsController.ReloadlyAirtimeOperatorByIdAsync(accept, authorization, operatorid);
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
| 404 | Operator not found for given id | `ApiException` |


# Reloadly-Airtime-Operator-by-Iso

```csharp
ReloadlyAirtimeOperatorByIsoAsync(
    string accept,
    string authorization,
    string countrycode,
    bool includeBundles,
    bool? suggestedAmountsMap = null,
    string suggestedAmounts = null,
    bool? includePin = null,
    bool? includeData = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `accept` | `string` | Header, Required | - |
| `authorization` | `string` | Query, Required | - |
| `countrycode` | `string` | Template, Required | The ISO code of the country where the operator is registered. |
| `includeBundles` | `bool` | Query, Required | Indicates if any airtime and data bundles being offered by the operator should be returned as a response. Default value is true. |
| `suggestedAmountsMap` | `bool?` | Query, Optional | Indicates if this field should be returned as a response. Default value is false. |
| `suggestedAmounts` | `string` | Query, Optional | Indicates if this field should be returned as a response. Default value is false. |
| `includePin` | `bool?` | Query, Optional | Indicates if PIN details if applicable to the operator, should be returned as a response. Default value is true. |
| `includeData` | `bool?` | Query, Optional | Indicates if any data plans being offered by the operator should be returned as a response. Default value is true. |

## Response Type

`Task<dynamic>`

## Example Usage

```csharp
string accept = "application/com.reloadly.topups-v1+json";
string authorization = "Bearer <YOUR_TOKEN_HERE>";
string countrycode = "US";
bool includeBundles = false;
bool? suggestedAmountsMap = false;
string suggestedAmounts = "false";
bool? includePin = false;
bool? includeData = false;

try
{
    dynamic result = await airtimeOperatorsController.ReloadlyAirtimeOperatorByIsoAsync(accept, authorization, countrycode, includeBundles, suggestedAmountsMap, suggestedAmounts, includePin, includeData);
}
catch (ApiException e){};
```

## Example Response

```
{
  "example": {
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
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Full authentication is required to access this resource | `ApiException` |
| 404 | Country not found and/or not currently supported | `ApiException` |

