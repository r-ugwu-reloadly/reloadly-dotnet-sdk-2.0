# Airtime-Commissions

```csharp
AirtimeCommissionsController airtimeCommissionsController = client.AirtimeCommissionsController;
```

## Class Name

`AirtimeCommissionsController`

## Methods

* [Reloadly-Airtime-Commissions](../../doc/controllers/airtime-commissions.md#reloadly-airtime-commissions)
* [Reloadly-Airtime-Commission-by-Id](../../doc/controllers/airtime-commissions.md#reloadly-airtime-commission-by-id)


# Reloadly-Airtime-Commissions

```csharp
ReloadlyAirtimeCommissionsAsync(
    string accept,
    string authorization,
    int? size = null,
    int? page = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `accept` | `string` | Header, Required | - |
| `authorization` | `string` | Header, Required | - |
| `size` | `int?` | Query, Optional | This indicates the number of operators offering discounts to be retrieved on a page. Default value is 200. |
| `page` | `int?` | Query, Optional | This indicates the page of the discounts list being retrieved. Default value is 1. |

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
    dynamic result = await airtimeCommissionsController.ReloadlyAirtimeCommissionsAsync(accept, authorization, size, page);
}
catch (ApiException e){};
```

## Example Response

```
{
  "content": [
    {
      "operator": {
        "operatorId": 1,
        "name": "Afghan Wireless Afghanistan",
        "countryCode": "AF",
        "status": true,
        "bundle": false
      },
      "percentage": 10,
      "internationalPercentage": 10,
      "localPercentage": 0,
      "updatedAt": "2021-06-26 03:36:16"
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


# Reloadly-Airtime-Commission-by-Id

```csharp
ReloadlyAirtimeCommissionByIdAsync(
    string accept,
    string authorization,
    string operatorid)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `accept` | `string` | Header, Required | - |
| `authorization` | `string` | Header, Required | - |
| `operatorid` | `string` | Template, Required | - |

## Response Type

`Task<dynamic>`

## Example Usage

```csharp
string accept = "application/com.reloadly.topups-v1+json";
string authorization = "Bearer <YOUR_TOKEN_HERE>";
string operatorid = "341";

try
{
    dynamic result = await airtimeCommissionsController.ReloadlyAirtimeCommissionByIdAsync(accept, authorization, operatorid);
}
catch (ApiException e){};
```

## Example Response

```
{
  "operator": {
    "operatorId": 1,
    "name": "Afghan Wireless Afghanistan",
    "countryCode": "AF",
    "status": true,
    "bundle": false
  },
  "percentage": 10,
  "internationalPercentage": 10,
  "localPercentage": 0,
  "updatedAt": "2021-06-26 03:36:16"
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Full authentication is required to access this resource | `ApiException` |
| 404 | Operator not found for given ID | `ApiException` |

