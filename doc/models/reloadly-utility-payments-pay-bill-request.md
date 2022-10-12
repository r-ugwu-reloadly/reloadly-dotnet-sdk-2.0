
# Reloadly Utility Payments Pay Bill Request

## Structure

`ReloadlyUtilityPaymentsPayBillRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `SubscriberAccountNumber` | `string` | Required | - |
| `Amount` | `int` | Required | - |
| `BillerId` | `int` | Required | - |
| `UseLocalAmount` | `bool` | Required | - |

## Example (as JSON)

```json
{
  "subscriberAccountNumber": "04223568280",
  "amount": 1000,
  "billerId": 5,
  "useLocalAmount": false
}
```

