<Codebox Title="Triggers" id="components-tooltip-demo-basic">
    <Description>
        <p>
            There are multiple triggers available to show | hide the tooltip. Specify a <code>IEnumerable&lt;TooltipTrigger&gt;</code> for the property <code>Triggers</code> to choose or combine the following <code>TooltipTrigger.Focus | TooltipTrigger.Hover | TooltipTrigger.Click</code>
        </p>
        <p>By default <code>TooltipTrigger.Hover</code> is used for every <code>Tooltip</code>, however you can override this default behavior by setting it explicitly as seen below.</p>
        <pre>
TooltipTrigger.DefaultTriggers = new[] {TooltipTrigger.Hover, TooltipTrigger.Focus}</pre>
    </Description>
    <Demo>
        <Tooltip>
            <Title>prompt text</Title>
            <ChildContent>
                <Button Label="Hover" />
            </ChildContent>
        </Tooltip>
        <Tooltip Triggers="@(new[] {TooltipTrigger.Focus})">
            <Title>prompt text</Title>
            <ChildContent>
                <Button Label="Focus" />
            </ChildContent>
        </Tooltip>
        <Tooltip Triggers="@(new[] {TooltipTrigger.Click})">
            <Title>prompt text</Title>
            <ChildContent>
                <Button Label="Click" />
            </ChildContent>
        </Tooltip>
        <Tooltip Triggers="@(new[] {TooltipTrigger.Hover, TooltipTrigger.Focus})">
            <Title>prompt text</Title>
            <ChildContent>
                <Button Label="Hover and Focus" />
            </ChildContent>
        </Tooltip>
    </Demo>
</Codebox>
