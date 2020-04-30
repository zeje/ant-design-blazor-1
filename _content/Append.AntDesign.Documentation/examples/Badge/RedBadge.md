<Codebox Title="Red Badge">
    <Description>
        <p>
            This will simply display a red badge, without a specific count. If <code>Count</code> equals <code>0</code>, it won't display the <code>Dot</code>.
        </p>
    </Description>
    <Demo>
        <Badge Dot>
            <Icon Type="IconType.Outlined.Notification"/>
        </Badge>
        <Badge Count="0" Dot>
            <Icon Type="IconType.Outlined.Notification"/>
        </Badge>

        <Badge Dot>
            <a>Link something</a>
        </Badge>
    </Demo>
</Codebox>

<style>

    .anticon-notification {
        width: 16px;
        height: 16px;
        line-height: 16px;
        font-size: 16px;
    }
</style>