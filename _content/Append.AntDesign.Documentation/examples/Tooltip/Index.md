A simple text popup tip.

## When To Use
- The tip is shown on mouse enter, and is hidden on mouse leave. The Tooltip doesn't support complex text or operations.
- To provide an explanation of a `button/text/operation`. It's often used instead of the html `title` attribute.

## Prerequisites
- To use toolips make sure to:
	- Add the services in `program.cs` by calling `Services.AddAntDesign()`.
	- Add a `<ToolTipContainer/>` to a top level element e.g. `Body` or your `Layout`.
		> Since a `Tooltip` uses absolute positioning it's sometimes relative to it's parent, which can introduce subtle bugs.
		> 
		> By making the `Tooltips` descendents of the `Body` element, these bugs can be be avoided.

## API

| Property | Description                   | Type                               | Default |
| -------- | ----------------------------- | ---------------------------------- | ------- |
| Title    | The text shown in the tooltip | RenderFragment                     | -       |
| ChildContent | The content the tooltip should wrap.  | RenderFragment         | -       |

### Common API

The following APIs are shared by Tooltip, Popconfirm, Popover.

| Property | Description | Type | Default |
| --- | --- | --- | --- |
| Visible | Wether or not to show the tooltip, optional if the component is uncontrolled. | bool | false |
| ShowDelay | Delay in milliseconds, before the tooltip is shown | int | 100 |
| HideDelay | Delay in milliseconds, before the tooltip is hidden | int | 100 |
| Placement | The position of the tooltip relative to the target, which can be one of `top` `left` `right` `bottom` `topLeft` `topRight` `bottomLeft` `bottomRight` `leftTop` `leftBottom` `rightTop` `rightBottom` | TooltipPlacement | `TooltipPlacement.Top` |
| Triggers  | The tooltip trigger mode, `Hover, Click, ContextMenu, Focus` Could be multiple by passing an array | `IEnumerable\<TooltipTrigger\>` | `TooltipTrigger.Hover` |
| VisibleChanged | Callback executed when Visible of the tooltip card is changed | EventCallback\<bool\> | - |

## FAQ
> Ask your questions on Github, they might end up here.
