# Utility Payments-Pay Bill

```csharp
UtilityPaymentsPayBillController utilityPaymentsPayBillController = client.UtilityPaymentsPayBillController;
```

## Class Name

`UtilityPaymentsPayBillController`


# Reloadly-Utility-Payments-Pay-Bill

```csharp
ReloadlyUtilityPaymentsPayBillAsync(
    string accept,
    string authorization,
    Models.ReloadlyUtilityPaymentsPayBillRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `accept` | `string` | Header, Required | - |
| `authorization` | `string` | Header, Required | - |
| `body` | [`Models.ReloadlyUtilityPaymentsPayBillRequest`](../../doc/models/reloadly-utility-payments-pay-bill-request.md) | Body, Required | Request Payload |

## Response Type

`Task<dynamic>`

## Example Usage

```csharp
string accept = "application/com.reloadly.utilities-v1+json";
string authorization = "Bearer <YOUR_TOKEN_HERE>";
var body = new ReloadlyUtilityPaymentsPayBillRequest();
body.SubscriberAccountNumber = "04223568280";
body.Amount = 1000;
body.BillerId = 5;
body.UseLocalAmount = false;

try
{
    dynamic result = await utilityPaymentsPayBillController.ReloadlyUtilityPaymentsPayBillAsync(accept, authorization, body);
}
catch (ApiException e){};
```

## Example Response

```
{
  "id": 36,
  "status": "PROCESSING",
  "referenceId": "4a391847-n193-22k8-wqkl-9h3s7428m036",
  "code": "PAYMENT_PROCESSING_IN_PROGRESS",
  "message": "The payment is being processed, status will be updated when biller processes the payment.",
  "submittedAt": "2022-05-18 09:13:53",
  "finalStatusAvailabilityAt": "2022-05-19 09:13:52"
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Full authentication is required to access this resource | `ApiException` |
| 404 | Not Found | `ApiException` |

