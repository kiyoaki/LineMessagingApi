## `ActionType`

```csharp
public enum LineMessaging.ActionType
    : Enum, IComparable, IFormattable, IConvertible

```

Enum

| Value | Name | Summary | 
| --- | --- | --- | 
| `0` | Postback |  | 
| `1` | Message |  | 
| `2` | Uri |  | 
| `3` | Datetimepicker |  | 


## `DatetimepickerAction`

```csharp
public class LineMessaging.DatetimepickerAction
    : ILineAction

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `ActionType` | Type |  | 


## `ILineAction`

```csharp
public interface LineMessaging.ILineAction

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `ActionType` | Type |  | 


## `ILineMessage`

```csharp
public interface LineMessaging.ILineMessage

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `MessageType` | Type |  | 


## `LineAreaBounds`

```csharp
public class LineMessaging.LineAreaBounds

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `Int32` | Height |  | 
| `Int32` | Width |  | 
| `Int32` | X |  | 
| `Int32` | Y |  | 


## `LineAudioMessage`

```csharp
public class LineMessaging.LineAudioMessage
    : ILineMessage

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `Int64` | Duration |  | 
| `String` | OriginalContentUrl |  | 
| `MessageType` | Type |  | 


## `LineErrorResponse`

```csharp
public class LineMessaging.LineErrorResponse

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `DetailObject[]` | Details |  | 
| `String` | Message |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | ToString() |  | 


## `LineImagemapMessage`

```csharp
public class LineMessaging.LineImagemapMessage
    : ILineMessage

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `IAction[]` | Actions |  | 
| `String` | AltText |  | 
| `LineSizeObject` | BaseSize |  | 
| `String` | BaseUrl |  | 
| `MessageType` | Type |  | 


## `LineImageMessage`

```csharp
public class LineMessaging.LineImageMessage
    : ILineMessage

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | OriginalContentUrl |  | 
| `String` | PreviewImageUrl |  | 
| `MessageType` | Type |  | 


## `LineLocationMessage`

```csharp
public class LineMessaging.LineLocationMessage
    : ILineMessage

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | Address |  | 
| `Double` | Latitude |  | 
| `Double` | Longitude |  | 
| `String` | Title |  | 
| `MessageType` | Type |  | 


## `LineMembers`

```csharp
public class LineMessaging.LineMembers

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `String[]` | MemberIds |  | 
| `String` | Next |  | 


## `LineMessagingClient`

```csharp
public class LineMessaging.LineMessagingClient

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Task<String>` | CreateRichMenu(`LineRichMenu` richMenu) |  | 
| `Task` | DeleteRichMenu(`String` richMenuId) |  | 
| `Task<LineProfile>` | GetGroupMember(`String` groupId, `String` userId) |  | 
| `Task<LineMembers>` | GetGroupMembers(`String` groupId, `String` start = null) |  | 
| `Task<Byte[]>` | GetMessageContent(`String` messageId) |  | 
| `Task<LineProfile>` | GetProfile(`String` userId) |  | 
| `Task<LineRichMenuResponse>` | GetRichMenu(`String` richMenuId) |  | 
| `Task<Byte[]>` | GetRichMenuContent(`String` richMenuId) |  | 
| `Task<LineProfile>` | GetRoomMember(`String` roomId, `String` userId) |  | 
| `Task<LineMembers>` | GetRoomMembers(`String` roomId, `String` start = null) |  | 
| `Task<String>` | GetUsersRichMenuId(`String` userId) |  | 
| `Task` | LeaveGroup(`String` groupId) |  | 
| `Task` | LeaveRoom(`String` roomId) |  | 
| `Task` | LinkUsersRichMenu(`String` userId, `String` richMenuId) |  | 
| `Task` | MulticastMessage(`LineMulticastMessage` multicastMessage) |  | 
| `Task` | MulticastMessage(`IEnumerable<String>` to, `ILineMessage` message) |  | 
| `Task` | MulticastMessage(`IEnumerable<String>` to, `IEnumerable<ILineMessage>` messages) |  | 
| `Task` | MulticastMessage(`IEnumerable<String>` to, `String` message) |  | 
| `Task` | MulticastMessage(`IEnumerable<String>` to, `String[]` messages) |  | 
| `Task` | PushMessage(`LinePushMessage` pushMessage) |  | 
| `Task` | PushMessage(`String` to, `ILineMessage` message) |  | 
| `Task` | PushMessage(`String` to, `IEnumerable<ILineMessage>` messages) |  | 
| `Task` | PushMessage(`String` to, `String` message) |  | 
| `Task` | PushMessage(`String` to, `String[]` messages) |  | 
| `Task` | ReplyMessage(`LineReplyMessage` replyMessage) |  | 
| `Task` | ReplyMessage(`String` replyToken, `IEnumerable<ILineMessage>` messages) |  | 
| `Task` | ReplyMessage(`String` replyToken, `String` message) |  | 
| `Task` | ReplyMessage(`String` replyToken, `String[]` messages) |  | 
| `Task` | UnlinkUsersRichMenu(`String` userId) |  | 


## `LineMessagingException`

```csharp
public class LineMessaging.LineMessagingException
    : Exception, ISerializable, _Exception

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `LineErrorResponse` | ErrorResponse |  | 
| `LineOAuthErrorResponse` | OAuthErrorResponse |  | 
| `String` | Path |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | ToString() |  | 


## `LineMulticastMessage`

```csharp
public class LineMessaging.LineMulticastMessage

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `IEnumerable<ILineMessage>` | Messages |  | 
| `IEnumerable<String>` | To |  | 


## `LineOAuthClient`

```csharp
public class LineMessaging.LineOAuthClient

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Task<LineOAuthTokenResponse>` | GetAccessToken() |  | 
| `Task` | RevokeAccessToken(`String` accessToken) |  | 


## `LineOAuthErrorResponse`

```csharp
public class LineMessaging.LineOAuthErrorResponse

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | Description |  | 
| `String` | Error |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | ToString() |  | 


## `LineOAuthTokenResponse`

```csharp
public class LineMessaging.LineOAuthTokenResponse

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | AccessToken |  | 
| `DateTime` | ExpiresIn |  | 
| `String` | TokenType |  | 
| `Int64` | UnixtimeExpiresIn |  | 


## `LineProfile`

```csharp
public class LineMessaging.LineProfile

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | DisplayName |  | 
| `String` | PictureUrl |  | 
| `String` | StatusMessage |  | 
| `String` | UserId |  | 


## `LinePushMessage`

```csharp
public class LineMessaging.LinePushMessage

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `IEnumerable<ILineMessage>` | Messages |  | 
| `String` | To |  | 


## `LineReplyMessage`

```csharp
public class LineMessaging.LineReplyMessage

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `IEnumerable<ILineMessage>` | Messages |  | 
| `String` | ReplyToken |  | 


## `LineRichMenu`

```csharp
public class LineMessaging.LineRichMenu

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `BoundsObject[]` | Areas |  | 
| `String` | CharBarText |  | 
| `String` | Name |  | 
| `Boolean` | Selected |  | 
| `LineSizeObject` | Size |  | 


## `LineRichMenuResponse`

```csharp
public class LineMessaging.LineRichMenuResponse
    : LineRichMenu

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | RichMenuId |  | 


## `LineSizeObject`

```csharp
public class LineMessaging.LineSizeObject

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `Int32` | Height |  | 
| `Int32` | Width |  | 


## `LineStickerMessage`

```csharp
public class LineMessaging.LineStickerMessage
    : ILineMessage

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | PackageId |  | 
| `String` | StickerId |  | 
| `MessageType` | Type |  | 


## `LineTemplateMessage`

```csharp
public class LineMessaging.LineTemplateMessage
    : ILineMessage

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | AltText |  | 
| `TemplateObject` | Template |  | 
| `MessageType` | Type |  | 


## `LineTextMessage`

```csharp
public class LineMessaging.LineTextMessage
    : ILineMessage

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | Text |  | 
| `MessageType` | Type |  | 


## `LineVideoMessage`

```csharp
public class LineMessaging.LineVideoMessage
    : ILineMessage

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | OriginalContentUrl |  | 
| `String` | PreviewImageUrl |  | 
| `MessageType` | Type |  | 


## `LineWebhookContent`

```csharp
public class LineMessaging.LineWebhookContent

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `Event[]` | Events |  | 


## `LineWebhookRequest`

```csharp
public class LineMessaging.LineWebhookRequest

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Task<LineWebhookContent>` | GetContent() |  | 
| `Task<String>` | GetContentJson() |  | 
| `Task<Boolean>` | IsValid() |  | 


## `MessageAction`

```csharp
public class LineMessaging.MessageAction
    : ILineAction

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `ActionType` | Type |  | 


## `MessageType`

```csharp
public enum LineMessaging.MessageType
    : Enum, IComparable, IFormattable, IConvertible

```

Enum

| Value | Name | Summary | 
| --- | --- | --- | 
| `0` | Text |  | 
| `1` | Image |  | 
| `2` | Video |  | 
| `3` | Audio |  | 
| `4` | File |  | 
| `5` | Location |  | 
| `6` | Sticker |  | 
| `7` | Imagemap |  | 
| `8` | Template |  | 


## `PostbackAction`

```csharp
public class LineMessaging.PostbackAction
    : ILineAction

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `ActionType` | Type |  | 


## `TemplateType`

```csharp
public enum LineMessaging.TemplateType
    : Enum, IComparable, IFormattable, IConvertible

```

Enum

| Value | Name | Summary | 
| --- | --- | --- | 
| `0` | Buttons |  | 
| `1` | Confirm |  | 
| `2` | Carousel |  | 
| `3` | ImageCarousel |  | 


## `UriAction`

```csharp
public class LineMessaging.UriAction
    : ILineAction

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `ActionType` | Type |  | 


## `WebhookRequestBeaconType`

```csharp
public enum LineMessaging.WebhookRequestBeaconType
    : Enum, IComparable, IFormattable, IConvertible

```

Enum

| Value | Name | Summary | 
| --- | --- | --- | 
| `0` | Enter |  | 
| `1` | Leave |  | 
| `2` | Banner |  | 


## `WebhookRequestEventType`

```csharp
public enum LineMessaging.WebhookRequestEventType
    : Enum, IComparable, IFormattable, IConvertible

```

Enum

| Value | Name | Summary | 
| --- | --- | --- | 
| `0` | Message |  | 
| `1` | Follow |  | 
| `2` | Unfollow |  | 
| `3` | Join |  | 
| `4` | Leave |  | 
| `5` | Postback |  | 
| `6` | Beacon |  | 


## `WebhookRequestSourceType`

```csharp
public enum LineMessaging.WebhookRequestSourceType
    : Enum, IComparable, IFormattable, IConvertible

```

Enum

| Value | Name | Summary | 
| --- | --- | --- | 
| `0` | User |  | 
| `1` | Group |  | 
| `2` | Room |  | 


