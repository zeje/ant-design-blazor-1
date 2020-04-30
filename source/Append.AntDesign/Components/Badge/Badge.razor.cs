using Append.AntDesign.Core;
using Microsoft.AspNetCore.Components;
using System;
using System.Linq;

namespace Append.AntDesign.Components
{
    public partial class Badge
    {
        private readonly static string prefix = "ant-badge";

        private ClassBuilder Classes => ClassBuilder.Create(Class)
               .AddClass(prefix)
               .AddClassWhen($"{prefix}-status", Status != null || !string.IsNullOrEmpty(Color))
               .AddClassWhen($"{prefix}-not-a-wrapper", ChildContent == null);



        private StyleBuilder Styles => StyleBuilder.Create(Style)
                .AddStyleWhen($"background: {Color}", CustomColor() == true)
                .AddStyleWhen($"right: -{Offset.X}px", Offset.X != 0)
                .AddStyleWhen($"margin-top: {Offset.Y}px", Offset.Y != 0);

        private ClassBuilder dotClasses => ClassBuilder.Create("ant-badge-status-dot")
                .AddClassWhen($"ant-badge-status-{Status}", Status != null)
                .AddClassWhen($"ant-badge-status-{Color}", CustomColor() == false);

        private string TitleString => Title ?? Count.ToString();

        private bool BadgeHasContentOrDotShouldOverride => (Count != null && ShowZero) || (Count > 0 || Count < 0) || (Dot && Count != 0);

        private void CheckContradictingParameters()
        {
            if (Count == null && ShowZero)
                throw new ArgumentException($"A {nameof(Badge)} cannot {nameof(ShowZero)} if the {nameof(Count)} is not defined.");

            if (Count != null && Icon != null)
                throw new ArgumentException($"A {nameof(Badge)} cannot define both an {nameof(Icon)} and a {nameof(Count)}.");

            if (!string.IsNullOrEmpty(Color) && Status != null)
                throw new ArgumentException($"A {nameof(Badge)} cannot define both a {nameof(Color)} and a {nameof(Status)}.");

        }

        private bool? CustomColor()
        {
            if (string.IsNullOrEmpty(Color))
                return null;

            return !Core.Color.TryFromName(Color, ignoreCase: true, out var result);
        }

        private string CountString()
        {
            return Count > OverflowCount ? $"{OverflowCount}+" : Count.ToString();
        }

        [Parameter] public RenderFragment ChildContent { get; set; }

        [Parameter] public int? Count { get; set; }

        [Parameter] public IconType Icon{ get; set; }

        [Parameter] public bool ShowZero { get; set; }

        [Parameter] public int OverflowCount { get; set; } = 99;

        [Parameter] public string Color { get; set; }

        [Parameter] public Offset Offset { get; set; }

        [Parameter] public bool Dot { get; set; }

        [Parameter] public BadgeStatus Status { get; set; }

        [Parameter] public string Text { get; set; }

        [Parameter] public string Title { get; set; }

        protected override void OnParametersSet()
        {
            CheckContradictingParameters();

            if (Status != null)
            {
                Dot = true;
            }
        }
    }
}