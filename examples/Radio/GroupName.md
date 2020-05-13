<Codebox Title="RadioGroup with name">
    <Description>
        <p>
            Defining the <code>Name</code> property to <code>RadioGroup</code> makes it so all the <code>input[type="radio"]</code> have this name. It is usually used to let the browser see your RadioGroup as a real "group" and keep the default behavior. For example, using left/right keyboard arrow to change your selection in the same <code>RadioGroup</code>.
        </p>
    </Description>
    <Demo>
        <RadioGroup Name="radiogroup" DefaultValue="1">
            <Radio Value="1">A</Radio>
            <Radio Value="2">B</Radio>
            <Radio Value="3">C</Radio>
            <Radio Value="4">D</Radio>
        </RadioGroup>
    </Demo>
</Codebox>