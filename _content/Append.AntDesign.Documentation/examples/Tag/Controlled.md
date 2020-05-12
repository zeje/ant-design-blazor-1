<Codebox Title="Controlled">
    <Description>
        <p>
            By using the <code>Visible</code> property, you can control the close state of Tag.
        </p>
    </Description>
    <Demo>
        <Tag Closable Visible="_state" OnClose="() => _state = false">
            Movies
        </Tag>
        <br />
        <br />
        <Button OnClick="ToggleState" Label="Toggle"></Button>
    </Demo>
</Codebox>
@code{
    private bool _state = true;
    private void ToggleState()
    {
        _state = !_state;
    }
}