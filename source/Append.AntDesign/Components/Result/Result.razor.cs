using Append.AntDesign.Core;
using Append.AntDesign.Services;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Append.AntDesign.Components
{
    public partial class Result
    {
        private static readonly string prefix = "ant-result";
        private MarkupString svgImage;

        private ClassBuilder classes => ClassBuilder.Create(Class)
                .AddClass(prefix)
                .AddClass($"{prefix}-{Status}");

        private ClassBuilder iconClasses => ClassBuilder.Create($"{prefix}-icon")
                .AddClassWhen($"{prefix}-image", isImage);

        private RenderFragment BuildIcon => builder =>
        {
            IconType iconType = DetermineIconType();

            builder.OpenComponent<Icon>(1);
            builder.AddAttribute(2, "Type", iconType);
            builder.CloseComponent();
        };

        private IconType DetermineIconType()
        {
            if (Icon != null)
                return Icon; // Custom icon by the user

            if (Status == ResultStatus.Error)
                return IconType.Filled.Close_Circle;

            if (Status == ResultStatus.Success)
                return IconType.Filled.Check_Circle;

            if (Status == ResultStatus.Warning)
                return IconType.Filled.Warning;

            if (Status == ResultStatus.Unauthorized_403)
                return IconType.Internal.Bad_Request;

            if (Status == ResultStatus.NotFound_404)
                return IconType.Internal.Bad_Request;

            if (Status == ResultStatus.BadRequest_500)
                return IconType.Internal.Bad_Request;

            return IconType.Filled.Info_Circle;
        }

        private bool isImage => Status == ResultStatus.BadRequest_500
                             || Status == ResultStatus.Unauthorized_403
                             || Status == ResultStatus.NotFound_404;

        private async Task LoadImage()
        {
            if (!isImage)
                return;

            var xdoc = await IconService.GetVectorGraphicTemplateAsync(DetermineIconType());
            svgImage = (MarkupString)xdoc.ToString();
        }

        [Inject] public IIconService IconService { get; set; }
        [Parameter] public RenderFragment Title { get; set; }
        [Parameter] public RenderFragment Subtitle { get; set; }
        [Parameter] public ResultStatus Status { get; set; } = ResultStatus.Info;
        [Parameter] public IconType Icon { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            await base.OnInitializedAsync();
            await LoadImage();
        }

    }
}
