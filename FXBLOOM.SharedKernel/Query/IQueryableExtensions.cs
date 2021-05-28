using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FXBLOOM.SharedKernel.Query
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> GetPagedData<T>(
            this IQueryable<T> queryable,
            PagedQueryRequest request)
        {
            return queryable.Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize);
        }

        public static async Task<PagedQueryResult<TOut>> ToPagedResult<T, TOut>(
            this IQueryable<T> source,
            int pageNumber,
            int pageSize)
        {
            var totalItemCount = await source.CountAsync();

            pageSize = pageSize < 1 ? totalItemCount : pageSize;

            var totalPageCount = totalItemCount == 0 ? 1 : (totalItemCount + pageSize - 1) / pageSize;
            pageNumber = Math.Max(1, Math.Min(pageNumber, totalPageCount));

            var startIndex = (pageNumber - 1) * pageSize;

            var items = await source
                .Skip(startIndex)
                .Take(pageSize)
                .ProjectTo<TOut>()
                .ToListAsync();

            return new PagedQueryResult<TOut>
            {
                Items = items,
                TotalPageCount = totalPageCount,
                CurrentPageNumber = pageNumber,
                CurrentPageSize = pageSize,
                TotalItemCount = totalItemCount
            };
        }

        public static bool RelatedEntityExists<T>(this IQueryable<T> set, Func<T, bool> expression)
            where T : class
        {
            return set.Any(expression);
        }
    }
}
