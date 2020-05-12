using Append.AntDesign.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;

namespace Append.AntDesign.Components
{
    public partial class Tag
    {
        private ClassBuilder classes => classesBase
            .AddClassWhen($"{baseClass}-hidden", _hideTag || !Visible);

        private StyleBuilder styles => stylesBase;

        private void HideCloseIcon()
        {
            _hideTag = true;
            OnClose.InvokeAsync(_hideTag);
        }

        private bool _hideTag;
        private bool _visible = true;

        [Parameter] public bool Closable { get; set; }
        [Parameter]
        public bool Visible
        {
            get { return _visible; }
            set
            {
                _hideTag = !value;
                _visible = value;
            }
        }
        [Parameter] public EventCallback<bool> OnClose { get; set; }

    }
}
