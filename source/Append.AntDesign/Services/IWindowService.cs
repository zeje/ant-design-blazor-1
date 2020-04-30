using Append.AntDesign.Components;
using Append.AntDesign.Core;
using System.Threading.Tasks;

namespace Append.AntDesign.Services
{
    public interface IWindowService
    {
        ValueTask<Dimension> GetDimensions();
        ValueTask RegisterOnWindowResizeHandler(AntComponent component);
    }
}