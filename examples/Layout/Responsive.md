<Codebox Title="Responsive">
    <Description>
        <p>Layout.Sider supports responsive layout.</p>
        <blockquote><p>Note: You can get a responsive layout by setting <code>Breakpoint</code>, the Sider will collapse to the width of <code>CollapsedWidth</code> when window width is below the <code>Breakpoint</code>. And a special trigger will appear if the <code>CollapsedWidth</code> is set to <code>0</code>.</p></blockquote>
    </Description>
    <Demo>
        <Layout>
            <Sider Breakpoint="BreakpointType.Md" Collapsible
                   CollapsedWidth="0">
                <div class="logo" />
                <Menu Theme="MenuTheme.Dark" Mode="MenuMode.Inline" DefaultSelectedItems="@(new[] { "4"})">
                    <MenuItem Key="1">
                        <Icon Type="IconType.Outlined.User" />
                        <span>nav 1</span>
                    </MenuItem>
                    <MenuItem Key="2">
                        <Icon Type="IconType.Outlined.Video_Camera" />
                        <span>nav 2</span>
                    </MenuItem>
                    <MenuItem Key="3">
                        <Icon Type="IconType.Outlined.Upload" />
                        <span>nav 3</span>
                    </MenuItem>
                    <MenuItem Key="4">
                        <Icon Type="IconType.Outlined.User" />
                        <span>nav 4</span>
                    </MenuItem>
                </Menu>
            </Sider>
            <Layout>
                <Header style="padding: 0;background:#fff" />
                <Content style="margin: 24px 16px 0">
                    <div style="padding: 24px; min-height: 360px ">
                        content
                    </div>
                </Content>
                <Footer style="text-align:center">Ant Design ©2018 Created by Ant UED</Footer>
            </Layout>
        </Layout>
    </Demo>
</Codebox>

<style>
    #components-layout-demo-responsive .logo {
        height: 32px;
        background: rgba(255, 255, 255, 0.2);
        margin: 16px;
    }
    #components-layout-demo-responsive .ant-layout-sider-trigger{
        position:sticky;
    }
</style>