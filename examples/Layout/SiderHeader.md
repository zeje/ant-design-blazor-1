<Codebox Title="Header Sider">
    <Description>
        <p>
            Both the top navigation and the sidebar, commonly used in documentation sites.
        </p>
    </Description>
    <Demo>
        <Layout>
            <Header class="header">
                <div class="logo" />
                <Menu Theme="MenuTheme.Dark" Mode="MenuMode.Horizontal" DefaultSelectedItems="@(new[] {"2"})">
                    <MenuItem Key="1">nav 1</MenuItem>
                    <MenuItem Key="2">nav 2</MenuItem>
                    <MenuItem Key="3">nav 3</MenuItem>
                </Menu>
            </Header>
            <Content style="padding: 0 50px">
                    <Breadcrumb style="margin: 16px 0">
                        <BreadcrumbItem>Home</BreadcrumbItem>
                        <BreadcrumbItem>List</BreadcrumbItem>
                        <BreadcrumbItem>App</BreadcrumbItem>
                    </Breadcrumb>
                <Layout style="padding: 24px 0;background:#fff">
                    <Sider style="background:#fff">
                        <Menu Mode="MenuMode.Inline"
                              DefaultSelectedItems="@(new[] {"1"})"
                              DefaultOpenSubMenus="@(new[] {"sub1"})"
                              style="height:100%;">
                            <SubMenu Key="sub1">
                                <Title>
                                    <Icon Type="IconType.Outlined.User" />
                                    <span>subnav 1</span>
                                </Title>
                                <Children>
                                    <MenuItem Key="1">option1</MenuItem>
                                    <MenuItem Key="2">option2</MenuItem>
                                    <MenuItem Key="3">option3</MenuItem>
                                    <MenuItem Key="4">option4</MenuItem>
                                </Children>
                            </SubMenu>
                            <SubMenu Key="sub2">
                                <Title>
                                    <Icon Type="IconType.Outlined.Laptop" />
                                    <span>subnav 2</span>
                                </Title>
                                <Children>
                                    <MenuItem key="5">option5</MenuItem>
                                    <MenuItem key="6">option6</MenuItem>
                                    <MenuItem key="7">option7</MenuItem>
                                    <MenuItem key="8">option8</MenuItem>
                                </Children>
                            </SubMenu>
                            <SubMenu key="sub3">
                                <Title>
                                    <Icon Type="IconType.Outlined.Notification" />
                                    <span>subnav 3</span>
                                </Title>
                                <Children>
                                    <MenuItem key="9">option9</MenuItem>
                                    <MenuItem key="10">option10</MenuItem>
                                    <MenuItem key="11">option11</MenuItem>
                                    <MenuItem key="12">option12</MenuItem>
                                </Children>
                            </SubMenu>
                        </Menu>
                    </Sider>
                    <Content style="padding: 0 24px; min-height: 280px">Content</Content>
                </Layout>
            </Content>
            <Footer style="text-align:center;">Ant Design ©2018 Created by Ant UED</Footer>
        </Layout>
    </Demo>
</Codebox>

<style>
    #components-layout-demo-siderheader .logo {
        width: 120px;
        height: 31px;
        background: rgba(255, 255, 255, 0.2);
        margin: 16px 28px 16px 0;
        float: left;
    }
</style>
