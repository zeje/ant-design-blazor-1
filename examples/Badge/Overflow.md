<Codebox Title="Overflow">
    <Description>
        <p>
            <code>OverflowCount</code> is displayed when <code>Count</code> is larger than the <code>OverflowCount</code>. The default value of overflowCount is <code>99</code>.
        </p>
    </Description>
    <Demo>
        <Badge Count="99">
            <a class="head-example" />
        </Badge>

        <Badge Count="100">
            <a class="head-example" />
        </Badge>

        <Badge Count="99" OverflowCount="10">
            <a class="head-example" />
        </Badge>

        <Badge Count="1000" OverflowCount="999">
            <a class="head-example" />
        </Badge>
    </Demo>
</Codebox>


<style>
    .head-example {
        width: 42px;
        height: 42px;
        border-radius: 2px;
        background: #eee;
        display: inline-block;
        vertical-align: middle;
    }
</style>