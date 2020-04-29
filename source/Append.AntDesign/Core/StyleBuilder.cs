using System;
using System.Text;

namespace Append.AntDesign.Core
{
    public class StyleBuilder
    {
        private readonly StringBuilder builder;
        private static readonly char separator = ';';

        private StyleBuilder(string initialValue = null)
        {
            builder = new StringBuilder(initialValue);
        }

        public static StyleBuilder Create(string initialValue = null)
        {
            return new StyleBuilder(initialValue);
        }

        public StyleBuilder AddStyle(string cssClass)
        {
            if (builder.Length != 0)
                builder.Append(separator);

            builder.Append(cssClass);
            return this;
        }

        public StyleBuilder AddStyleWhen(string cssClass, bool isValid)
        {
            if (!isValid)
                return this;

            if (string.IsNullOrEmpty(cssClass))
                return this;

            if (builder.Length != 0)
                builder.Append(separator);

            builder.Append(cssClass);

            return this;
        }

        public override string ToString()
        {
            if (builder.Length == 0)
                return null;
            return builder.ToString();
        }

        public StyleBuilder AddStyleWhen(string cssClass, Func<bool> isValid)
        {
            if (!isValid.Invoke())
                return this;

            if (string.IsNullOrEmpty(cssClass))
                return this;

            if (builder.Length != 0)
                builder.Append(separator);

            builder.Append(cssClass);

            return this;
        }
    }
}
