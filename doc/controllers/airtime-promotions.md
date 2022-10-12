# Airtime-Promotions

```csharp
AirtimePromotionsController airtimePromotionsController = client.AirtimePromotionsController;
```

## Class Name

`AirtimePromotionsController`

## Methods

* [Reloadly-Airtime-Promotions](../../doc/controllers/airtime-promotions.md#reloadly-airtime-promotions)
* [Reloadly-Airtime-Promotion-by-Id](../../doc/controllers/airtime-promotions.md#reloadly-airtime-promotion-by-id)
* [Reloadly-Airtime-Promotion-by-Iso](../../doc/controllers/airtime-promotions.md#reloadly-airtime-promotion-by-iso)
* [Reloadly-Airtime-Promotion-by-Operator-Id](../../doc/controllers/airtime-promotions.md#reloadly-airtime-promotion-by-operator-id)


# Reloadly-Airtime-Promotions

```csharp
ReloadlyAirtimePromotionsAsync(
    string accept,
    string authorization,
    int? size = null,
    int? page = null,
    int? languageCode = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `accept` | `string` | Header, Required | - |
| `authorization` | `string` | Header, Required | - |
| `size` | `int?` | Query, Optional | This indicates the number of promotions to be retrieved on a page. Default value is 200. |
| `page` | `int?` | Query, Optional | This indicates the page of the promotions list being retrieved. Default value is 1. |
| `languageCode` | `int?` | Query, Optional | This indicates the language you want the promotion information to be displayed in. The language code is to be specified in the ISO 639-1 format. Choices are 'EN', 'ES', 'FR', 'IT', 'PT', 'ZH', 'AR', 'HI', 'HT', 'JA' and 'DE'. Default is 'EN'. This is a case-insensitive field. The promotion information is returned in your requested language irrespective of the original language in which the promotion was launched. |

## Response Type

`Task<dynamic>`

## Example Usage

```csharp
string accept = "application/com.reloadly.topups-v1+json";
string authorization = "Bearer <YOUR_TOKEN_HERE>";
int? size = 10;
int? page = 1;

try
{
    dynamic result = await airtimePromotionsController.ReloadlyAirtimePromotionsAsync(accept, authorization, size, page, null);
}
catch (ApiException e){};
```

## Example Response

```
{
  "content": [
    {
      "promotionId": 1,
      "operatorId": 129,
      "title": "Tigo El Salvador From 25 Jun 2018 00:00 To 25 July...",
      "title2": "Get 500 MB and 150 minutes for USA or Canada",
      "description": "For top ups of $10 or more, customer...",
      "startDate": "Mon, 25 Jun 2018 06:00:00 +0000",
      "endDate": "Tue, 26 Jun 2018 05:59:00 +0000",
      "denominations": "USD 10 and up",
      "localDenominations": null
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


# Reloadly-Airtime-Promotion-by-Id

```csharp
ReloadlyAirtimePromotionByIdAsync(
    string accept,
    string authorization,
    string promotionid,
    string languageCode = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `accept` | `string` | Header, Required | - |
| `authorization` | `string` | Header, Required | - |
| `promotionid` | `string` | Template, Required | The promotion's identification number. |
| `languageCode` | `string` | Query, Optional | This indicates the language you want the promotion information to be displayed in. The language code is to be specified in the ISO 639-1 format. Choices are 'EN', 'ES', 'FR', 'IT', 'PT', 'ZH', 'AR', 'HI', 'HT', 'JA' and 'DE'. Default is 'EN'. This is a case-insensitive field. The promotion information is returned in your requested language irrespective of the original language in which the promotion was launched. |

## Response Type

`Task<dynamic>`

## Example Usage

```csharp
string accept = "application/com.reloadly.topups-v1+json";
string authorization = "Bearer <YOUR_TOKEN_HERE>";
string promotionid = "5583";
string languageCode = "EN";

try
{
    dynamic result = await airtimePromotionsController.ReloadlyAirtimePromotionByIdAsync(accept, authorization, promotionid, languageCode);
}
catch (ApiException e){};
```

## Example Response

```
{
  "content": {
    "promotionId": 1,
    "operatorId": 129,
    "title": "Tigo El Salvador From 25 Jun 2018 00:00 To 25 July...",
    "title2": "Get 500 MB and 150 minutes for USA or Canada",
    "description": "For top ups of $10 or more, customer...",
    "startDate": "Mon, 25 Jun 2018 06:00:00 +0000",
    "endDate": "Tue, 26 Jun 2018 05:59:00 +0000",
    "denominations": "USD 10 and up",
    "localDenominations": null
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Full authentication is required to access this resource | `ApiException` |
| 404 | Promotion not found | `ApiException` |


# Reloadly-Airtime-Promotion-by-Iso

```csharp
ReloadlyAirtimePromotionByIsoAsync(
    string accept,
    string authorization,
    string countrycode)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `accept` | `string` | Header, Required | - |
| `authorization` | `string` | Header, Required | - |
| `countrycode` | `string` | Template, Required | - |

## Response Type

`Task<dynamic>`

## Example Usage

```csharp
string accept = "application/com.reloadly.topups-v1+json";
string authorization = "Bearer <YOUR_TOKEN_HERE>";
string countrycode = "US";

try
{
    dynamic result = await airtimePromotionsController.ReloadlyAirtimePromotionByIsoAsync(accept, authorization, countrycode);
}
catch (ApiException e){};
```

## Example Response

```
{
  "content": [
    {
      "promotionId": 1,
      "operatorId": 129,
      "title": "Tigo El Salvador From 25 Jun 2018 00:00 To 25 July...",
      "title2": "Get 500 MB and 150 minutes for USA or Canada",
      "description": "For top ups of $10 or more, customer...",
      "startDate": "Mon, 25 Jun 2018 06:00:00 +0000",
      "endDate": "Tue, 26 Jun 2018 05:59:00 +0000",
      "denominations": "USD 10 and up",
      "localDenominations": null
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


# Reloadly-Airtime-Promotion-by-Operator-Id

```csharp
ReloadlyAirtimePromotionByOperatorIdAsync(
    string accept,
    string authorization,
    string operatorid)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `accept` | `string` | Header, Required | - |
| `authorization` | `string` | Template, Required | - |
| `operatorid` | `string` | Template, Required | - |

## Response Type

`Task<dynamic>`

## Example Usage

```csharp
string accept = "application/com.reloadly.topups-v1+json";
string authorization = "Bearer <YOUR_TOKEN_HERE>";
string operatorid = "129";

try
{
    dynamic result = await airtimePromotionsController.ReloadlyAirtimePromotionByOperatorIdAsync(accept, authorization, operatorid);
}
catch (ApiException e){};
```

## Example Response

```
{
  "content": [
    {
      "promotionId": 1,
      "operatorId": 129,
      "title": "Tigo El Salvador From 25 Jun 2018 00:00 To 25 July...",
      "title2": "Get 500 MB and 150 minutes for USA or Canada",
      "description": "For top ups of $10 or more, customer...",
      "startDate": "Mon, 25 Jun 2018 06:00:00 +0000",
      "endDate": "Tue, 26 Jun 2018 05:59:00 +0000",
      "denominations": "USD 10 and up",
      "localDenominations": null
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

