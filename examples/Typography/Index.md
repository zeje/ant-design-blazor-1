Basic text writing, including headings, body text, lists, and more.

## When To Use

- When need to display a title or paragraph contents in Articles/Blogs/Notes.
- When you need copyable/editable/ellipsis texts.

## API

### Typography.Text

| Property | Description | Type | Default | Version |
| --- | --- | --- | --- | --- |
| Code | Code style | Boolean | false |  |
| Delete | Deleted line style | Boolean | false |  |
| Disabled | Disabled content | Boolean | false |  |
| Mark | Marked style | Boolean | false |  |
| Underline | Underlined style | Boolean | false |  |
| Strong | Bold style | Boolean | false |  |
| Type | Content type | TypographyType | TypographyType.Default |  |
| Copyable | Config copy. Must set copy text | Boolean | false |  |
| TextToCopy | The text that can be copied when copyable | string | | |

<!--| Editable | Editable. Can control edit state when is object | Boolean \| { editing: Boolean, onStart: Function, onChange: Function(string) } | false |  |
| Ellipsis | Display ellipsis when text overflows | Boolean | false |  |
| OnChange | Trigger when user edits the content | Function(string) | - |  |-->

### Typography.Title

| Property | Description | Type | Default | Version |
| --- | --- | --- | --- | --- |
| Code | Code style | Boolean | false |  |
| Delete | Deleted line style | Boolean | false |  |
| Disabled | Disabled content | Boolean | false |  |
| Level | Set content importance. Match with `h1`, `h2`, `h3`, `h4` | TypographyTitleLevel | TypographyTitleLevel.H1 |  |
| Mark | Marked style | Boolean | false |  |
| Underline | Underlined style | Boolean | false |  |
| Type | Content type | TypographyType | TypographyType.Default |  |
| Copyable | Config copy. Must set copy text | Boolean | false |  |
| TextToCopy | The text that can be copied when copyable | string | | |

<!--| OnChange | Trigger when user edits the content | Function(string) | - |  |
| Editable | Editable. Can control edit state when is object | Boolean \| { editing: Boolean, onStart: Function, onChange: Function(string) } | false |  |
| Ellipsis | Display ellipsis when text overflows. Can configure rows and expandable by using object | Boolean \| { rows: number, expandable: Boolean, onExpand: Function(event), onEllipsis: Function(ellipsis) } | false | onEllipsis: 4.2.0 |-->

### Typography.Paragraph

| Property | Description | Type | Default | Version |
| --- | --- | --- | --- | --- |
| Code | Code style | Boolean | false |  |
| Delete | Deleted line style | Boolean | false |  |
| Disabled | Disabled content | Boolean | false |  |
| Mark | Marked style | Boolean | false |  |
| Underline | Underlined style | Boolean | false |  |
| Strong | Bold style | Boolean | false |  |
| Type | Content type | TypographyType | TypographyType.Default |  |
| Copyable | Config copy. Must set copy text | Boolean  | false |  |
| TextToCopy | The text that can be copied when copyable | string | | |

<!--| Editable | Editable. Can control edit state when is object | Boolean \| { editing: Boolean, onStart: Function, onChange: Function(string) } | false |  |
| Ellipsis | Display ellipsis when text overflows. Can configure rows expandable and suffix by using object | Boolean \| { rows: number, expandable: Boolean suffix: string, onExpand: Function(event), onEllipsis: Function(ellipsis) } | false | onEllipsis: 4.2.0 |
| OnChange | Trigger when user edits the content | Function(string) | - |  |-->