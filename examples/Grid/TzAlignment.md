<Codebox Title="Alignment">
    <Description>
        <p>
            Child elements can be vertically aligned.
        </p>
    </Description>
    <Demo>
        <Divider Orientation="DividerOrientation.Left" style="color: #333; font-weight: normal" Label="Align Top" />
        <Row Justify="Justification.Center" Align="AntDesign.Components.Alignment.Top">
            <Column Span="4">
            <p style="height:100px;line-height:100px">col-4</p>
            </Column>
            <Column Span="4">
            <p style="height:50px;line-height:50px">col-4</p>
            </Column>
            <Column Span="4">
            <p style="height:120px;line-height:120px">col-4</p>
            </Column>
            <Column Span="4">
            <p style="height:80px;line-height:80px">col-4</p>
            </Column>
        </Row>

        <Divider Orientation="DividerOrientation.Left" style="color: #333; font-weight: normal" Label="Align Middle" />
        <Row Justify="Justification.Space_Around" Align="AntDesign.Components.Alignment.Middle">
            <Column Span="4">
            <p style="height:100px;line-height:100px">col-4</p>
            </Column>
            <Column Span="4">
            <p style="height:50px;line-height:50px">col-4</p>
            </Column>
            <Column Span="4">
            <p style="height:120px;line-height:120px">col-4</p>
            </Column>
            <Column Span="4">
            <p style="height:80px;line-height:80px">col-4</p>
            </Column>
        </Row>

        <Divider Orientation="DividerOrientation.Left" style="color: #333; font-weight: normal" Label="Align Bottom" />
        <Row Justify="Justification.Space_Between" Align="AntDesign.Components.Alignment.Bottom">
            <Column Span="4">
            <p style="height:100px;line-height:100px">col-4</p>
            </Column>
            <Column Span="4">
            <p style="height:50px;line-height:50px">col-4</p>
            </Column>
            <Column Span="4">
            <p style="height:120px;line-height:120px">col-4</p>
            </Column>
            <Column Span="4">
            <p style="height:80px;line-height:80px">col-4</p>
            </Column>
        </Row>
    </Demo>
</Codebox>

<style>
    #components-grid-demo-tzalignment [class~='ant-row'] {
        background: rgba(128, 128, 128, 0.08);
    }
</style>