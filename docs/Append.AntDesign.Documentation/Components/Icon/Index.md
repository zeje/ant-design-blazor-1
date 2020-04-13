All icons are **S**emantic **V**ector **G**raphics. There is no need to install them since they are contained in the package.

## About SVG Icons
Using SVG icons has has the following benefits:

- Complete offline usage of icons, without dependency on a CDN-hosted font icon file (No more empty square during downloading and no need to deploy icon font files locally either!)
- Much more display accuracy on lower-resolution screens
- The ability to choose icon color

## Themes
There are 3 themes you can choose from:
- Filled
- Outlined
- TwoTone

## API

| Property | Description | Type | Default | Version |
| --- | --- | --- | --- | --- |
| Width | The width of the `svg` element | `string` | '1em' |  |
| Height | The height of the `svg` element | `string` | '1em' |  |
| Fill | Define the color used to paint the `svg` element | `string` | 'currentColor' |  |
| Class | className of the `svg` element  | `string` | - |  |
| Style | Style properties of icon, like `fontSize` and `color` | CSSProperties | - |  |
| Spin | Rotates the icon with a spinnig animation | boolean | false |  |
| Rotate | Rotate by n degrees (not working in IE9) | number | - |  |
| PrimaryColor | Only supports the two-tone icon. Specifies the primary color. | `string` (hex color) | - |  |
| SecondaryColor | Only supports the two-tone icon. Specifies the secondary color. | `string` (hex color) | - |  |

## File Size
By default **all** the icons are present as `.svg` files in the `_content/Append.AntDesign.Components/icons` folder. 
However it's possible you don't need all these icons since it can drastically increase the download size of your application.
After you published your app, can you delete the icon files you're not using thus reducing the download size. 
Typically these files are located at the following location `[yourapplocation]\bin\Release\netcoreapp3.1\publish\wwwroot\_content\Append.AntDesign.Components\icons`


