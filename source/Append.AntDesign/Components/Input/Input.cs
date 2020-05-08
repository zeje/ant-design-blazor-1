using Append.AntDesign.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Append.AntDesign.Components
{
    public partial class Input : AntComponent
    {
        private readonly static string baseClass = "ant-input";
        private readonly static string enterKeyString = "Enter";

        private ClassBuilder classes => ClassBuilder.Create(Class)
                .AddClass(baseClass)
                .AddClassWhen($"{baseClass}-sm", Size == InputSize.Small)
                .AddClassWhen($"{baseClass}-lg", Size == InputSize.Large);


        private bool _showPassowrd;
        private string inputTypeComputed => _showPassowrd ? "text" : Type.Name;

        private bool fixDefined => PrefixIcon != null || SuffixIcon != null || PrefixText != null || SuffixText != null || AllowClear || (VisibilityToggle && Type == InputType.Password);
        private bool prefixDefined => (PrefixText != null || PrefixIcon != null);
        private bool suffixDefined => (SuffixText != null || SuffixIcon != null || AllowClear || (VisibilityToggle && Type == InputType.Password));

        private bool addonDefined => AddonBeforeText != null || AddonBeforeIcon != null || AddonAfterText != null || AddonAfterIcon != null || EnterButton != null;
        private bool addonBeforeDefined => AddonBeforeText != null || AddonBeforeIcon != null;
        private bool addonAfterDefined => AddonAfterText != null || AddonAfterIcon != null || EnterButton != null;

        private ClassBuilder fixClasses => ClassBuilder.Create("")
                .AddClassWhen($"{baseClass}-affix-wrapper", fixDefined)
                .AddClassWhen($"{baseClass}-affix-wrapper-sm", Size == InputSize.Small && fixDefined)
                .AddClassWhen($"{baseClass}-affix-wrapper-lg", Size == InputSize.Large && fixDefined)
                .AddClassWhen($"{baseClass}-search-enter-button", EnterButton != null)
                .AddClassWhen($"{baseClass}-search", Type == InputType.Search && fixDefined)
                .AddClassWhen($"{baseClass}-password", Type == InputType.Password)
                .AddClassWhen($"{baseClass}-search-large", Size == InputSize.Large && fixDefined && EnterButton != null)
                .AddClassWhen($"{baseClass}-search-small", Size == InputSize.Small && fixDefined && EnterButton != null)
                .AddClassWhen($"{baseClass}-affix-wrapper-lg", Size == InputSize.Large && fixDefined && EnterButton != null)
                .AddClassWhen($"{baseClass}-affix-wrapper-sm", Size == InputSize.Small && fixDefined && EnterButton != null)
                .AddClassWhen($"{baseClass}-affix-wrapper-textarea-with-clear-btn", Type == InputType.TextArea && AllowClear);

        private ClassBuilder addonClassesFirstWrapper => ClassBuilder.Create("")
                .AddClassWhen($"{baseClass}-group-wrapper", addonDefined)
                .AddClassWhen($"{baseClass}-group-wrapper-sm", Size == InputSize.Small && addonDefined)
                .AddClassWhen($"{baseClass}-group-wrapper-lg", Size == InputSize.Large && addonDefined)
                .AddClassWhen($"{baseClass}-search", Type == InputType.Search && addonDefined)
                .AddClassWhen($"{baseClass}-search-enter-button", EnterButton != null && addonDefined)
                .AddClassWhen($"{baseClass}-search-large", EnterButton != null && Size == InputSize.Large && addonDefined)
                .AddClassWhen($"{baseClass}-search-small", EnterButton != null && Size == InputSize.Small && addonDefined);

        private ClassBuilder addonClassesSecondWrapper => ClassBuilder.Create("")
                .AddClassWhen($"{baseClass}-wrapper", addonDefined)
                .AddClassWhen($"{baseClass}-group", addonDefined);

        private ClassBuilder enterButtonClasses => ClassBuilder.Create($"{baseClass}-search-button")
            .AddClassWhen("ant-btn-lg", Size == InputSize.Large)
            .AddClassWhen("ant-btn-sm", Size == InputSize.Small);

        private ClassBuilder suffixClassBuilder => ClassBuilder.Create("")
            .AddClassWhen($"{baseClass}-suffix", suffixDefined && Type != InputType.TextArea);

        private ClassBuilder clearIconBuilder => ClassBuilder.Create("")
            .AddClassWhen($"{baseClass}-clear-icon", Type != InputType.TextArea)
            .AddClassWhen($"{baseClass}-clear-icon-hidden", Type != InputType.TextArea && string.IsNullOrEmpty(Value))
            .AddClassWhen($"{baseClass}-textarea-clear-icon", Type == InputType.TextArea)
            .AddClassWhen($"{baseClass}-textarea-clear-icon-hidden", Type == InputType.TextArea && string.IsNullOrEmpty(Value));

        private StyleBuilder textAreaStyleBuilder => StyleBuilder.Create("")
            .AddStyle("margin-top: 0px")
            .AddStyle("margin-bottom: 0px");



        private void ToggleShowPassword()
        {
            _showPassowrd = !_showPassowrd;
        }

        private void ClearInput()
        {
            Value = "";
        }

        private Core.Size ConvertInputToButtonSize()
        {
            if (Size == InputSize.Small)
                return Core.Size.Small;
            if (Size == InputSize.Large)
                return Core.Size.Large;
            return Core.Size.Default;
        }

        private void CheckKeypress(KeyboardEventArgs keyboardEventArgs)
        {
            if (keyboardEventArgs.Key.Equals(enterKeyString))
                EnterPressedInInput();
        }

        private void EnterPressedInInput()
        {
            OnPressEnter.InvokeAsync(Value);
            if (Type == InputType.Search)
                InvokeOnSearch();
        }

        private void InvokeOnSearch()
        {
            OnSearch.InvokeAsync(Value);
        }

        // bad way to recalculate amount of rows
        private int rows;
        protected void CalculateSize(string value)
        {
            if (value == null)
            {
                rows = AutosizeConstraints?.Item1 ?? 3;
                return;
            }
            rows = Math.Max(value.Split('\n').Length, value.Split('\r').Length);
            rows = Math.Max(rows, 3);

            if (AutoSize && AutosizeConstraints != null)
            {
                rows = Math.Max(rows, AutosizeConstraints.GetValueOrDefault().Item1);
                rows = Math.Min(rows, AutosizeConstraints.GetValueOrDefault().Item2);
            }
        }

        private string _value;

        public InputType Type { get; set; }

        [Parameter] public string AddonAfterText { get; set; }
        [Parameter] public string AddonBeforeText { get; set; }
        [Parameter] public IconType AddonAfterIcon { get; set; }
        [Parameter] public IconType AddonBeforeIcon { get; set; }
        [Parameter] public string DefaultValue { get; set; }
        [Parameter] public bool Disabled { get; set; }
        [Parameter] public string Id { get; set; }
        [Parameter] public int? MaxLength { get; set; }
        [Parameter] public IconType PrefixIcon { get; set; }
        [Parameter] public string PrefixText { get; set; }
        [Parameter] public InputSize Size { get; set; } = InputSize.Middle;
        [Parameter] public IconType SuffixIcon { get; set; }
        [Parameter] public string SuffixText { get; set; }
        [Parameter]
        public string Value
        {
            get { return _value; }
            set
            {
                if (Type == InputType.TextArea)
                    CalculateSize(value);
                _value = value;
            }
        }
        [Parameter] public bool AllowClear { get; set; }
        [Parameter] public EventCallback<ChangeEventArgs> OnChange { get; set; }
        [Parameter] public EventCallback<string> OnPressEnter { get; set; } // not yet implemented

        // type search
        [Parameter] public string EnterButton { get; set; }
        [Parameter] public EventCallback<string> OnSearch { get; set; }
        [Parameter] public bool Loading { get; set; }

        // password
        [Parameter] public bool VisibilityToggle { get; set; } = true;

        // textarea
        [Parameter] public bool AutoSize { get; set; }
        [Parameter] public ValueTuple<int, int>? AutosizeConstraints { get; set; }
        [Parameter] public EventCallback<Dimension> OnResize { get; set; }

        protected IconType SearchButtonIconTypeComputed => Loading ? IconType.Outlined.Loading : IconType.Outlined.Search;

        protected override void OnInitialized()
        {
            Value = DefaultValue;
            Type ??= InputType.Text;
            if (Type == InputType.Search && EnterButton == null)
                SuffixIcon = SearchButtonIconTypeComputed;
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {

            base.BuildRenderTree(builder);

            if (addonClassesFirstWrapper.ToString() != null)
            {
                builder.OpenElement(0, "span");
                builder.AddAttribute(1, "class", addonClassesFirstWrapper);
            }

            if (addonClassesSecondWrapper.ToString() != null)
            {
                builder.OpenElement(2, "span");
                builder.AddAttribute(3, "class", addonClassesSecondWrapper);
            }

            if (addonBeforeDefined)
            {
                builder.OpenElement(4, "span");
                builder.AddAttribute(5, "class", $"{baseClass}-group-addon");
                builder.AddContent(6, AddonBeforeText);
                if (AddonBeforeIcon != null)
                {
                    builder.OpenComponent<Icon>(7);
                    builder.AddAttribute(8, "Type", AddonBeforeIcon);
                    builder.CloseComponent();
                }
                builder.CloseElement();
            }

            if (fixClasses.ToString() != null)
            {
                builder.OpenElement(9, "span");
                builder.AddAttribute(10, "class", fixClasses);
                builder.AddAttribute(11, "style", Style);
            }

            if (prefixDefined)
            {
                builder.OpenElement(12, "span");
                builder.AddAttribute(13, "class", $"{baseClass}-prefix");
                builder.AddContent(14, PrefixText);
                if (PrefixIcon != null)
                {
                    builder.OpenComponent<Icon>(15);
                    builder.AddAttribute(16, "Type", PrefixIcon);
                    builder.CloseComponent();
                }
                builder.CloseElement();
            }

            if (Type == InputType.TextArea)
            {
                builder.OpenElement(17, "textarea");
                builder.AddMultipleAttributes(18, Attributes);

                builder.AddAttribute(19, "id", "txtArea");
                builder.AddAttribute(20, "rows", rows);
                builder.AddAttribute(21, "style", textAreaStyleBuilder);
                builder.AddAttribute(22, "class", $"{baseClass}");
            }
            else
            {
                builder.OpenElement(23, "input");
                builder.AddMultipleAttributes(24, Attributes);

                builder.AddAttribute(25, "type", inputTypeComputed);
                builder.AddAttribute(26, "class", classes);
            }

            builder.AddAttribute(27, "maxlength", MaxLength);
            builder.AddAttribute(28, "disabled", Disabled);
            builder.AddAttribute(29, "value", Value);
            builder.AddAttribute(30, "onchange", EventCallback.Factory.Create(this, OnChange));
            builder.AddAttribute(31, "oninput", EventCallback.Factory.Create<ChangeEventArgs>(this, (e) => { Value = e.Value.ToString(); }));
            builder.AddAttribute(32, "onkeypress", EventCallback.Factory.Create<KeyboardEventArgs>(this, CheckKeypress));
            builder.CloseElement();

            if (suffixDefined)
            {
                builder.OpenElement(33, "span");
                builder.AddAttribute(34, "class", suffixClassBuilder);
                if (AllowClear)
                {
                    builder.OpenComponent<Icon>(35);
                    builder.AddAttribute(36, "class", clearIconBuilder);
                    builder.AddAttribute(37, "Type", IconType.Outlined.Close_Circle);
                    builder.AddAttribute(38, "onclick", EventCallback.Factory.Create<MouseEventArgs>(this, (e) => ClearInput()));
                    builder.CloseComponent();
                }

                if (Type == InputType.Password)
                {
                    builder.OpenComponent<Icon>(39);
                    builder.AddAttribute(40, "class", $"{baseClass}-password-icon");
                    builder.AddAttribute(41, "Type", IconType.Outlined.Eye_Invisible);
                    builder.AddAttribute(42, "onclick", EventCallback.Factory.Create<MouseEventArgs>(this, (e) => ToggleShowPassword()));
                    builder.CloseComponent();
                }
                else
                {
                    builder.AddContent(43, SuffixText);
                    if (SuffixIcon != null)
                    {
                        if (Type == InputType.Search && !addonAfterDefined)
                        {
                            builder.OpenComponent<Icon>(44);
                            builder.AddAttribute(45, "class", $"{baseClass}-search-icon");
                            builder.AddAttribute(46, "Type", SuffixIcon);
                            builder.AddAttribute(47, "onclick", EventCallback.Factory.Create<MouseEventArgs>(this, (e) => InvokeOnSearch()));
                            builder.CloseComponent();
                        }
                        else
                        {
                            builder.OpenComponent<Icon>(48);
                            builder.AddAttribute(49, "style", "padding-right:4px");
                            builder.AddAttribute(50, "Type", SuffixIcon);
                            builder.CloseComponent();
                        }
                    }
                }
                builder.CloseElement();
            }

            if (fixClasses.ToString() != null)
            {
                builder.CloseElement();
            }

            if (addonAfterDefined)
            {
                builder.OpenElement(51, "span");
                builder.AddAttribute(52, "class", $"{baseClass}-group-addon");

                if (EnterButton != null)
                {
                    builder.OpenComponent<Button>(53);
                    builder.AddAttribute(54, "class", enterButtonClasses);
                    builder.AddAttribute(55, "Type", ButtonType.Primary);
                    builder.AddAttribute(56, "Label", EnterButton.Equals("") ? "" : EnterButton);
                    builder.AddAttribute(57, "Size", ConvertInputToButtonSize());
                    builder.AddAttribute(58, "onclick", EventCallback.Factory.Create<MouseEventArgs>(this, (e) => InvokeOnSearch()));
                    if (EnterButton.Equals(""))
                    {
                        builder.AddAttribute(59, "ChildContent", (RenderFragment)((builder2) =>
                        {
                            builder2.OpenComponent<Icon>(60);
                            builder2.AddAttribute(61, "Type", SearchButtonIconTypeComputed);
                            builder2.CloseComponent();
                        }));
                    }
                    builder.CloseComponent();
                }
                else
                {
                    builder.AddContent(62, AddonAfterText);
                    if (AddonAfterIcon != null)
                    {
                        builder.OpenComponent<Icon>(63);
                        builder.AddAttribute(64, "Type", AddonAfterIcon);
                        builder.CloseComponent();
                    }
                }

                builder.CloseElement();
            }
            if (addonClassesSecondWrapper.ToString() != null)
            {
                builder.CloseElement();
            }

            if (addonClassesFirstWrapper.ToString() != null)
            {
                builder.CloseElement();
            }
        }
    }
}