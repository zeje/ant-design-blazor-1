Vertically displayed timeline.

## When To Use

- When a series of information needs to be ordered by time (ascending or descending).
- When you need a timeline to make a visual connection.

## API

```razor
<Timeline>
  <TimelineItem>step1 2015-09-01</TimelineItem>
  <TimelineItem>step2 2015-09-01</TimelineItem>
  <TimelineItem>step3 2015-09-01</TimelineItem>
  <TimelineItem>step4 2015-09-01</TimelineItem>
</Timeline>
```

### Timeline

Timeline

| Property | Description | Type | Default |
| --- | --- | --- | --- |
| Mode | `Left`, `Right` and `Alternate` forces the timeline to render at the position,  The timeline will distribute the nodes to the left and right when it's set to `Alternate` | TimelineMode | TimelineMode.Left |

### Timeline.Item

Node of timeline

| Property | Description | Type | Default |
| --- | --- | --- | --- |
| Color | Set the circle's color to `blue`, `red`, `green`, `gray`. | TimelineColor | `TimelineColor.Blue` |
| Dot | Customize the circle in anything you'd like | RenderFragment | - |
| ChildContent | Markup of the item. | RenderFragment | - |
| Position | Customize the position, by default the `Timeline` will calculate this based on the `TimelineMode` | TimelinePosition | - |
| Label | Set the label | string | - |
