<Codebox Title="Clickable">
    <Description>
        <p>
            The <code>Badge</code>can be wrapped with <code>a</code> tag to make it linkable.
        </p>
    </Description>
    <Demo>
        <a href="#" target="_blank">
            <Badge Count="0">
                <span class="head-example" />
            </Badge>
        </a>
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