`Steps` is a navigation bar that guides users through the steps of a task.

## When To Use

When a given task is complicated or has a certain sequence in the series of subtasks, we can decompose it into several steps to make things easier.

## API

```jsx
<Steps>
  <Step title="first step" />
  <Step title="second step" />
  <Step title="third step" />
</Steps>
```

### Steps

The whole of the step bar.

| Property | Description | Type | Default | Version |
| --- | --- | --- | --- | --- |
| ClassName | Additional class to Steps | string | - |  |
| Type | Type of steps, can be set to one of the following values: `StepsType.Default`, `StepsType.Navigation` | StepsType | `StepsType.Default` |  |
| Current | To set the current step, counting from 0. You can overwrite this state by using `status` of `Step` | number | 0 |  |
| Direction | To specify the direction of the step bar, `StepsDirection.Horizontal` or `StepsDirection.Vertical` | StepsDirection | `StepsDirection.Horizontal` |  |
| LabelPlacement | Place title and description with `StepsDirection.Horizontal` or `StepsDirection.Vertical` direction | StepsDirection |  `StepsDirection.Horizontal` |  |
| ProgressDot | Steps with progress dot style, customize the progress dot by setting it to a function. labelPlacement will be `vertical` | Boolean or RenderFragment | false |  |
| Size | To specify the size of the step bar, `StepsSize.Default` and `StepsSize.Small` are currently supported | StepsSize | `StepsSize.Default` |  |
| Status | To specify the status of current step, can be set to one of the following values: `StepsStatus.Wait` `StepsStatus.Process` `StepsStatus.Finish` `StepsStatus.Error` | StepsStatus | `StepsStatus.Process` |  |
| Initial | Set the initial step, counting from 0 | number | 0 |  |
| OnChange | Trigger when Step is changed | Action<int> | - |  |

### Steps.Step

A single step in the step bar.

| Property | Description | Type | Default | Version |
| --- | --- | --- | --- | --- |
| Description | Description of the step, optional property | string | - |  |
| Icon | Icon of the step, optional property | IconType | - |  |
| Status | To specify the status. It will be automatically set by `current` of `Steps` if not configured. Optional values are: `StepsStatus.Wait` `StepsStatus.Process` `StepsStatus.Finish` `StepsStatus.Error` | StepsStatus | `StepsStatus.wait` |  |
| Title | Title of the step | string | - |  |
| SubTitle | Subtitle of the step | string | - |  |
| Disabled | Disable click | bool | false |  |