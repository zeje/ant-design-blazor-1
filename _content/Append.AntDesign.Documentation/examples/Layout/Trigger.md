<Codebox Title="Custom Trigger">
    <Description>
        <p>
            If you want to use a customized <code>Trigger</code>, you can hide the default one by setting <code>ShowTrigger="false"</code>.
        </p>

    </Description>
    <Demo>
        <BrowserMockup style="height:360px;overflow:auto;" WithUrl>
            <Layout>
                <Sider Collapsible="false" Collapsed=isCollapsed>
                    <div class="logo" />
                    <Menu Theme="MenuTheme.Dark" Mode="@MenuMode.Inline" DefaultSelectedItems="@(new[] { "1"})">
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
                    </Menu>
                </Sider>
                <Layout>
                    <Header style="background:#fff;padding:8px">
                        <Button OnClick="Toggle">
                            <Icon Type="@(isCollapsed ? IconType.Outlined.Menu_Unfold : IconType.Outlined.Menu_Fold)" />
                        </Button>
                    </Header>
                    <Content style="margin:24px 16px;padding:24px;min-height:280px;background:#fff">
                        Content
                    </Content>
                </Layout>
            </Layout>
        </BrowserMockup>
    </Demo>
</Codebox>

@code{
    private bool isCollapsed;
    private void Toggle()
    {
        isCollapsed = !isCollapsed;
    }

    protected override void OnAfterRender(bool firstRender)
    {
        base.OnAfterRender(firstRender);
    }

}

<style>
    #components-layout-demo-trigger .trigger {
        font-size: 18px;
        line-height: 64px;
        padding: 0 24px;
        cursor: pointer;
        transition: color 0.3s;
    }

    #components-layout-demo-trigger .logo {
        height: 32px;
        background: rgba(255, 255, 255, 0.2);
        margin: 16px;
    }
</style>