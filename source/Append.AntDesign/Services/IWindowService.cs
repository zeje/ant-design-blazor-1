using Append.AntDesign.Components;
using System.Threading.Tasks;

namespace Append.AntDesign.Services
{
    public interface IWindowService
    {
        ValueTask<WindowDimension> GetDimensions();
        ValueTask RegisterOnWindowResizeHandler(AntComponent component);
    }
}