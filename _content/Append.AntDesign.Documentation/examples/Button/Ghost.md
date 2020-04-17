<Codebox Title="Ghost">
    <Description>
        <p>The <code>Ghost</code> property will make button's background transparent, it is commonly used in colored background.</p>
    </Description>
    <Demo>
        <div class="site-button-ghost-wrapper">
            <Button Type="@ButtonType.Primary" Ghost Label="Primary" />
            <Button Ghost Label="Default" />
            <Button Type="@ButtonType.Dashed" Ghost Label="Dashed" />
            <Button Type="@ButtonType.Link" Ghost Label="Link" />
            <br />
            <br />
        </div>
    </Demo>
</Codebox>

<style>
    .site-button-ghost-wrapper {
        background: rgb(190, 200, 200);
        padding: 26px 16px 16px;
    }
</style>