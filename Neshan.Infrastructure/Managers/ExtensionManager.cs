using Library.Core.Enums;
using Neshan.Domain.Entities;

namespace Neshan.Infrastructure.Managers
{
    public static class ExtensionManager
    {
        public static IQueryable<ShortUrl> ToSort(this IQueryable<ShortUrl> query, SharedEnums.Sort sort)
        {

            switch (sort)
            {
                case SharedEnums.Sort.ID:
                    return query.OrderBy(o => o.ID);

                case SharedEnums.Sort.ID_desc:
                    return query.OrderByDescending(o => o.ID);

                case SharedEnums.Sort.CreateDate:
                    return query.OrderBy(o => o.CreateDate);

                case SharedEnums.Sort.CreateDate_desc:
                    return query.OrderByDescending(o => o.CreateDate);

                case SharedEnums.Sort.ModifyDate:
                    return query.OrderBy(o => o.CreateDate);

                case SharedEnums.Sort.ModifyDate_desc:
                    return query.OrderByDescending(o => o.CreateDate);

                default:
                    return query.OrderBy(o => o.ID);
            }
        }
    }
}
