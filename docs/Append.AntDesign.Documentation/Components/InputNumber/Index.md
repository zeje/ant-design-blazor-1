Enter a number within certain range with the mouse or keyboard.

## When To Use

When a numeric value needs to be provided.

## API

| Property | Description | Type | Default |
| --- | --- | --- | --- |
| AutoFocus | get focus when component mounted | bool | false |
| DefaultValue | initial value | number |  |
| Disabled | disable the input | bool | false |
| Formatter | Specifies the format of the value presented | function(value: number \| string): string |  |
| Max | max value | number | Infinity |
| Min | min value | number | -Infinity |
| Parser | Specifies the value extracted from formatter | function( string): number |  |
| Precision | precision of input value | number |  |
| DecimalSeparator | decimal separator | string |  |
| Size | height of input box | `InputSize` | `InputSize.Middle` |
| Step | The number to which the current value is increased or decreased. It can be an integer or decimal. | number\|string | 1 |
| Type | HTML inputs can have a type of `number`, and this can be added to aid mobile broswer keyboards to show the number keybaord, as well as limit inputs to numbers only `0-9` and `e`, but will not guaruntee client and server side validation. | string - ie 'number' |  |
| Value | current value | number |  |
| OnChange | The callback triggered when the value is changed. | function(value: number \| string) |  |
| OnPressEnter | The callback function that is triggered when Enter key is pressed. | function(e) |  |

## Methods

| Name    | Description  |
| ------- | ------------ |
| Blur()  | remove focus |
| Focus() | get focus    |