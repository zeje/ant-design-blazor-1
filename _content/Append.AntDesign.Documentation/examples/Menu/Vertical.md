<Codebox Title="Vertical" id="components-menu-vertical">
    <Description>
        <p>
            A vertical menu with pop-ups on the side, we advise to use the other <code>Inline</code> mode for optimal user experience.
        </p>
    </Description>
    <Demo>
        <Menu Mode="MenuMode.Vertical" style="width:256px;">
            <SubMenu Key="sub1">
                <Title>
                    <Icon Type="IconType.Outlined.Mail" />
                    <span>Navigation One</span>
                </Title>
                <Children>
                    <MenuItemGroup>
                        <Title>Item 1</Title>
                        <Children>
                            <MenuItem Key="setting:1">Option 1</MenuItem>
                            <MenuItem Key="setting:2">Option 2</MenuItem>
                        </Children>
                    </MenuItemGroup>
                    <MenuItemGroup>
                        <Title>Item 2</Title>
                        <Children>
                            <MenuItem Key="setting:3">Option 3</MenuItem>
                            <MenuItem Key="setting:4">Option 4</MenuItem>
                        </Children>
                    </MenuItemGroup>
                </Children>
            </SubMenu>
            <SubMenu Key="sub2">
                <Title>
                    <Icon Type="IconType.Outlined.Appstore" />
                    <span>Navigation Two</span>
                </Title>
                <Children>
                    <MenuItem Key="setting:5">Option 5</MenuItem>
                    <MenuItem Key="setting:6">Option 6</MenuItem>
                    <SubMenu Key="sub2">
                        <Title><span>Submenu</span></Title>
                        <Children>
                            <MenuItem Key="7">Option 7</MenuItem>
                            <MenuItem Key="8">Option 8</MenuItem>
                        </Children>
                    </SubMenu>
                </Children>
            </SubMenu>
            <SubMenu Key="sub3">
                <Title>
                    <Icon Type="IconType.Outlined.Setting" />
                    <span>Navigation Three</span>
                </Title>
                <Children>
                    <MenuItem Key="setting:9">Option 9</MenuItem>
                    <MenuItem Key="setting:10">Option 10</MenuItem>
                    <MenuItem Key="setting:11">Option 11</MenuItem>
                    <MenuItem Key="setting:12">Option 12</MenuItem>
                </Children>
            </SubMenu>
        </Menu>
    </Demo>
</Codebox>