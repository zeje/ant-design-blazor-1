<Codebox Title="Advanced responsiveness">
    <Description>
        <p>
            <code>Span | Pull | Push | Offset | Order</code> parameters can be embedded into <code>Xs Sm Md Lg Xl</code> properties to use, where <code> Xs="6"</code> is equivalent to <code>Xs="@@(new ResponsiveOptions { Span=6})"</code>.
        </p>
    </Description>
    <Demo>
        <Row>
            <Column Xs="@(new ResponsiveOptions { Span=5,Offset=1 })" Lg="@(new ResponsiveOptions { Span=6,Offset=2 })">
            Col
            </Column>
            <Column Xs="@(new ResponsiveOptions { Span=11,Offset=1 })" Lg="@(new ResponsiveOptions { Span=6,Offset=2 })">
            Col
            </Column>
            <Column Xs="@(new ResponsiveOptions { Span=5,Offset=1 })" Lg="@(new ResponsiveOptions { Span=6,Offset=2 })">
            Col
            </Column>
        </Row>
    </Demo>
</Codebox>