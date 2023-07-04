using System;
using System.Collections.Generic;

namespace NatnaAgencyDigitalSystem.Core.Models.Common
{
    public class Page<T> where T : class
    {
        public Page(List<T> content, IPageable pageable, int totalItems)
        {
            TotalItems = totalItems;
            PageSize = pageable.PageSize;
            PageNumber = pageable.PageNumber;

            Content = new List<T>();
            if (content != null) Content.AddRange(content);
        }

        public List<T> Content { get; }

        public int TotalItems { get; }

        public int TotalPages => (int)Math.Ceiling(TotalItems / (double)PageSize);

        public int PageNumber { get; }

        public int PageSize { get; }
    }
}