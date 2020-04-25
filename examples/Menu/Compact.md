<Codebox Title="Compact" id="components-menu-compact">
    <Description>
        <p>
            A <code>Inline</code> <code>Light</code> menu that behaves like an accordion, it will close all other submenus. Click a submenu and you will see that all the other submenus gets collapsed to keep the entire menu compact.
        </p>
    </Description>
    <Demo>
        <Menu style="width:256px;" Mode="MenuMode.Inline" DefaultOpenSubMenus="OpenSubmenus" Accordion >
            <SubMenu Key="sub1">
                <Title>
                    <Icon Type="IconType.Outlined.Mail" />
                    <span>Navigation One</span>
                </Title>
                <Children>
                    <MenuItem Key="1">Option 1</MenuItem>
                    <MenuItem Key="2">Option 2</MenuItem>
                    <MenuItem Key="3">Option 3</MenuItem>
                    <MenuItem Key="4">Option 4</MenuItem>
                </Children>
            </SubMenu>
            <SubMenu Key="sub2">
                <Title>
                    <Icon Type="IconType.Outlined.Appstore" />
                    <span>Navigation Two</span>
                </Title>
                <Children>
                    <MenuItem Key="5"><span>Option 5</span></MenuItem>
                    <MenuItem Key="6">Option 6</MenuItem>
                    <SubMenu Key="sub3">
                        <Title><span>Submenu</span></Title>
                        <Children>
                            <MenuItem Key="7">Option 7</MenuItem>
                            <MenuItem Key="8">Option 8</MenuItem>
                        </Children>
                    </SubMenu>
                </Children>
            </SubMenu>
            <SubMenu Key="sub4">
                <Title>
                    <Icon Type="IconType.Outlined.Setting" />
                    <span>Navigation Three</span>
                </Title>
                <Children>
                    <MenuItem Key="9">Option 9</MenuItem>
                    <MenuItem Key="10">Option 10</MenuItem>
                    <MenuItem Key="11">Option 11</MenuItem>
                    <MenuItem Key="12">Option 12</MenuItem>
                </Children>
            </SubMenu>
        </Menu>
    </Demo>
</Codebox>

@code{
    private string[] OpenSubmenus = { "sub1" };
}