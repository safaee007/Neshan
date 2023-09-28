using Library.Core.Enums;

namespace Library.Core.Models
{
    public class ApiResponseModel
    {
        public SharedEnums.SharedResult Status { get; set; }
        public object Content { get; set; } = default!;
        public string Message { get; set; } = default!;
    }
}
