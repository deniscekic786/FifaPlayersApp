using System.Collections.Generic;
using System.Linq;

namespace FifaFanApp.Helpers
{
    /// <summary>
    /// Extention methods used to help get a page count and also limit the
    /// amount of objects we want per page
    /// </summary>
        public static class PagingExtensions
        {
        //get page count
            public static int PageCount(int totalRecords, int pageSize)
            {
            return (totalRecords + pageSize - 1) / pageSize;
            }

           
            //used by LINQ to SQL
            public static IQueryable<TSource> Page<TSource>(this IQueryable<TSource> source, int page, int pageSize)
            {
                return source.Skip((page - 1) * pageSize).Take(pageSize);
            }

            //used by LINQ
            public static IEnumerable<TSource> Page<TSource>(this IEnumerable<TSource> source, int page, int pageSize)
            {
                return source.Skip((page - 1) * pageSize).Take(pageSize);
            }
    }
}