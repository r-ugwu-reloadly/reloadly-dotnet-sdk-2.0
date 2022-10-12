# Airtime-Countries

```csharp
AirtimeCountriesController airtimeCountriesController = client.AirtimeCountriesController;
```

## Class Name

`AirtimeCountriesController`

## Methods

* [Reloadly-Airtime-Countries](../../doc/controllers/airtime-countries.md#reloadly-airtime-countries)
* [Reloadly-Airtime-Country-by-Iso](../../doc/controllers/airtime-countries.md#reloadly-airtime-country-by-iso)


# Reloadly-Airtime-Countries

```csharp
ReloadlyAirtimeCountriesAsync(
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
    dynamic result = await airtimeCountriesController.ReloadlyAirtimeCountriesAsync(accept, authorization);
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


# Reloadly-Airtime-Country-by-Iso

```csharp
ReloadlyAirtimeCountryByIsoAsync(
    string accept,
    string authorization,
    string countrycode)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `accept` | `string` | Header, Required | - |
| `authorization` | `string` | Header, Required | - |
| `countrycode` | `string` | Template, Required | The country's ISO Code. |

## Response Type

`Task<dynamic>`

## Example Usage

```csharp
string accept = "application/com.reloadly.topups-v1+json";
string authorization = "Bearer <YOUR_TOKEN_HERE>";
string countrycode = "US";

try
{
    dynamic result = await airtimeCountriesController.ReloadlyAirtimeCountryByIsoAsync(accept, authorization, countrycode);
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

