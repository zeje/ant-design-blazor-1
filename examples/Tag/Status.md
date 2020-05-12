<Codebox Title="Status tag">
    <Description>
        <p>
            We preset five different colors, you can set the <code>Color</code> property such as <code>success</code>, <code>processing</code>, <code>error</code>, <code>default</code> and <code>warning</code> to indicate a specific status.
        </p>
    </Description>
    <Demo>
        <div>
            <h4>Without icon</h4>
            <Tag Color="success">success</Tag>
            <Tag Color="processing">processing</Tag>
            <Tag Color="error">error</Tag>
            <Tag Color="warning">warning</Tag>
            <Tag Color="default">default</Tag>
        </div>
        <br />
        <div>
            <h4>With icon</h4>
            <Tag Color="success">
                <Icon Type="IconType.Outlined.Check_Circle" />
                success
            </Tag>

            <Tag Color="processing">
                <Icon Type="IconType.Outlined.Sync" Spin />
                processing
            </Tag>

            <Tag Color="error">
                <Icon Type="IconType.Outlined.Close_Circle" />
                error
            </Tag>

            <Tag Color="warning">
                <Icon Type="IconType.Outlined.Exclamation_Circle" />
                warning
            </Tag>

            <Tag Color="default">
                <Icon Type="IconType.Outlined.Clock_Circle" />
                waiting
            </Tag>

            <Tag Color="default">
                <Icon Type="IconType.Outlined.Minus_Circle" />
                stop
            </Tag>
        </div>
    </Demo>
</Codebox>