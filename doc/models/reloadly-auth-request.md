
# Reloadly Auth Request

## Structure

`ReloadlyAuthRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `ClientId` | `string` | Required | - |
| `ClientSecret` | `string` | Required | - |
| `GrantType` | `string` | Required | - |
| `Audience` | `string` | Required | - |

## Example (as JSON)

```json
{
  "client_id": "CLIENT_ID_GOES_HERE",
  "client_secret": "CLIENT_SECRET_GOES_HERE",
  "grant_type": "client_credentials",
  "audience": "https://topups.reloadly.com"
}
```

