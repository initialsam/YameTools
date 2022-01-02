using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;

namespace YameTools.Extensions
{
    public static class IQueryableExtension
    {
        /// <summary>
        /// 分頁
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="page">第幾頁</param>
        /// <param name="pageSize">一頁幾筆</param>
        /// <returns></returns>
        public static IQueryable<T> Page<T>(this IQueryable<T> @list, int page, int pageSize)
        {
            return @list.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public static IOrderedQueryable<TSource> OrderByWithDirection<TSource, TKey>
            (this IQueryable<TSource> source,
             Expression<Func<TSource, TKey>> keySelector,
             bool isAsc)
        {
            return isAsc
                    ? source.OrderBy(keySelector)
                    : source.OrderByDescending(keySelector);
        }

        public static IOrderedQueryable<TSource> ThenByWithDirection<TSource, TKey>(
         this IOrderedQueryable<TSource> source,
         Expression<Func<TSource, TKey>> keySelector,
         bool isAsc)
        {
            return isAsc
                    ? source.ThenBy(keySelector)
                    : source.ThenByDescending(keySelector);


        }
    }
}
