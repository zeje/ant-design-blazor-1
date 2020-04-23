<Codebox Title="Alternate">
    <Description>
        <p>
            Alternating timeline.
        </p>
    </Description>
    <Demo>
        <Timeline Mode="TimelineMode.Alternate">
            <TimelineItem>Create a services site 2015-09-01</TimelineItem>
            <TimelineItem Color="TimelineColor.Green">Solve initial network problems 2015-09-01</TimelineItem>
            <TimelineItem Dot=clock>
                Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque
                laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto
                beatae vitae dicta sunt explicabo.
            </TimelineItem>
            <TimelineItem Color="TimelineColor.Red">Network problems being solved 2015-09-01</TimelineItem>
            <TimelineItem>Create a services site 2015-09-01</TimelineItem>
            <TimelineItem Dot="clock">Technical testing 2015-09-01</TimelineItem>
        </Timeline>
    </Demo>
</Codebox>

@code{
    private RenderFragment clock =@<Icon Type="IconType.Outlined.Clock_Circle" Style="font-size:16px" />;
}