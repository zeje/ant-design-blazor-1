@inject IIconService IconService
<Codebox Title="Lazy" id="components-icon-demo-basic">
    <Description>
        <p>
            Icons are lazy-loaded, which means that only the icons you use in your app will be downloaded when needed and stored in a cache.
            However you can opt-in to preload certain or all icons by using the <code>IIconService</code>.
        </p>
    </Description>
</Codebox>

@code{
    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        // All icons
        //await IconService.PreloadIconsAsync(); 

        // Only certain icons are preloaded.
        //await IconService.PreloadIconsAsync(new[] { IconType.Filled.Github, IconType.Filled.Trophy });
    }
}