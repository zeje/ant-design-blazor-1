<Codebox Title="Typesetting">
    <Description>
        <p>
            Child elements depending on the value of the <code>start } center | end | space-between | space-around</code>, which are defined in its parent node typesetting mode.
        </p>
    </Description>
    <Demo>
        <Divider Orientation="DividerOrientation.Left" 
                 style="color: #333; font-weight: normal"
                 Label="sub-element align left">
        </Divider>
        <Row Justify="Justification.Start">
            <Column Span="4">col-4</Column>
            <Column Span="4">col-4</Column>
            <Column Span="4">col-4</Column>
            <Column Span="4">col-4</Column>
        </Row>

        <Divider Orientation="DividerOrientation.Left" 
                 style="color: #333; font-weight: normal"
                 Label="sub-element align center">
        </Divider>
        <Row Justify="Justification.Center">
            <Column Span="4">col-4</Column>
            <Column Span="4">col-4</Column>
            <Column Span="4">col-4</Column>
            <Column Span="4">col-4</Column>
        </Row>

        <Divider Orientation="DividerOrientation.Left" 
                 style="color: #333; font-weight: normal"
                 Label="sub-element align right">
        </Divider>
        <Row Justify="Justification.End">
            <Column Span="4">col-4</Column>
            <Column Span="4">col-4</Column>
            <Column Span="4">col-4</Column>
            <Column Span="4">col-4</Column>
        </Row>

        <Divider Orientation="DividerOrientation.Left" 
                 style="color: #333; font-weight: normal"
                 Label="sub-element monospaced arrangement">
        </Divider>
        <Row Justify="Justification.Space_Between">
            <Column Span="4">col-4</Column>
            <Column Span="4">col-4</Column>
            <Column Span="4">col-4</Column>
            <Column Span="4">col-4</Column>
        </Row>

        <Divider Orientation="DividerOrientation.Left" 
                 style="color: #333; font-weight: normal"
                 Label="sub-element align full">
        </Divider>
        <Row Justify="Justification.Space_Around">
            <Column Span="4">col-4</Column>
            <Column Span="4">col-4</Column>
            <Column Span="4">col-4</Column>
            <Column Span="4">col-4</Column>
        </Row>
    </Demo>
</Codebox>

<style>
    #components-grid-demo-typesetting [class~='ant-row'] {
        background: rgba(128, 128, 128, 0.08);
    }
</style>