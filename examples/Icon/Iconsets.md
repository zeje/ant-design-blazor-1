@using System.Reflection
<Codebox Title="Iconsets" id="components-icon-demo-filled">
    <Description>
        <p>Different Icon Themes</p>
    </Description>
    <Demo>
        <p>Click on one of the Themes to see them in action! </p>
        <Button Label="Filled" OnClick="_ => SelectIconType(IconTheme.Filled)" Type="(selectedTheme == IconTheme.Filled ? ButtonType.Primary : ButtonType.Default)" />
        <Button Label="Outlined" OnClick="_ => SelectIconType(IconTheme.Outlined)" Type="(selectedTheme == IconTheme.Outlined ? ButtonType.Primary : ButtonType.Default)" />
        <Button Label="TwoTone" OnClick="_ => SelectIconType(IconTheme.TwoTone)" Type="(selectedTheme == IconTheme.TwoTone ? ButtonType.Primary : ButtonType.Default)" />
        <Divider Label="@selectedTheme.Name" />
        <ul class="anticons-list">
            @foreach (var item in icons)
            {
                <li @key="item">
                    <Icon Type="item" />
                    <span class="anticon-class">
                        <span class="ant-badge">@item.UnnormalisedName</span>
                    </span>
                </li>
            }
        </ul>
    </Demo>
</Codebox>

@code{
    private IconTheme selectedTheme = IconTheme.Filled;
    private IEnumerable<IconType> icons;

    protected override void OnInitialized()
    {
        base.OnInitialized();
        icons = IconType.List.Where(x => x.Theme == IconTheme.Filled);
    }

    private void SelectIconType(IconTheme theme)
    {
        selectedTheme = theme;
        icons = IconType.List.Where(x => x.Theme == selectedTheme);
    }

}

<style>
    ul.anticons-list li {
        position: relative;
        float: left;
        width: 16.66%;
        height: 100px;
        margin: 3px 0;
        padding: 10px 0 0;
        overflow: hidden;
        color: #555;
        text-align: center;
        list-style: none;
        background-color: inherit;
        border-radius: 4px;
        cursor: pointer;
        -webkit-transition: color .3s ease-in-out,background-color .3s ease-in-out;
        transition: color .3s ease-in-out,background-color .3s ease-in-out;
    }
</style>