<Codebox Title="Basic">
    <Description>
        <p>
            Simplest Usage. <code>Badge</code> will be hidden when <code>Count</code> is <code>0</code>, but we can use <code>ShowZero</code> to show it.
        </p>
    </Description>
    <Demo>
        <Badge Count="5">
            <a class="head-example" />
        </Badge>

        <Badge Count="0" ShowZero>
            <a class="head-example" />
        </Badge>

        <Badge Icon="IconType.Outlined.Clock_Circle" style="color:red;">
            <a class="head-example" />
        </Badge>
    </Demo>
</Codebox>

<style>
    .ant-badge:not(.ant-badge-not-a-wrapper) {
        margin-right: 20px;
    }

    .ant-badge.ant-badge-rtl:not(.ant-badge-not-a-wrapper) {
        margin-right: 0;
        margin-left: 20px;
    }

    .head-example {
        width: 42px;
        height: 42px;
        border-radius: 2px;
        background: #eee;
        display: inline-block;
        vertical-align: middle;
    }
</style>