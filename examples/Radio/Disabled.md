<Codebox Title="Disabled">
    <Description>
        <p>
            The Radio is unavailable.
        </p>
    </Description>
    <Demo>
        <Radio Disabled="_disableRadio">
            Disabled
        </Radio>
        <br />
        <Radio DefaultChecked Disabled="_disableRadio">
            Disabled
        </Radio>
        <Button Type="ButtonType.Primary" OnClick="() => _disableRadio = !_disableRadio" Label="Toggle disabled" style="margin-top:20px" />
    </Demo>
</Codebox>
@code{
    private bool _disableRadio;
}