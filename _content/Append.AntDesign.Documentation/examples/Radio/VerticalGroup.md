<Codebox Title="Vertical RadioGroup">
    <Description>
        <p>
            Vertical <code>RadioGroup</code>.
        </p>
    </Description>
    <Demo>
        <RadioGroup Value="1" OnChange="@((e) => System.Diagnostics.Debug.WriteLine($"Currently selected radio: {e}"))">
            <Radio class="radioStyle" Value="1">
                Option A
            </Radio>
            <Radio class="radioStyle" Value="2">
                Option B
            </Radio>
            <Radio class="radioStyle" Value="3">
                Option C
            </Radio>
        </RadioGroup>
    </Demo>
</Codebox>
<style>
    .radioStyle {
        display: block;
        height: 30px;
        line-height: 30px;
    }
</style>