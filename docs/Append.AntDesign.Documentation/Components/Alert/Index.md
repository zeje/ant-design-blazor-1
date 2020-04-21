Alert component for feedback.

## When To Use

- When you need to show alert messages to users.
- When you need a persistent static container which is closable by user actions.

## API

| Property | Description | Type | Default |
| --- | --- | --- | --- |
| Banner | Whether to show as banner | boolean | false |
| Closable | Whether Alert can be closed | boolean | - |
| CloseText | Close text to show | RenderFragment | - |
| Description | Additional content of Alert | RenderFragment | - |
| Message | Content of Alert | RenderFragment | - |
| Icon | Custom icon, only effective when `ShowIcon` is `true` | IconType | - |
| ShowIcon | Whether to show the icon on the left.| boolean | true |
| Type | Type of Alert styles, options: `success`, `info`, `warning`, `error` | AlertType | AlertType.Info |
| OnClose | Called when the close animation is finished | Eventcallback | - |

## FAQ
> Ask your questions on Github, they might end up here.