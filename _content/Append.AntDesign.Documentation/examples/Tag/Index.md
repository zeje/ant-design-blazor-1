Tag for categorizing or markup.

## When To Use

- It can be used to tag by dimension or property.

- When categorizing.

## API

### Tag

| Property | Description | Type | Default |
| --- | --- | --- | --- |
| Color | Color of the Tag | string | - |
| ChildContent | Set the content of the tag | RenderFragment | - |  |
| Closable | Whether the Tag can be closed | bool | `false` |
| Visible | Whether the Tag is closed or not | bool | `true` |
| OnClose | Callback executed when tag is closed | `Callback<bool>` | - |


### CheckableTag

| Property | Description                                     | Type              | Default |
| -------- | ----------------------------------------------- | ----------------- | ------- |
| Color | Color of the Tag | string | - |
| ChildContent | Set the content of the tag | RenderFragment | - |  |
| Checked  | Checked status of Tag                           | bool           | `false` |
| OnChange | Callback executed when Tag is checked/unchecked | `Callback<bool>` | -       |

