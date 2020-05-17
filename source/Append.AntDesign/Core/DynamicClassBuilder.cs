using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Append.AntDesign.Core
{
    internal class DynamicClassBuilder
    {
        private IDynamicClassBuilderObserver _dynamicClassBuilderObserver;
        private StringBuilder builder;
        private static char separator = ' ';

        protected DynamicClassBuilder(IDynamicClassBuilderObserver dynamicClassBuilderObserver)
        {
            _dynamicClassBuilderObserver = dynamicClassBuilderObserver;
            builder = new StringBuilder(null);
        }
        internal static DynamicClassBuilder Create(IDynamicClassBuilderObserver dynamicClassBuilderObserver)
        {
            return new DynamicClassBuilder(dynamicClassBuilderObserver);
        }

        internal async Task AddClassFor(string cssClass, TimeSpan duration)
        {
            AddClass(cssClass);
            await Task.Delay(duration);
            RemoveClass(cssClass);
            _dynamicClassBuilderObserver.ClassesHaveChanged();
        }

        internal async Task AddClassesFor(TimeSpan duration, params string[] cssClasses)
        {
            foreach (var cssClass in cssClasses)
                AddClass(cssClass);

            await Task.Delay(duration);

            foreach (var cssClass in cssClasses)
                RemoveClass(cssClass);

            _dynamicClassBuilderObserver.ClassesHaveChanged();
        }

        internal async Task AddClassAfter(string cssClass, TimeSpan time)
        {
            await Task.Delay(time);
            AddClass(cssClass);
            _dynamicClassBuilderObserver.ClassesHaveChanged();
        }

        internal async Task AddClassesAfter(TimeSpan time, params string[] cssClasses)
        {
            await Task.Delay(time);
            foreach (var cssClass in cssClasses)
                AddClass(cssClass);
            _dynamicClassBuilderObserver.ClassesHaveChanged();
        }

        private DynamicClassBuilder AddClass(string cssClass)
        {
            if (builder.Length != 0)
                builder.Append(separator);

            builder.Append(cssClass);
            return this;
        }

        private void RemoveClass(string cssClass)
        {
            builder.Replace(cssClass, "");
   
            builder.Replace("  ", " ");
        }

        public override string ToString()
        {
            if (builder.Length == 0)
                return null;
            return builder.ToString();
        }
    }
}
