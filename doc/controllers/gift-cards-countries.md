# Gift Cards-Countries

```csharp
GiftCardsCountriesController giftCardsCountriesController = client.GiftCardsCountriesController;
```

## Class Name

`GiftCardsCountriesController`

## Methods

* [Reloadly-Gift-Cards-Countries](../../doc/controllers/gift-cards-countries.md#reloadly-gift-cards-countries)
* [Reloadly-Gift-Cards-Country-by-Iso](../../doc/controllers/gift-cards-countries.md#reloadly-gift-cards-country-by-iso)


# Reloadly-Gift-Cards-Countries

```csharp
ReloadlyGiftCardsCountriesAsync(
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
    dynamic result = await giftCardsCountriesController.ReloadlyGiftCardsCountriesAsync(accept, authorization);
}
catch (ApiException e){};
```

## Example Response

```
[
  {
    "isoName": "AF",
    "name": "Afghanistan",
    "continent": "Asia",
    "currencyCode": "AFN",
    "currencyName": "Afghan Afghani",
    "currencySymbol": "؋",
    "flag": "https://s3.amazonaws.com/rld-flags/af.svg",
    "callingCodes": [
      "+93"
    ]
  },
  {},
  {}
]
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Full authentication is required to access this resource | `ApiException` |
| 404 | Not Found | `ApiException` |


# Reloadly-Gift-Cards-Country-by-Iso

```csharp
ReloadlyGiftCardsCountryByIsoAsync(
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
string accept = "application/com.reloadly.giftcards-v1+json";
string authorization = "Bearer <YOUR_TOKEN_HERE>";
string countrycode = "PK";

try
{
    dynamic result = await giftCardsCountriesController.ReloadlyGiftCardsCountryByIsoAsync(accept, authorization, countrycode);
}
catch (ApiException e){};
```

## Example Response

```
[
  {
    "isoName": "AG",
    "name": "Antigua and Barbuda",
    "continent": "North America",
    "currencyCode": "XCD",
    "currencyName": "East Caribbean Dollar",
    "currencySymbol": "XCD",
    "flag": "https://s3.amazonaws.com/rld-flags/ag.svg",
    "callingCodes": [
      "+1268"
    ]
  }
]
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Full authentication is required to access this resource | `ApiException` |
| 404 | Country not found and/or not currently supported | `ApiException` |

