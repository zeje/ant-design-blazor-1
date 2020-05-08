using Ardalis.SmartEnum;

namespace Append.AntDesign.Components
{
    public sealed class ResultStatus : SmartEnum<ResultStatus>
    {
        public static ResultStatus Success = new ResultStatus(nameof(Success).ToLower(), 1);
        public static ResultStatus Error = new ResultStatus(nameof(Error).ToLower(), 2);
        public static ResultStatus Info = new ResultStatus(nameof(Info).ToLower(), 3);
        public static ResultStatus Warning = new ResultStatus(nameof(Warning).ToLower(), 4);
        public static ResultStatus Unauthorized_403 = new ResultStatus("403", 5);
        public static ResultStatus NotFound_404 = new ResultStatus("404", 6);
        public static ResultStatus BadRequest_500 = new ResultStatus("500", 7);
        private ResultStatus(string name, int value) : base(name, value)
        {
        }
    }
}
