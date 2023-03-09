using Application.Dtos;

namespace Application.Helpers
{
    public static class EntityFrameworkHelper
    {
        private static IQueryable<T> GetPage<T>(IQueryable<T> query, int page, int pageSize, PagedResponseDto<T> result) where T : class
        {
            result.CurrentPage = page;
            result.PageSize = pageSize;
            result.RowCount = query.Count();

            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            var skip = (page - 1) * pageSize;
            return query.Skip(skip).Take(pageSize);
        }

        public static async Task<PagedResponseDto<T>> GetPagedAsync<T>(
           this IQueryable<T> query,
           int page,
           int pageSize) where T : class
        {
            var result = new PagedResponseDto<T>();
            var pagedQuery = GetPage(query, page, pageSize, result);
            result.Results = pagedQuery.ToList();
            return result;
        }
    }
}
