namespace Append.AntDesign.Components
{
    public class RadioGroupOption
    {
        public string Label { get; set; }
        public string Value { get; set; }
        public bool Disabled { get; set; }

        private RadioGroupOption(string label, string value, bool disabled)
        {
            Label = label;
            Value = value;
            Disabled = disabled;
        }

        public static RadioGroupOption Create(string label) => new RadioGroupOption(label, null, false);
        public static RadioGroupOption Create(string label, string value) => new RadioGroupOption(label, value, false);
        public static RadioGroupOption Create(string label, string value, bool disabled) => new RadioGroupOption(label, value, disabled);
    }
}