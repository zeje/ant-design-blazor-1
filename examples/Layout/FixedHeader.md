<Codebox Title="Fixed Header">
    <Description>
        <p>
            Fixed Header is generally used to fix the top navigation to facilitate page switching.
        </p>
    </Description>
    <Demo>
        <BrowserMockup style="height:360px;overflow:auto;" WithUrl>
            <Layout>
                @* For demo purposes it's a sticky, but you can use `fixed` as well. *@
                <Header style="position: sticky;z-index: 1; width: 100%;top:0">
                    <div class="logo" />
                    <Menu Theme="MenuTheme.Dark" Mode="MenuMode.Horizontal" DefaultSelectedItems="@( new[] {"2"})">
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
                    <div style="background:#fff;padding:24px;min-height:280px">Content</div>
                </Content>
                <Footer style="text-align:center">Ant Design ©2018 Created by Ant UED</Footer>
            </Layout>
        </BrowserMockup>
    </Demo>
</Codebox>

<style>
    #components-layout-demo-fixedheader .logo {
        width: 120px;
        height: 31px;
        background: rgba(255, 255, 255, 0.2);
        margin: 16px 24px 16px 0;
        float: left;
    }
</style>

