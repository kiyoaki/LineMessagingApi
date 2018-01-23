# LineMessagingApi
LINE Messaging API Client Library for .NET (C#)

## `LineOAuthClient`

### Usage

```csharp
var oAuthClient = new LineOAuthClient("Your Channel ID", "Your Channel Secret");

// get access token
var accessToken = await oAuthClient.GetAccessToken();

// revoke access token
await oAuthClient.RevokeAccessToken(accessToken);
```

## `LineWebhookRequest`

### Usage

```csharp
var webhookRequest = new LineWebhookRequest("Your Channel Secret", HttpRequestMessage);

// verify X-Line-Signature and request body
var valid = await webhookRequest.IsValid();

// get content json
var json = await webhookRequest.GetContentJson();

// get deserialized object
var webhookContent = await webhookRequest.GetContent();
```

## `LineMessagingClient`

### Usage

```csharp
var messagingClient = new LineMessagingClient("Access Token");

// push single message (text, image, video, audio...)
var valid = await messagingClient.PushMessage("User ID", ILineMessage);

// push multiple messages (text, image, video, audio...)
var valid = await messagingClient.PushMessage("User ID", IList<ILineMessage> messages);

// push single text message
var valid = await messagingClient.PushMessage("User ID", "text message");

// push multiple text message
var valid = await messagingClient.PushMessage("User ID", new [] { "text message 1", "text message 2" });

// multicast message
var valid = await messagingClient.MulticastMessage(LineMulticastMessage);

// multicast single text message
var valid = await messagingClient.MulticastMessage(new [] { "User ID 1", "User ID 2" }, "text message");
```

### Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Task<String>` | CreateRichMenu(`LineRichMenu` richMenu) |  | 
| `Task` | DeleteRichMenu(`String` richMenuId) |  | 
| `Task<LineProfile>` | GetGroupMember(`String` groupId, `String` userId) |  | 
| `Task<LineMembers>` | GetGroupMembers(`String` groupId, `String` start = null) |  | 
| `Task<Byte[]>` | GetMessageContent(`String` messageId) |  | 
| `Task<LineProfile>` | GetProfile(`String` userId) |  | 
| `Task<LineProfile>` | GetRichMenu(`String` richMenuId) |  | 
| `Task<Byte[]>` | GetRichMenuContent(`String` richMenuId) |  | 
| `Task<LineProfile>` | GetRoomMember(`String` roomId, `String` userId) |  | 
| `Task<LineMembers>` | GetRoomMembers(`String` roomId, `String` start = null) |  | 
| `Task<String>` | GetUsersRichMenuId(`String` userId) |  | 
| `Task` | LeaveGroup(`String` groupId) |  | 
| `Task` | LeaveRoom(`String` roomId) |  | 
| `Task` | LinkUsersRichMenu(`String` userId, `String` richMenuId) |  | 
| `Task` | MulticastMessage(`LineMulticastMessage` multicastMessage) |  | 
| `Task` | MulticastMessage(`IList<String>` to, `ILineMessage` message) |  | 
| `Task` | MulticastMessage(`IList<String>` to, `IList<ILineMessage>` messages) |  | 
| `Task` | MulticastMessage(`IList<String>` to, `String` message) |  | 
| `Task` | MulticastMessage(`IList<String>` to, `IList<String>` messages) |  | 
| `Task` | PushMessage(`LinePushMessage` pushMessage) |  | 
| `Task` | PushMessage(`String` to, `ILineMessage` message) |  | 
| `Task` | PushMessage(`String` to, `IList<ILineMessage>` messages) |  | 
| `Task` | PushMessage(`String` to, `String` message) |  | 
| `Task` | PushMessage(`String` to, `IList<String>` messages) |  | 
| `Task` | ReplyMessage(`LineReplyMessage` replyMessage) |  | 
| `Task` | UnlinkUsersRichMenu(`String` userId) |  | 

