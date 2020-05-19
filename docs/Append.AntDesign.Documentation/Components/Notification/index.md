Display a notification message globally.

## When To Use

To display a notification message at any of the four corners of the viewport. Typically it can be used in the following cases:

- A notification with complex content.
- A notification providing a feedback based on the user interaction. Or it may show some details about upcoming steps the user may have to follow.
- A notification that is pushed by the application.

## Prerequisites
- To use toolips make sure to:
	- Add the services in `program.cs` by calling `Services.AddAntDesign()`.
	- Add a `<NotificationContainer/>` to a top level element e.g. `Body` or your `Layout`.

## API

- `NotificationService.Open(config)`
- `NotificationService.Open(string message, string description)`
- `NotificationService.Success(config)`
- `NotificationService.Success(string message, string description)`
- `NotificationService.Error(config)`
- `NotificationService.Error(string message, string description)`
- `NotificationService.Info(config)`
- `NotificationService.Info(string message, string description)`
- `NotificationService.Warning(config)`
- `NotificationService.Warning(string message, string description)`
- `NotificationService.Warn(config)`
- `NotificationService.Warn(string message, string description)`
- `NotificationService.Close(key: String)`
- `NotificationService.Destroy()`

A notification can be configuered by using the `NotificationConfigOptions` class that implements the builder pattern.

Example:
```csharp
NotificationService.Open(NotificationConfigOptions.Builder()
                                        .SetDuration(12)
                                        .SetMessage("Notification Title")
                                        .SetDescription("This is the content of the notification.")
                                        .Build());
```

| Property | Description | Type | Default |
| --- | --- | --- | --- |
| Bottom | Distance from the bottom of the viewport, when `Placement` is `NotificationPlacement.BottomRight` or `NotificationPlacement.BottomLeft` (unit: pixels). | double | 24 |
| CloseButton | Customized close button | RenderFragment |  |
| ClassName | Customized CSS class | string |  |
| Description | The content of notification box | string\|RenderFragment |  |
| Duration | Time in seconds before Notification is closed. When set to 0 it will never be closed automatically | double | 4.5 |
| Icon | Customized icon | RenderFragment |  |
| CloseIcon | custom close icon | RenderFragment |  |
| Key | The unique identifier of the Notification | string |  |
| Message | The title of notification box | string\|RenderFragment |  |
| OnClose | Trigger when notification closed | Action |  |
| OnClick | Specify a function that will be called when the notification is clicked | Action |  |
| Placement | Position of the Notification, can be one of `NotificationPlacement.TopLeft` `NotificationPlacement.TopRight` `NotificationPlacement.BottomLeft` `NotificationPlacement.BottomRight` | NotificationPlacement | `NotificationPlacement.TopRight` |
| Style | Customized inline style | string |  |
| Top | Distance from the top of the viewport, when `Placement` is `NotificationPlacement.TopRight` or `NotificationPlacement.TopLeft` (unit: pixels). | double | 24 |

The `NotificationContainer` component also provides a `NotificationGlobalConfigOptions` parameter that can be used for specifying the global default options. Once this parameter is set, all the notifications will take into account these globally defined options when displaying. The `NotificationGlobalConfigOptions` class implements the builder pattern.

Example:
```razor
<NotificationContainer NotificationGlobalConfigOptions="NotificationGlobalConfigOptions.Builder().SetDuration(20).Build()" />
```

| Property | Description | Type | Default |
| --- | --- | --- | --- |
| Bottom | Distance from the bottom of the viewport, when `Placement` is `NotificationPlacement.BottomRight` or `NotificationPlacement.BottomLeft` (unit: pixels). | double | 24 |
| CloseIcon | custom close icon | RenderFragment |  |
| Duration | Time in seconds before Notification is closed. When set to 0 it will never be closed automatically | double | 4.5 |
| Placement | Position of the Notification, can be one of `NotificationPlacement.TopLeft` `NotificationPlacement.TopRight` `NotificationPlacement.BottomLeft` `NotificationPlacement.BottomRight` | NotificationPlacement | `NotificationPlacement.TopRight` |
| Top | Distance from the top of the viewport, when `Placement` is `NotificationPlacement.TopRight` or `NotificationPlacement.TopLeft` (unit: pixels). | double | 24 |