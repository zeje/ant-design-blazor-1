using Append.AntDesign.Core;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Append.AntDesign.Components
{
    public partial class CheckableTag
    {

        private ClassBuilder extraClasses => ClassBuilder.Create()
            .AddClass("ant-tag-checkable")
            .AddClassWhen("ant-tag-checkable-checked", Checked);

        private void ToggleChecked()
        {
            Checked = !Checked;
            OnChange.InvokeAsync(Checked);
        }

        [Parameter] public bool Checked { get; set; }
        [Parameter] public EventCallback<bool> OnChange { get; set; }
    }
}
