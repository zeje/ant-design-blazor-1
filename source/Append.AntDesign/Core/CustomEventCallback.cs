using System;


namespace Append.AntDesign.Core
{
    public class CustomEventCallback<TCustomValue, TEventArgs> where TEventArgs : EventArgs
    {
        public TCustomValue CutsomEventCallbackValue { get; set; }
        public TEventArgs EventArgs { get; set; }

        public CustomEventCallback(TCustomValue cutsomEventCallbackValue, TEventArgs eventArgs)
        {
            CutsomEventCallbackValue = cutsomEventCallbackValue;
            EventArgs = eventArgs;
        }
    }
}
