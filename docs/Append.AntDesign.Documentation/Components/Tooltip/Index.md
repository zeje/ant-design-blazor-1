A simple text popup tip.

## When To Use

- The tip is shown on mouse enter, and is hidden on mouse leave. The Tooltip doesn't support complex text or operations.
- To provide an explanation of a `button/text/operation`. It's often used instead of the html `title` attribute.

## API

| Property | Description                   | Type                               | Default |
| -------- | ----------------------------- | ---------------------------------- | ------- |
| Title    | The text shown in the tooltip | RenderFragment                     | -       |
| ChildContent | The content the tooltip should wrap.  | RenderFragment         | -       |

### Common API

The following APIs are shared by Tooltip, Popconfirm, Popover.

| Property | Description | Type | Default |
| --- | --- | --- | --- |
| DefaultVisible | Whether the floating tooltip card is visible by default | boolean | false |
| ShowDelay | Delay in milliseconds, before the tooltip is shown | int | 100 |
| HideDelay | Delay in milliseconds, before the tooltip is hidden | int | 100 |
| Placement | The position of the tooltip relative to the target, which can be one of `top` `left` `right` `bottom` `topLeft` `topRight` `bottomLeft` `bottomRight` `leftTop` `leftBottom` `rightTop` `rightBottom` | TooltipPlacement | `TooltipPlacement.Top` |
| Triggers  | The tooltip trigger mode. Could be multiple by passing an array | `hover` \| `focus` \| `click` \| `contextMenu` \| `IEnumerable\<TooltipTrigger\>` | `TooltipTrigger.Hover` |
| OnVisibilityChanged | Callback executed when visibility of the tooltip card is changed | EventCallback\<bool\> | - |
| Class | Addtional class name of the tooltip card | string | - |
| OverlayStyle | Addtional style of the tooltip card  | string | - |
## Note

Please ensure that the child node of `Tooltip` accepts `onMouseEnter`, `onMouseLeave`, `onFocus`, `onClick` events.
