@using Microsoft.AspNetCore.Components.Routing
<Codebox Title="Navigation" id="components-menu-inline">
    <Description>
        <p>
            <code>NavLink</code> as a first-class citizen, simply wrap the <code>MenuItem</code> with a <code>NavLink</code> and set the <code>Menu</code> to <code>Selectable=false</code>
        </p>
    </Description>
    <Demo>
        <Menu style="width:256px;" Mode="MenuMode.Inline" Selectable="false">
            <NavLink href="/" Match="NavLinkMatch.All">
                <MenuItem Key="Home">

                    <Icon Type="IconType.TwoTone.Home" />
                    <span>Home</span>
                </MenuItem>
            </NavLink>

            <MenuItemGroup>
                <Title>General</Title>
                <Children>
                    <NavLink href="components/Button">
                        <MenuItem Key="Button">
                            <span>Button</span>
                        </MenuItem>
                    </NavLink>
                    <NavLink href="components/Icon">
                        <MenuItem Key="Icons">
                            <span>Icons</span>
                        </MenuItem>
                    </NavLink>
                    <NavLink href="components/Menu">
                        <MenuItem Key="Menu">
                            <span>Menu</span>
                        </MenuItem>
                    </NavLink>
                </Children>
            </MenuItemGroup>
        </Menu>
    </Demo>
</Codebox>