
# Reloadly Airtime Async Topup Request

## Structure

`ReloadlyAirtimeAsyncTopupRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `OperatorId` | `string` | Required | - |
| `Amount` | `string` | Required | - |
| `UseLocalAmount` | `bool` | Required | - |
| `CustomIdentifier` | `string` | Required | - |
| `RecipientPhone` | [`Models.RecipientPhone`](../../doc/models/recipient-phone.md) | Required | - |
| `SenderPhone` | [`Models.SenderPhone`](../../doc/models/sender-phone.md) | Required | - |

## Example (as JSON)

```json
{
  "operatorId": "444",
  "amount": "1",
  "useLocalAmount": false,
  "customIdentifier": "This is example identifier",
  "recipientPhone": {
    "countryCode": "ES",
    "number": "657228901"
  },
  "senderPhone": {
    "countryCode": "CA",
    "number": "1231231231"
  }
}
```

