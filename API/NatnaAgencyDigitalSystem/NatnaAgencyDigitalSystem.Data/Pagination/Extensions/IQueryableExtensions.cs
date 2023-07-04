using NatnaAgencyDigitalSystem.Core.Models.Common;
using NatnaAgencyDigitalSystem.Data.Pagination.Binders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NatnaAgencyDigitalSystem.Data.Pagination.Extensions
{
    public static class QueryableExtensions
    {
        public static Page<TEntity> UsePageable<TEntity>(this IQueryable<TEntity> receiver, IPageable pageable)
            where TEntity : class
        {
            pageable.PageSize = pageable.PageSize == 0 ? PageableBinderConfig.DefaultMaxPageSize : pageable.PageSize;

            var entities = receiver.Skip(pageable.Offset)
                .Take(pageable.PageSize);
            return new Page<TEntity>(entities.ToList(), pageable, receiver.Count());
        }

        public static Page<TEntity> UsePageable<TEntity>(this IEnumerable<TEntity> receiver, IPageable pageable)
           where TEntity : class
        {
            pageable.PageSize = pageable.PageSize == 0 ? PageableBinderConfig.DefaultMaxPageSize : pageable.PageSize;

            var entities = receiver.Skip(pageable.Offset)
                .Take(pageable.PageSize);
            return new Page<TEntity>(entities.ToList(), pageable, receiver.Count());
        }
    }
}
