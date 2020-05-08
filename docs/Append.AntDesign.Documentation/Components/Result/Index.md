Provides feedback the results of a series of operational tasks.

## When To Use

Use when important operations need to inform the user to process the results and the feedback is more complicated.

## API

| Property | Description | Type | Default |
| --- | --- | --- | --- |
| Title | the headline | RenderFragment | - |
| SubTitle | a small description under the headline | RenderFragment | - |
| Status | result status, which manipulates the icon. `Success` \| `Error` \| `Info` \| `Warning` \| `NotFound_404` \| `Unauthorized_403` \| `BadRequest_500` | ResultStatus | `ResultStatus.Info` |
| Icon | override the default icons, which are based on the `Status` | IconType | - |
| ChildContent | content to place more information and buttons | RenderFragment | - |
