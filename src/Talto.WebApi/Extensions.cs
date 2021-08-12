using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Talto.WebApi
{
    public static class Extensions
    {
        /// <summary>
        /// Filtra uma query por data de início e data de fim, se houver.
        /// </summary>
        /// <typeparam name="TSource">O tipo do objeto.</typeparam>
        /// <param name="source">A query fonte.</param>
        /// <param name="func">Um método que receba o objeto e devolva um <see cref="DateTime"/> para a filtragem.</param>
        /// <param name="startDate">A data de início.</param>
        /// <param name="endDate">A data de término.</param>
        /// <returns>O <see cref="IQueryable{TSource}"/></returns>
        public static IQueryable<TSource> FilterByDateRange<TSource>(
            this IQueryable<TSource> source, Func<TSource, DateTime> func, DateTime? startDate, DateTime? endDate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (func == null) throw new ArgumentNullException(nameof(func));

            if (startDate.HasValue && !endDate.HasValue)
                return source.Where(o => func(o) >= startDate);
            else if (!startDate.HasValue && endDate.HasValue)
                return source.Where(o => func(o) <= endDate);
            else if (startDate.HasValue && endDate.HasValue)
                return source.Where(o => func(o) >= startDate && func(o) <= endDate);
            else
                return source;
        }
    }
}
