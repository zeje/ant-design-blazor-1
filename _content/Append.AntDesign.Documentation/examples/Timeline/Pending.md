<Codebox Title="Pending">
    <Description>
        <p>
            Shows a loading icon as the last item.
        </p>
    </Description>
    <Demo>
        <Timeline>
            <TimelineItem>Create a services site 2015-09-01</TimelineItem>
            <TimelineItem>Solve initial network problems 2015-09-01</TimelineItem>
            <TimelineItem>Technical testing 2015-09-01</TimelineItem>
            <TimelineItem Dot="loadingIcon">Recording...</TimelineItem>
        </Timeline>
    </Demo>
</Codebox>

@code{
    private RenderFragment loadingIcon = @<Icon Type="IconType.Outlined.Loading"/>;
}