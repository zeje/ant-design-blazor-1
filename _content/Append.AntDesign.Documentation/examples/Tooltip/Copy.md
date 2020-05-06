@inject IClipboardService Clipboard
<Codebox Title="Copy" id="components-tooltip-demo-copy">
    <Description>
        <p>A more advanced concept to copy code, which uses the <code>IClipboardService</code> to copy text.</p>
    </Description>
    <Demo>
        <Tooltip>
            <Title>@text</Title>
            <ChildContent>
                <Button OnClick="CopyCode">
                    @if (text.Equals("Copy"))
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
    string text = "Copy";
    private async Task CopyCode()
    {
        await Clipboard.Copy("Your code to copy!");
        text = "Copied!";
        StateHasChanged();
        await Task.Delay(3000);
        ResetTooltip();
    }
    private void ResetTooltip()
    {
        text = "Copy";
    }
}