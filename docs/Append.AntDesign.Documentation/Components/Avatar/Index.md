Avatars can be used to represent people or objects. It supports images, `Icon`s, or letters.

## API

| Property | Description | Type | Default | Version |
| --- | --- | --- | --- | --- |
| Icon | Icon for an icon avatar | IconType | - |  |
| ChildContent | custom text you want to show | RenderFragment | - |  |
| Shape | the shape of avatar | AvatarShape | `AvatarShape.Circle` |  |
| Size | the size of the avatar | Size | Size.Medium |  |
| ImageSource | the address/path of the image for an image avatar | string | - |  |
| ImageSourceSet | a list of sources to use for different screen resolutions | string | - |  |
| ImageAlt | defines the alternative text describing the image | string | - |  |
| OnImageLoadError | handler when img load error, return false to prevent default fallback behavior | EventCallback | - |  |

> Note that you have to choose one of the following:
> - Icon
> - ImageSource
> - ChildContent