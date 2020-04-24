Handling the overall layout of a page.

## Specification

### Size

The first level navigation is left aligned near a logo, and the secondary menu is right aligned.

- Top Navigation: the height of the first level navigation `64px`, the second level navigation `48px`.
- Top Navigation (for landing pages): the height of the first level navigation `80px`, the second level navigation `56px`.
- Calculation formula of a top navigation: `48+8n`.
- Calculation formula of an aside navigation: `200+8n`.

### Interaction rules

- The first level navigation and the last level navigation should be distinguishable by visualization;
- The current item should have the highest priority of visualization;
- When the current navigation item is collapsed, the style of the current navigation item is applied to its parent level;
- The left side navigation bar has support for both the accordion and expanding styles; you can choose the one that fits your case the best.

## Visualization rules

Style of a navigation should conform to its level.

- **Emphasis by colorblock**

  When background color is a deep color, you can use this pattern for the parent level navigation item of the current page.

- **The highlight match stick**

  When background color is a light color, you can use this pattern for the current page navigation item; we recommend using it for the last item of the navigation path.

- **Highlighted font**

  From the visualization aspect, a highlighted font is stronger than colorblock; this pattern is often used for the parent level of the current item.

- **Enlarge the size of the font**

  `12px`, `14px` is a standard font size of navigations, `14px` is used for the first and the second level of the navigation. You can choose an appropriate font size regarding the level of your navigation.

## Component Overview

- `Layout`: The layout wrapper, in which `Header` `Sider` `Content` `Footer` or `Layout` itself can be nested, and can be placed in any parent container.
- `Header`: The top layout with the default style, in which any element can be nested, and must be placed in `Layout`.
- `Sider`: The sidebar with default style and basic functions, in which any element can be nested, and must be placed in `Layout`.
- `Content`: The content layout with the default style, in which any element can be nested, and must be placed in `Layout`.
- `Footer`: The bottom layout with the default style, in which any element can be nested, and must be placed in `Layout`.

> Based on `flex layout`, please pay attention to the [compatibility](http://caniuse.com/#search=flex).

## API

```jsx
<Layout>
  <Header>header</Header>
  <Layout>
    <Sider>left sidebar</Sider>
    <Content>main content</Content>
    <Sider>right sidebar</Sider>
  </Layout>
  <Footer>footer</Footer>
</Layout>
```

### Layout, Header, Content, Footer

Have no parameters.

### Sider

The sidebar.

| Property | Description | Type | Default |
| --- | --- | --- | --- |
| Breakpoint | breakpoints of the responsive layout | Sider.Breakpoint | - |
| Collapsed | to set the current status | boolean | - |
| CollapsedWidth | width of the collapsed sidebar, by setting to `0` a special trigger will appear | int | 80 |
| Collapsible | toggle to show a Trigger to open/close the sider | boolean | false |
| Theme | color theme of the sidebar | SiderTheme | SiderTheme.Dark |
| Trigger | specify the customized trigger| RenderFragment | - |
| Width | width of the sidebar | int | 200 |
| OnCollapse | the callback function, executed by clicking the trigger or activating the responsive layout | (collapsed, type) => {} | - |

#### breakpoint width

```js
{
  Xs: '480px',
  Sm: '576px',
  Md: '768px',
  Lg: '992px',
  Xl: '1200px',
  Xxl: '1600px',
}
```

<style>
  [data-theme="dark"] .site-layout-background {
    background: #141414;
  }
  [data-theme="dark"] .site-layout-header-background {
    background: #1f1f1f;
  }
</style>
