<Codebox Title="OnEnter event search">
    <Description>
        <p>
            Search OnPressEnter event example.
        </p>
    </Description>
    <Demo>
        <Search placeholder="Fire OnEnter event when pressing enter" OnPressEnter="OnEnter" />
        <br />
        <br />
        <Search placeholder="Fire OnEnter event when pressing enter" EnterButton="" OnPressEnter="OnEnter" />
        <br />
        <br />
        <TextArea placeholder="Fire OnEnter event when pressing enter" OnPressEnter="OnEnter" />
        <br />
        <br />
        <Input AddonBeforeText="Input value when enter was pressed" Value="@_inputValue" />

    </Demo>
</Codebox>

@code{

    private string _inputValue;

    private void OnEnter(string inputValue)
    {
        _inputValue = inputValue;
    }

}

