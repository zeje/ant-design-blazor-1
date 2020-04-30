<Codebox Title="Size">
    <Description>
        <p>Ant Design supports a default button <code>size</code> as well as a <code>large</code> and <code>small</code> size. If a <code>large</code> or <code>small</code> button is desired, set the <code>size</code> property to either <code>large</code> or <code>small</code> respectively. Omit the <code>size</code> property for a button with the default size.</p>
    </Description>
    <Demo>
        <Button Type="ButtonType.Primary" Size="Size.Large" Label="Large Primary" />
        <Button Type="ButtonType.Default" Size="Size.Large" Label="Large Default" />
        <Button Type="ButtonType.Dashed" Size="Size.Large" Label="Large Dashed" />
        <Button Type="ButtonType.Link" Size="Size.Large" Label="Large Link" />
        <br />
        <br />
        <Button Type="ButtonType.Primary" Size="Size.Default" Label="Default Primary" />
        <Button Type="ButtonType.Default" Size="Size.Default" Label="Default Default" />
        <Button Type="ButtonType.Dashed" Size="Size.Default" Label="Default Dashed" />
        <Button Type="ButtonType.Link" Size="Size.Default" Label="Default Link" />
        <br />
        <br />
        <Button Type="ButtonType.Primary" Size="Size.Small" Label="Small Primary" />
        <Button Type="ButtonType.Default" Size="Size.Small" Label="Small Default" />
        <Button Type="ButtonType.Dashed" Size="Size.Small" Label="Small Dashed" />
        <Button Type="ButtonType.Link" Size="Size.Small" Label="Small Link" />
        <br />
        <br />
        <Button Type="ButtonType.Primary" Size="Size.Large">
            <Icon Type="IconType.Outlined.Download" />
        </Button>
        <Button Type="ButtonType.Primary" Size="Size.Large" Shape="ButtonShape.Circle">
            <Icon Type="IconType.Outlined.Download" />
        </Button>
        <Button Type="ButtonType.Primary" Size="Size.Large" Shape="ButtonShape.Round">
            <Icon Type="IconType.Outlined.Download" />
        </Button>
        <Button Type="ButtonType.Primary" Size="Size.Large" Shape="ButtonShape.Round" Label="Download">
            <Icon Type="IconType.Outlined.Download" />
        </Button>
        <Button Type="ButtonType.Primary" Size="Size.Large" Label="Download">
            <Icon Type="IconType.Outlined.Download" />
        </Button>
    </Demo>
</Codebox>