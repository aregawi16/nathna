using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatnaAgencyDigitalSystem.Core.Models.Common
{
    public class Pageable : IPageable
    {

        public Pageable()
        {

        }

        private Pageable(int pageNumber, int pageSize)
        {
            if (pageNumber < 0)
                throw new ArgumentNullException(nameof(pageNumber), "Page Number must not be less than zero!");

            if (pageSize < 1) throw new ArgumentNullException(nameof(pageSize), "Page Size must not be less than one!");

            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        public int Id { get; set; } = 0;
        public string? Name { get; set; } = null;
        public int PageNumber { get; set; } = 0;
        public int PageSize { get; set; }

        int IPageable.Offset => PageNumber * PageSize;

        public static Pageable Of(int pageNumber, int pageSize)
        {
            return new Pageable(pageNumber, pageSize);
        }
    }
    public interface IPageable
    {
        int Offset { get; }
        int PageNumber { get; set; }
        int PageSize { get; set; }
    }

}
