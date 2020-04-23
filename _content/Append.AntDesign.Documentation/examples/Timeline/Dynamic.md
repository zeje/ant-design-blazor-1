<Codebox Title="Dynamic">
    <Description>
        <p>
            Dynamically load items based on a <code>IEnumerable</code> with and custom ordering.
        </p>
    </Description>
    <Demo>
        <Timeline>
            @foreach (var item in items.Reverse())
            {
                <TimelineItem>@item</TimelineItem>
            }
        </Timeline>
    </Demo>
</Codebox>

@code{
    private IEnumerable<string> items = new[]
    {
        "Create a services site 2015-09-01",
        "Solve initial network problems 2015-09-01",
        "Technical testing 2015-09-01",
        DateTime.UtcNow.ToLongDateString()
    };
}