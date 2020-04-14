A versatile menu for navigation.

## When To Use

Navigation is an important part of any website, as a good navigation setup allows users to move around the site quickly and efficiently. Ant Design offers top and side navigation options. Top navigation provides all the categories and functions of the website. Side navigation provides the multi-level structure of the website.

## API

```razor
<Menu >
    <MenuItem Key="mail">
        <Icon Type="IconType.Outlined.Mail" />
        <span>Navigation One</span>
    </MenuItem>
    <SubMenu Key="sub1">
        <Title>
            <Icon Type="IconType.Outlined.Setting" />
            <span>Navigation Three - Submenu</span>
        </Title>
        <Children>
            <MenuItem Key="setting:1">Option 1</MenuItem>
            <MenuItem Key="setting:2">Option 2</MenuItem>
            <MenuItem Key="setting:3">Option 3</MenuItem>
            <MenuItem Key="setting:4">Option 4</MenuItem>
        </Children>
    </SubMenu>
    <MenuItem Key="antdesign">
        <a href="https://ant.design" target="_blank">
            Navigation Four - Link
        </a>
    </MenuItem>
</Menu>
```

### Menu

| Param | Description | Type | Default value | Version |
| --- | --- | --- | --- | --- |
| defaultOpenKeys | Array with the keys of default opened sub menus | string\[] |  |  |
| defaultSelectedKeys | Array with the keys of default selected menu items | string\[] |  |  |
| inlineCollapsed | Specifies the collapsed status when menu is inline mode | boolean | - |  |
| Mode | Type of menu; `vertical`, `horizontal`, or `inline` | MenuMode | MenuMode.Inline |  |
| selectable | Allows selecting menu items | boolean | true |  |
| Accordion | Closes all non-parents when a submenu is clicked | boolean | false |  |
| Style | Style of the root node | string |  |  |
| Theme | Color theme of the menu | MenuTheme | MenuTheme.Light |  |
| onClick | Called when a menu item is clicked | function({ item, key, keyPath, domEvent }) | - |  |
| onOpenChange | Called when sub-menus are opened or closed | function(openKeys: string\[]) | noop |  |
| onSelect | Called when a menu item is selected | function({ item, key, keyPath, selectedKeys, domEvent }) | none |  |

### MenuItem

| Param    | Description                          | Type    | Default value | Version |
| -------- | ------------------------------------ | ------- | ------------- | ------- |
| Disabled | Whether menu item is disabled        | boolean | false         |         |
| Key      | Unique ID of the menu item           | string  |               |         |
| Title    | Set display title for collapsed item | RenderFragment  |               |         |

### SubMenu

| Param | Description | Type | Default value | Version |
| --- | --- | --- | --- | --- |
| Children | Sub-menus or sub-menu items | RenderFragment |  |  |
| Disabled | Whether sub-menu is disabled | bool | false |  |
| Key | Unique ID of the sub-menu | string |  |  |
| Title | Title of the sub-menu | RenderFragment |  |  |
| OnTitleClick | Callback executed when the sub-menu title is clicked | function({ key, domEvent }) |  |  |

### MenuItemGroup

| Param    | Description        | Type              | Default value | Version |
| -------- | ------------------ | ----------------- | ------------- | ------- |
| Children | sub-menu items     | RenderFragment  |               |         |
| Title    | title of the group | RenderFragment  |               |         |