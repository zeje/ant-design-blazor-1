A spinner for displaying loading state of a page or a section.

## When To Use

When part of the page is waiting for asynchronous data or during a rendering process, an appropriate loading animation can effectively alleviate users' inquietude.

## API

| Property | Description | Type | Default Value |
| --- | --- | --- | --- |
<!--| delay | specifies a delay in milliseconds for loading state (prevent flush) | number (milliseconds) | - |
| indicator | React node of the spinning indicator | ReactNode | - | -->
| Size | size of Spin, options: `Small`, `Default` and `Large` | Size | `Size.Default` |
| Spinning | whether Spin is spinning | boolean | true |
| Label | customize description content when Spin has children | string | - |

<!--
### Static Method

- `Spin.setDefaultIndicator(indicator: ReactNode)`

  You can define default spin element globally.
-->