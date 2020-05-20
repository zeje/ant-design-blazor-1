Radio.

## When To Use

- Used to select a single state from multiple options.
- The difference from Select is that Radio is visible to the user and can facilitate the comparison of choice, which means there shouldn't be too many of them.

## API

### Radio/RadioButton

| Property | Description | Type | Default |
| --- | --- | --- | --- |
| Checked | Specifies whether the radio is selected. | bool | false |
| DefaultChecked | Specifies the initial state: whether or not the radio is selected. | bool | false |
| Disabled | Disable radio | boolean | false |
| Value | Value for comparison, to determine whether the radio should be selected in a `RadioGroup` | string |  |

### RadioGroup

`RadioGroup` can wrap a group of `Radio` or `RadioButton`.

| Property | Description | Type | Default |
| --- | --- | --- | --- |
| DefaultValue | Default selected value | string |  |
| Disabled | Disable all radio buttons | bool | false |
| Name | The `name` property of all `input[type="radio"]` children | string |  |
| Options | set children optional | List<RadioGroupOption> |  |
| Size | size for the radio button style, can be set to `RadioButtonSize.Small`, `RadioButtonSize.Middle` or `RadioButtonSize.Large` | `RadioButtonSize` | `RadioButtonSize.Middle` |
| Value | Used for setting the currently selected value. | string |  |
| OnChange | The callback function that is triggered when the state changes. | `EventCallback<bool>` |  |
| ButtonStyle | style type of the radio button, can be set to `RadioButtonStyle.Outline` or `RadioButtonStyle.Solid` | `RadioButtonStyle` | `RadioButtonStyle.Outline` |