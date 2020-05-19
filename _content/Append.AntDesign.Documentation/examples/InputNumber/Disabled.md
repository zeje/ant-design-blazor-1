<Codebox Title="Disabled">
    <Description>
        <p>
            Click the button to toggle between available and disabled states.
        </p>
    </Description>
    <Demo>
        <div>
            <InputNumber Min=1 Max=10 Disabled=@disabled DefaultValue=3 />
            <div style="margin-top: 20px;">
                <Button OnClick="Toggle" Type=@ButtonType.Primary Label="Toggle disabled"/>
            </div>
        </div>
    </Demo>
</Codebox>

@code{
    public bool disabled = true;

    public void Toggle()
    {
        disabled = !disabled;
    }
}