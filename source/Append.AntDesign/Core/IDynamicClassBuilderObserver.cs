using System;
using System.Collections.Generic;
using System.Text;

namespace Append.AntDesign.Core
{
    internal interface IDynamicClassBuilderObserver
    {
        public void ClassesHaveChanged();
    }
}
