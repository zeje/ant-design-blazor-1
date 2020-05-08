<Codebox Title="Autosizing the height to fit the content">
    <Description>
        <p>
            The <code>AutoSize</code> property for an input of type <code>InputType.Textarea</code> makes the height to automatically adjust based on the content. The propery <code>AutosizeConstraints</code> can be used to autoSize to specify the minimum and maximum number of lines the textarea will automatically adjust to.
        </p>
    </Description>
    <Demo>
        <TextArea placeholder="with autosize" AutoSize />
        <br />
        <br />
        <TextArea placeholder="with constraints, min=4, max=8" AutoSize AutosizeConstraints="(4,8)" />
    </Demo>
</Codebox>