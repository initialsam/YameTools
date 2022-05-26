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
        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TItem"></typeparam>
        /// <param name="query"></param>
        /// <param name="items"></param>
        /// <param name="filterPattern"></param>
        /// <param name="isOr"></param>
        /// <returns></returns>
        public static IQueryable<T> FilterByItems<T, TItem>(
            this IQueryable<T> query,
            IEnumerable<TItem> items,
            Expression<Func<T, TItem, bool>> filterPattern,
            bool isOr)
        {
            Expression predicate = null;
            foreach (var item in items)
            {
                var itemExpr = Expression.Constant(item);
                var itemCondition = ExpressionReplacer.Replace(filterPattern.Body, filterPattern.Parameters[1], itemExpr);
                if (predicate == null)
                    predicate = itemCondition;
                else
                {
                    predicate = Expression.MakeBinary(isOr ? ExpressionType.OrElse : ExpressionType.AndAlso, predicate,
                        itemCondition);
                }
            }

            if (predicate is null)
            {
                predicate = Expression.Constant(false);
            }

            var filterLambda = Expression.Lambda<Func<T, bool>>(predicate, filterPattern.Parameters[0]);

            return query.Where(filterLambda);

            /// items = items.FilterByItems(
            ///     KeyWordList,
            ///     (x, keyWord) => x.DemoA.Contains(keyWord) || x.DemoB.Contains(keyWord),
            ///     true);
        }
    }
}
