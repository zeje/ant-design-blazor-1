A small numerical value or status description for UI elements.

## When To Use

A `Badge` normally appears in proximity to notifications or user avatars with eye-catching appeal, typically displaying unread messages count.

## API

| Property | Description | Type | Default | Version |
| --- | --- | --- | --- | --- |
| Color | Customize Badge dot color | string |  |  |
| Count | Number to show in badge | int? |  |  |
| Dot | Whether to display a red dot instead of `Count` | boolean | `false` |  |
| Offset | set offset of the badge dot, like`Offset.Create(x, y)` | `Offset` | - |  |
| OverflowCount | Max Count to show | int | 99 |  |
| ShowZero | Whether to show the badge when `Count` is zero | boolean | `false` |  |
| Status | Set Badge as a Status dot, the following options are possible: `BadgeStatus.Success` \| `BadgeStatus.Processing` \| `BadgeStatus.Default` \| `BadgeStatus.Error` \| `BadgeStatus.Warning` | BadgeStatus |  |  |
| Text | If `Status` is set, `Text` sets the display text of the status dot | string |  |  |
| Title | Text to show when hovering over the badge | string |  |  |
| Icon | Icon to show in the Badge | IconType|  |  |
