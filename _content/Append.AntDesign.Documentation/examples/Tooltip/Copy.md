@inject IClipboardService Service
<Codebox Title="Copy" id="components-tooltip-demo-copy">
    <Description>
        <p>A more advanced concept to copy code, which uses the <code>IClipboardService</code> to copy text.</p>
    </Description>
    <Demo>
        <Tooltip Visible="@visible" OnVisibilityChanged="HandleVisibilityChanged">
            <Title>@text</Title>
            <ChildContent>
                <Button OnClick="CopyCode">
                    @if (text.Equals("Copy code"))
                    {
                        <Icon Type="IconType.Outlined.Copy" />
                    }
                    else
                    {
                        <Icon Type="IconType.Outlined.Check" Fill="green" />
                    }
                </Button>
            </ChildContent>
        </Tooltip>
    </Demo>
</Codebox>

@code{
    string text = "Copy code";
    bool visible = false;
    public async Task CopyCode()
    {
        await Service.Copy("Your code to copy!");
        text = "Copied!";
    }
    public void HandleVisibilityChanged(bool newVisibility)
    {
        visible = newVisibility;
        if (!visible)
            text = "Copy code";
    }
}