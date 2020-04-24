To trigger an operation.
## When To Use

A button means an operation (or a series of operations). Clicking a button will trigger corresponding business logic.

In Ant Design we provide 4 types of button.

- Primary button: indicate the main action, one primary button at most in one section.
- Default button: indicate a series of actions without priority.
- Dashed button: used for adding action commonly.
- Link button: used for external links.

And 4 other properties additionally.

- `danger`: used for actions of risk, like deletion or authorization.
- `ghost`: used in situations with complex background, home pages usually.
- `disabled`: when actions is not available.
- `loading`: add loading spinner in button, avoiding multiple submits too.

## API

To get a customized button, just set `type`/`shape`/`size`/`loading`/`disabled`.

| Property | Description | Type | Default | Version |
| --- | --- | --- | --- | --- |
| Disabled | disabled state of button | boolean | `false` |  |
| Ghost | make background transparent and invert text and border colors | boolean | `false` |  |
| Href | redirect url of link button, which will render the button as an `<a>` tag. | string | - |  |
| HtmlType | set the original html `type` of `button`, see: [MDN](https://developer.mozilla.org/en-US/docs/Web/HTML/Element/button#attr-type) | string | `button` |  |
| Icon | set the icon component of button | RenderFragment | - |  |
| Loading | set the loading status of button | boolean | `false` |  |
| Shape | can be set to `circle`, `round` or omitted | `ButtonShape` | - |  |
| Size | set the size of button | `ButtonSize` | `middle` |  |
| Type | can be set to `primary` `ghost` `dashed` `link` or omitted (meaning `default`) | `ButtonType` | `default` |  |
| OnClick | set the handler to handle `click` event | `EventCallback` | - |  |
| Block | option to fit button width to its parent width | `boolean` | `false` |  |
| Danger | set the danger status of button | `boolean` | `false` |  |

## FAQ
> Ask your questions on Github, they might end up here.


<style>
[id^=components-button-demo-] .ant-btn {
  margin-right: 8px;
  margin-bottom: 12px;
}
[id^=components-button-demo-] .ant-btn-group > .ant-btn,
[id^=components-button-demo-] .ant-btn-group > span > .ant-btn {
  margin-right: 0;
}
[data-theme="dark"] .site-button-ghost-wrapper {
  background: rgba(255, 255, 255, 0.2);
}
</style>
