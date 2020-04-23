A breadcrumb displays the current location within a hierarchy. It allows going back to states higher up in the hierarchy.

## When To Use

- When the system has more than two layers in a hierarchy.
- When you need to inform the user of where they are.
- When the user may need to navigate back to a higher level.

## API

### Breadcrumb

| Property | Description | Type | Default | Version |
| --- | --- | --- | --- | --- |
| Separator | Custom separator | string | '/' |  |

### BreadcrumbItem

| Property | Description | Type | Default | Version |
| --- | --- | --- | --- | --- |
| Href | Target of hyperlink | string | - |  |
| OnClick | Set the handler to handle `click` event | (e:MouseEvent)=>void | - |  |
