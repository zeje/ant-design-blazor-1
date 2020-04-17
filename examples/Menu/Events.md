@using System.Text.Json
@using System.Text.Json.Serialization;

<Codebox Title="Events" id="components-menu-events">
    <Description>
        <p>
            There are multiple events you can act upon:
        </p>
        <ul>
            <li>Individual <code>@nameof(MenuItem)</code> - <code>@nameof(MenuItem.OnClicked)</code> </li>
            <li>Individual <code>@nameof(SubMenu)</code> - <code>@nameof(SubMenu.OnTitleClicked)</code> </li>
            <li>Any <code>@nameof(MenuItem)</code> in the <code>@nameof(Menu)</code> - <code>@nameof(Menu.OnMenuItemClicked)</code> </li>
            <li>Any <code>@nameof(SubMenu)</code> in the <code>@nameof(Menu)</code> - <code>@nameof(Menu.OnSubmenuClicked)</code> </li>
        </ul>
    </Description>
    <Demo>
        <Menu OnMenuItemClicked="HandleOnMenuItemClicked" OnSubmenuClicked="HandleOnSubMenuOpenChanged">
            <MenuItem Key="1" OnClicked="HandleMenuItem1Clicked">Option 1</MenuItem>
            <MenuItem Key="2">Option 2</MenuItem>
            <SubMenu Key="sub1">
                <Title>
                    <Icon Type="IconType.Outlined.Mail" />
                    <span>Navigation One</span>
                </Title>
                <Children>
                    <MenuItem Key="3">Option 3</MenuItem>
                    <MenuItem Key="4">Option 4</MenuItem>
                </Children>
            </SubMenu>
            <SubMenu Key="sub2" OnTitleClicked="HandleSubMenu2Clicked">
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
        </Menu>
        <Divider Label="Performed Actions" />
        @foreach (var message in messages)
        {
            <p>@message</p>
        }
    </Demo>
</Codebox>

@code{
    private List<string> messages = new List<string>();
    /// <summary>
    /// Default example for non-asynchronize calls.
    /// </summary>
    /// <param name="item"></param>
    private void HandleOnMenuItemClicked(MenuItem item)
    {
        var state = item.IsSelected ? "selected" : "deselected";
        messages.Add($"{nameof(Menu)} - You clicked on menuitem with key: {item.Key}, it's now {state}");
        StateHasChanged();
    }
    /// <summary>
    /// Task example for asynchronize calls
    /// </summary>
    /// <param name="menu"></param>
    /// <returns></returns>
    private async Task HandleOnSubMenuOpenChanged(SubMenu menu)
    {
        await Task.Delay(100);
        var state = menu.IsOpen ? "open" : "closed";
        messages.Add($"{nameof(Menu)} - You changed the open state of {nameof(SubMenu)} with key: {menu.Key}, it's now {state}");
    }
    /// <summary>
    /// Separate menu item clicks are available.
    /// </summary>
    /// <param name="item"></param>
    private Task HandleMenuItem1Clicked(MouseEventArgs args)
    {
        messages.Add($"{nameof(MenuItem)} - You clicked the first {nameof(MenuItem)}, the {nameof(MouseEventArgs)} are {RepresentAsJson(args)}");
        return Task.CompletedTask;
    }
    /// <summary>
    /// Separate menu item clicks are available.
    /// </summary>
    /// <param name="item"></param>
    private Task HandleSubMenu2Clicked(MouseEventArgs args)
    {
        messages.Add($"{nameof(SubMenu)} - You clicked the second {nameof(SubMenu)}, the {nameof(MouseEventArgs)} are {RepresentAsJson(args)}");
        return Task.CompletedTask;
    }

    private string RepresentAsJson(MouseEventArgs args)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };
        return JsonSerializer.Serialize(args,options);

    }
}