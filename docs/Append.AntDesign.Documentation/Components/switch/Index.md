Switching Selector.

## When To Use

- If you need to represent the switching between two states or on-off state.
- The difference between `Switch` and `Checkbox` is that `Switch` will trigger a state change directly when you toggle it, while `Checkbox` is generally used for state marking, which should work in conjunction with submit operation.

## API

| Property | Description | Type | Default |
| --- | --- | --- | --- |
| AutoFocus | get focus when component mounted | boolean | false |
| Checked | determine whether the `Switch` is checked | boolean? |  |
| CheckedChildText | content to be shown when the state is checked | string |  |
| CheckedChildIcon | content to be shown when the state is checked | IconType |  |
| DefaultChecked | to set the initial state | boolean | false |
| Disabled | Disable switch | boolean | false |
| Loading | loading state of switch | boolean | false |
| Size | the size of the `Switch`, options: `SwitchSize.Default` `SwitchSize.Small` | SwitchSize | SwitchSize.Default |
| UnCheckedChildText | content to be shown when the state is unchecked | string |  |
| UnCheckedChildIcon | content to be shown when the state is unchecked | IconType |  |
| CheckChanged | trigger when the checked state is changing | EventCallback<bool> |  |
| OnClick | trigger when clicked | EventCallback<bool> |  |

## Methods

> Currently not implemented.