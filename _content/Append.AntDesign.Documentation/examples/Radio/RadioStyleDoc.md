<Codebox Title="Radio style">
    <Description>
        <p>
            The combination of radio button style.
        </p>
    </Description>
    <Demo>
        <RadioGroup OnChange="@((e) => System.Diagnostics.Debug.WriteLine($"Currently selected radio: {e}"))" DefaultValue="a">
            <RadioButton Value="a">Hangzhou</RadioButton>
            <RadioButton Value="b">Shanghai</RadioButton>
            <RadioButton Value="c">Beijing</RadioButton>
            <RadioButton Value="d">Chengdu</RadioButton>
        </RadioGroup>
        <br />
        <br />
        <RadioGroup OnChange="@((e) => System.Diagnostics.Debug.WriteLine($"Currently selected radio: {e}"))" DefaultValue="c">
            <RadioButton Value="a">Hangzhou</RadioButton>
            <RadioButton Value="b" Disabled>Shanghai</RadioButton>
            <RadioButton Value="c">Beijing</RadioButton>
            <RadioButton Value="d">Chengdu</RadioButton>
        </RadioGroup>
        <br />
        <br />
        <RadioGroup Disabled OnChange="@((e) => System.Diagnostics.Debug.WriteLine($"Currently selected radio: {e}"))" DefaultValue="d">
            <RadioButton Value="a">Hangzhou</RadioButton>
            <RadioButton Value="b">Shanghai</RadioButton>
            <RadioButton Value="c">Beijing</RadioButton>
            <RadioButton Value="d">Chengdu</RadioButton>
        </RadioGroup>
    </Demo>
</Codebox>