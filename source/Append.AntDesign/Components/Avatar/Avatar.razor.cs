using Append.AntDesign.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace Append.AntDesign.Components
{
    /// <summary>
    /// Avatars can be used to represent people or objects. It supports images, <see cref="IconType"/>, or text.
    /// </summary>
    public partial class Avatar
    {
        private static readonly string prefix = "ant-avatar";

        private ClassBuilder classes => ClassBuilder.Create(Class)
                .AddClass(prefix)
                .AddClass($"{prefix}-{Shape}")
                .AddClassWhen($"{prefix}-{Size}", Size != null)
                .AddClassWhen($"{prefix}-icon", Icon != null)
                .AddClassWhen($"{prefix}-image", !string.IsNullOrEmpty(ImageSource));

        private StyleBuilder textStyles => StyleBuilder.Create()
                .AddStyle($"transform: scale({scale}) translateX(-50%);");

        private ClassBuilder textClasses => ClassBuilder.Create($"{prefix}-string");

        private ElementReference avatarRef;
        private ElementReference textRef;

        private Dimension avatarDimension;
        private Dimension textDimension;

        private decimal scale = 1M;
        private bool isReadyForInterop;

        [Inject] public IJSRuntime jsRuntime{ get; set; }

        [Parameter] public Size Size { get; set; }
        [Parameter] public IconType Icon { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public AvatarShape Shape { get; set; } = AvatarShape.Circle;
        [Parameter] public string ImageSource { get; set; }
        [Parameter] public string ImageSourceSet { get; set; }
        [Parameter] public string ImageAlt { get; set; }
        [Parameter] public EventCallback<ErrorEventArgs> OnImageLoadError { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();
            await SetScaleForTextAccordingToParent();
            CheckContradictingContent();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (firstRender)
            {
                isReadyForInterop = true;
                await SetScaleForTextAccordingToParent();
            }
        }

        private void CheckContradictingContent()
        {
            if (Icon != null && ChildContent != null)
                throw new ArgumentException($"An {nameof(Avatar)} cannot have an {nameof(Icon)} and ${nameof(ChildContent)}.");

            if (Icon != null && !string.IsNullOrEmpty(ImageSource))
                throw new ArgumentException($"An {nameof(Avatar)} cannot have an {nameof(Icon)} and a ${nameof(ImageSource)}.");

            if (ChildContent != null && !string.IsNullOrEmpty(ImageSource))
                throw new ArgumentException($"An {nameof(Avatar)} cannot have {nameof(ChildContent)} and a ${nameof(ImageSource)}.");
        }

        /// <summary>
        /// Scales the text according to the size of the avatar.
        /// </summary>
        private async Task SetScaleForTextAccordingToParent()
        {
            if (ChildContent == null)
                return;

            if (!isReadyForInterop)
                return;

            avatarDimension = await avatarRef.GetDimension(jsRuntime);
            textDimension = await textRef.GetDimension(jsRuntime);

            // We're checking if the text is bigger than the avatar, if it is we scale the text accoridingly.

            decimal newScale = 1M; ;

            if (avatarDimension == null || textDimension == null)
                return;

            if (avatarDimension.Width - 8M < textDimension.Width)
            {
                newScale = (avatarDimension.Width - 8M) / textDimension.Width;
            }

            if (newScale == scale)
                return;

            scale = newScale;
            StateHasChanged();
        }

    }
}
