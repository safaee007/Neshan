using Library.Core.Enums;

namespace Neshan.Domain.DTOs.Common
{
    public class ListFilterDTO
    {
        public Guid userID { get; set; }
        public SharedEnums.Languages Language { get; set; } = SharedEnums.Languages.Farsi;
        public string? Search { get; set; } = string.Empty;
        public SharedEnums.BaseStatus Status { get; set; } = SharedEnums.BaseStatus.None;
        public SharedEnums.Sort Sort { get; set; } = SharedEnums.Sort.CreateDate_desc;
        public Guid Parent { get; set; }
        public int From { get; set; } = 0;
        public int Count { get; set; } = 20;
    }
}
