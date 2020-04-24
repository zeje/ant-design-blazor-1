<Codebox Title="Sider">
    <Description>
        <p>
            Two-columns layout. The sider menu can be collapsed when horizontal space is limited.
        </p>
        <p>
            Generally, the mainnav is placed on the left side of the page, and the secondary menu is placed on the top of the working area. Contents will adapt the layout to the viewing area to improve the horizontal space usage, while the layout of the whole page is not stable.
        </p>
        <p>
            The level of the aside navigation is scalable. The first, second, and third level navigations could be present more fluently and relevantly, and aside navigation can be fixed, allowing the user to quickly switch and spot the current position, improving the user experience. However, this navigation occupies some horizontal space of the contents
        </p>
    </Description>
    <Demo>
        <BrowserMockup style="height:360px;overflow:auto;" WithUrl>
            <Layout style="min-height:100vh">
                <Sider Collapsible Collapsed="isCollapsed" OnCollapse="HandleCollapsed">
                    <div class="logo" />
                    <Menu Theme="MenuTheme.Dark" DefaultSelectedItems="@(new[] { "1"})" Mode="MenuMode.Inline">
                        <MenuItem Key="1">
                            <Icon Type="IconType.Outlined.Pie_Chart" />
                            <span>Option 1</span>
                        </MenuItem>
                        <MenuItem Key="2">
                            <Icon Type="IconType.Outlined.Desktop" />
                            <span>Option 2</span>
                        </MenuItem>
                        <SubMenu Key="sub1">
                            <Title>
                                <Icon Type="IconType.Outlined.User" />
                                <span>User</span>
                            </Title>
                            <Children>
                                <MenuItem Key="3">Tom</MenuItem>
                                <MenuItem Key="4">Bill</MenuItem>
                                <MenuItem Key="5">Alex</MenuItem>
                            </Children>
                        </SubMenu>
                        <SubMenu Key="sub2">
                            <Title>
                                <Icon Type="IconType.Outlined.Team" />
                                <span>Team</span>
                            </Title>
                            <Children>
                                <MenuItem Key="6">Team 1</MenuItem>
                                <MenuItem Key="7">Team 2</MenuItem>
                            </Children>
                        </SubMenu>
                        <MenuItem Key="8">
                            <Icon Type="IconType.Outlined.File" />
                            <span>Files</span>
                        </MenuItem>
                    </Menu>
                </Sider>
                <Layout>
                    <Header style="padding: 0;background:#fff" />
                    <Content style="margin: 0 16px">
                        <Breadcrumb style="margin: 16px 0">
                            <BreadcrumbItem>User</BreadcrumbItem>
                            <BreadcrumbItem>Bill</BreadcrumbItem>
                        </Breadcrumb>
                        <div style="padding: 24px; min-height: 360px">
                            Bill is a <strong>cool</strong> cat.
                        </div>
                    </Content>
                    <Footer style="text-align:center">Ant Design ©2018 Created by Ant UED</Footer>
                </Layout>
            </Layout>
        </BrowserMockup>
    </Demo>
</Codebox>
@code{
    private bool isCollapsed = false;
    private void HandleCollapsed(bool newState)
    {
        Console.WriteLine($"New state is : {(newState ? "closed" : "open")}");
    }
}

<style>
    #components-layout-demo-siderhidden .logo {
        height: 32px;
        background: rgba(255, 255, 255, 0.2);
        margin: 16px;
    }

    #components-layout-demo-siderhidden .ant-layout-sider-trigger {
        /* Else the nav trigger will move with the entire page...*/
        position: sticky;
    }
</style>
