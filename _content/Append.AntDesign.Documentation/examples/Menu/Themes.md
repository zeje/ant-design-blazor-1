<Codebox Title="Themes" id="components-menu-themes">
    <Description>
        <p>
            <code>Dark | Light</code> theme, specifed by the <code>Theme</code> property.
        </p>
    </Description>
    <Demo>
        <div style="display:flex; justify-content:space-around;">
            <div>
                <p>Light</p>
                <Menu Style="width:256px;" Mode="MenuMode.Inline" Theme="MenuTheme.Light">
                    <MenuItem Key="1">
                        <Icon Type="IconType.Outlined.Pie_Chart" />
                        <span>Option 1</span>
                    </MenuItem>
                    <MenuItem Key="2">
                        <Icon Type="IconType.Outlined.Desktop" />
                        <span>Option 2</span>
                    </MenuItem>
                    <MenuItem Key="3">
                        <Icon Type="IconType.Outlined.Container" />
                        <span>Option 3</span>
                    </MenuItem>
                    <SubMenu Key="sub1">
                        <Title>
                            <Icon Type="IconType.Outlined.Mail" />
                            <span>Navigation One</span>
                        </Title>
                        <Children>
                            <MenuItem Key="5">Option 5</MenuItem>
                            <MenuItem Key="6">Option 6</MenuItem>
                            <MenuItem Key="7">Option 7</MenuItem>
                            <MenuItem Key="8">Option 8</MenuItem>
                        </Children>
                    </SubMenu>
                    <SubMenu Key="sub2">
                        <Title>
                            <Icon Type="IconType.Outlined.Appstore" />
                            <span>Navigation Two</span>
                        </Title>
                        <Children>
                            <MenuItem Key="9">Option 9</MenuItem>
                            <MenuItem Key="10">Option 10</MenuItem>
                            <SubMenu Key="sub3">
                                <Title>Submenu</Title>
                                <Children>
                                    <MenuItem Key="11">Option 11</MenuItem>
                                    <MenuItem Key="12">Option 12</MenuItem>
                                </Children>
                            </SubMenu>
                        </Children>
                    </SubMenu>
                </Menu>
            </div>
            <div>
                <p>Dark</p>
                <Menu Style="width:256px;" Mode="MenuMode.Inline" Theme="MenuTheme.Dark">
                    <MenuItem Key="1">
                        <Icon Type="IconType.Outlined.Pie_Chart" />
                        <span>Option 1</span>
                    </MenuItem>
                    <MenuItem Key="2">
                        <Icon Type="IconType.Outlined.Desktop" />
                        <span>Option 2</span>
                    </MenuItem>
                    <MenuItem Key="3">
                        <Icon Type="IconType.Outlined.Container" />
                        <span>Option 3</span>
                    </MenuItem>
                    <SubMenu Key="sub1">
                        <Title>
                            <Icon Type="IconType.Outlined.Mail" />
                            <span>Navigation One</span>
                        </Title>
                        <Children>
                            <MenuItem Key="5">Option 5</MenuItem>
                            <MenuItem Key="6">Option 6</MenuItem>
                            <MenuItem Key="7">Option 7</MenuItem>
                            <MenuItem Key="8">Option 8</MenuItem>
                        </Children>
                    </SubMenu>
                    <SubMenu Key="sub2">
                        <Title>
                            <Icon Type="IconType.Outlined.Appstore" />
                            <span>Navigation Two</span>
                        </Title>
                        <Children>
                            <MenuItem Key="9">Option 9</MenuItem>
                            <MenuItem Key="10">Option 10</MenuItem>
                            <SubMenu Key="sub3">
                                <Title>Submenu</Title>
                                <Children>
                                    <MenuItem Key="11">Option 11</MenuItem>
                                    <MenuItem Key="12">Option 12</MenuItem>
                                </Children>
                            </SubMenu>
                        </Children>
                    </SubMenu>
                </Menu>
            </div>
        </div>
    </Demo>
</Codebox>