using System;
using System.Text;

namespace Append.AntDesign.Core
{
    public class ClassBuilder
    {
        private StringBuilder builder;
        private static char separator = ' ';

        private ClassBuilder(string initialValue)
        {
            builder = new StringBuilder(initialValue);
        }

        public static ClassBuilder Create(string initialValue)
        {
            return new ClassBuilder(initialValue);
        }

        public ClassBuilder AddClass(string cssClass)
        {
            if (builder.Length != 0)
                builder.Append(separator);

            builder.Append(cssClass);
            return this;
        }
        public ClassBuilder AddClassWhen(string cssClass, bool isValid)
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
            return builder.ToString();
        }

        public ClassBuilder AddClassWhen(string cssClass, Func<bool> isValid)
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
