<Codebox Title="Right">
    <Description>
        <p>
            Right aligned timeline.
        </p>
    </Description>
    <Demo>
        <Timeline Mode="TimelineMode.Right"> 
            <TimelineItem>Create a services site 2015-09-01</TimelineItem>
            <TimelineItem>Solve initial network problems 2015-09-01</TimelineItem>
            <TimelineItem Color="TimelineColor.Red" Dot="clock">Technical testing 2015-09-01</TimelineItem>
            <TimelineItem>Network problems being solved 2015-09-01</TimelineItem>
        </Timeline>
    </Demo>
</Codebox>

@code{
    private RenderFragment clock =@<Icon Type="IconType.Outlined.Clock_Circle" style="font-size:16px" />;
}