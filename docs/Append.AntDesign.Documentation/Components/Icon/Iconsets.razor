@using System.Reflection
<Codebox Title="Iconsets" id="components-icon-demo-filled">
    <Description>
        <p>Different Icon Themes</p>
    </Description>
    <Demo>
        <p>Click on one of the Themes to see them in action! </p>
        <Button Label="Filled" OnClick="_ => SelectIconType(typeof(IconType.Filled))" Type="(selectedIconType == typeof(IconType.Filled) ? ButtonType.Primary : ButtonType.Default)" />
        <Button Label="Outlined" OnClick="_ => SelectIconType(typeof(IconType.Outlined))" Type="(selectedIconType == typeof(IconType.Outlined) ? ButtonType.Primary : ButtonType.Default)" />
        <Button Label="TwoTone" OnClick="_ => SelectIconType(typeof(IconType.TwoTone))" Type="(selectedIconType == typeof(IconType.TwoTone) ? ButtonType.Primary : ButtonType.Default)" />
        <Divider Label="@selectedIconType.Name" />
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
    private Type selectedIconType = typeof(IconType.Filled);
    private IEnumerable<IconType> icons;

    private IconTheme theme => selectedIconType == typeof(IconType.Filled) ? IconTheme.Filled
                             : selectedIconType == typeof(IconType.Outlined) ? IconTheme.Outlined
                                                 : IconTheme.TwoTone;
    protected override void OnInitialized()
    {
        base.OnInitialized();
        icons = GetIcons();
    }

    private IEnumerable<IconType> GetIcons()
    {
        return selectedIconType.GetFields(BindingFlags.Public | BindingFlags.Static)
                          .Where(f => f.FieldType == selectedIconType)
                          .Select(x => (IconType)x.GetValue(null));
    }

    private void SelectIconType(Type iconSet)
    {
        selectedIconType = iconSet;
        icons = GetIcons();
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