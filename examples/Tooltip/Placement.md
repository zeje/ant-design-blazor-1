<Codebox Title="Placement" id="components-tooltip-demo-placement">
    <Description>
        <p>
            There are 12 placement options available.
        </p>
    </Description>
    <Demo>
        <div style="margin-left: 70px; white-space: nowrap;">
            <Tooltip Placement="TooltipPlacement.TopLeft">
                <Title>@text</Title>
                <ChildContent>
                    <Button Label="TL"/>
                </ChildContent>
            </Tooltip>
            <Tooltip Placement="TooltipPlacement.Top">
                <Title>@text</Title>
                <ChildContent>
                    <Button Label="Top"/>
                </ChildContent>
            </Tooltip>
            <Tooltip Placement="TooltipPlacement.TopRight">
                <Title>@text</Title>
                <ChildContent>
                    <Button Label="TR" />
                </ChildContent>
            </Tooltip>
        </div>
        <div style="width: 70px; float: left;">
            <Tooltip Placement="TooltipPlacement.LeftTop">
                <Title>@text</Title>
                <ChildContent>
                    <Button Label="LT"/>
                </ChildContent>
            </Tooltip>
            <Tooltip Placement="TooltipPlacement.Left">
                <Title>@text</Title>
                <ChildContent>
                    <Button Label="Left"/>
                </ChildContent>
            </Tooltip>
            <Tooltip Placement="TooltipPlacement.LeftBottom">
                <Title>@text</Title>
                <ChildContent>
                    <Button Label="LB"/>
                </ChildContent>
            </Tooltip>
        </div>
        <div style="width: 70px; margin-left: 304px;">
            <Tooltip Placement="TooltipPlacement.RightTop">
                <Title>@text</Title>
                <ChildContent>
                    <Button Label="RT" />
                </ChildContent>
            </Tooltip>
            <Tooltip Placement="TooltipPlacement.Right">
                <Title>@text</Title>
                <ChildContent>
                    <Button Label="Right"/>
                </ChildContent>
            </Tooltip>
            <Tooltip Placement="TooltipPlacement.RightBottom">
                <Title>@text</Title>
                <ChildContent>
                    <Button Label="RB" />
                </ChildContent>
            </Tooltip>
        </div>
        <div style="margin-left: 70px; clear: both; white-space: nowrap;">
            <Tooltip Placement="TooltipPlacement.BottomLeft">
                <Title>@text</Title>
                <ChildContent>
                    <Button Label="BL"/>
                </ChildContent>
            </Tooltip>
            <Tooltip Placement="TooltipPlacement.Bottom">
                <Title>@text</Title>
                <ChildContent>
                    <Button Label="Bottom"/>
                </ChildContent>
            </Tooltip>
            <Tooltip Placement="TooltipPlacement.BottomRight">
                <Title>@text</Title>
                <ChildContent>
                    <Button Label="BR"/>
                </ChildContent>
            </Tooltip>
        </div>

    </Demo>
</Codebox>

@code{
    string text = "prompt text";
}

<style>
    #components-tooltip-demo-placement .ant-btn {
        width: 70px;
        text-align: center;
        padding: 0;
    }
</style>