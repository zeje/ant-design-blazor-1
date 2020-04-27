@inject IClipboardService Clipboard
<Codebox Title="Copy" id="components-tooltip-demo-copy">
    <Description>
        <p>A more advanced concept to copy code, which uses the <code>IClipboardService</code> to copy text.</p>
    </Description>
    <Demo>
        <Tooltip Visible="@visible" VisibleChanged="HandleVisibilityChanged">
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
    private async Task CopyCode()
    {
        await Clipboard.Copy("Your code to copy!");
        text = "Copied!";
    }
    private void HandleVisibilityChanged(bool newVisibility)
    {
        visible = newVisibility;
        ResetTooltip();
    }
    private void ResetTooltip()
    {
        if (!visible)
            text = "Copy code";
    }
}