A basic widget for getting the user input in a text field. A keyboard and mouse can also be used for providing or changing data.

## When To Use

- A user input in a form field is needed.
- A search input is required.

## API

### `Input`

| Property | Description | Type | Default |
| --- | --- | --- | --- |
| AddonAfterText | The label text displayed after (on the right side of) the input field. | string |  |
| AddonBeforeText | The label text displayed before (on the left side of) the input field. | string |  |
| AddonAfterIcon | The label icon displayed after (on the right side of) the input field. | IconType |  |
| AddonBeforeIcon | The label icon displayed before (on the left side of) the input field. | IconType |  |
| DefaultValue | The initial input content | string |  |
| Disabled | Whether the input is disabled. | bool | false |
| MaxLength | max length | int? |  |
| PrefixText | The prefix text for the Input. | string  |
| PrefixIcon | The prefix icon for the Input. | IconType  |
| Size | The size of the input box. | `InputSize` | `InputSize.Middle`  |
| SuffixText | The suffix text for the Input. | string |  |
| SuffixIcon | The suffix icon for the Input. | IconType |  |
| Value | The input content value | string |  |
| OnChange | callback when user input | EventCallback<string> |  |
| OnPressEnter | The callback function that is triggered when Enter key is pressed. | EventCallback<string> |  |
| AllowClear | allow to remove input content with clear icon | bool? |  |

### `TextArea`

| Property | Description | Type | Default |
| --- | --- | --- | --- |
| AutoSize | Use the height autosize feature | bool | false |
| AutoSizeConstraints | Height autosize constraints, the tuple represents the min and max amount of rows | Tuple<int,int> |  |
| OnPressEnter | The callback function that is triggered when Enter key is pressed. | EventCallback<string> |  |
| OnResize | The callback function when the TextArea is resized. | EventCallback<string> |  |

Supports most props of `Input`.

#### `Search`

| Property | Description | Type | Default |
| --- | --- | --- | --- |
| EnterButton | to show an enter button after input, use EnterButton="" to get a button with a search icon. This property conflicts with the `AddonAfter` property. | string |  |
| OnSearch | The callback function triggered when you click on the search-icon, the clear-icon or press the Enter key. | EventCallback<string> |  |
| Loading | Search box with a loading icon. | bool | false |

Supports all props of `Input`.

#### `Password`

| Property         | Description                | Type    | Default |
| ---------------- | -------------------------- | ------- | ------- |
| VisibilityToggle | Whether show the toggle button | bool | true    |

Supports all props of `Input`.

#### InputGroup

| Property | Description | Type | Default |
| --- | --- | --- | --- |
| Compact | Whether use the compact style | bool | false |
| Size | The size of `InputGroup` specifies the size of the included `Input` fields. Available: `InputSize.Large` `InputSize.Middle` `InputSize.Small` | `InputSize` | `InputSize.Middle` |