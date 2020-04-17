using System.Threading.Tasks;

namespace Append.AntDesign.Services
{
    public interface IClipboardService
    {
        ValueTask Copy(string text);
    }
}