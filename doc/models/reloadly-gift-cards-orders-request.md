
# Reloadly Gift Cards Orders Request

## Structure

`ReloadlyGiftCardsOrdersRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `ProductId` | `int` | Required | - |
| `CountryCode` | `string` | Required | - |
| `Quantity` | `int` | Required | - |
| `UnitPrice` | `int` | Required | - |
| `CustomIdentifier` | `string` | Required | - |
| `SenderName` | `string` | Required | - |
| `RecipientEmail` | `string` | Required | - |
| `RecipientPhoneDetails` | [`Models.RecipientPhoneDetails`](../../doc/models/recipient-phone-details.md) | Required | - |

## Example (as JSON)

```json
{
  "productId": 120,
  "countryCode": "US",
  "quantity": 1,
  "unitPrice": 1,
  "customIdentifier": "obucks10",
  "senderName": "John Doe",
  "recipientEmail": "anyone@email.com",
  "recipientPhoneDetails": {
    "countryCode": "ES",
    "phoneNumber": "657228901"
  }
}
```

