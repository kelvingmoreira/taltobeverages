using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talto.Repository.Models.Helpers;

namespace Talto.WebApi.Pagination
{
    //adaptado de https://codewithmukesh.com/blog/pagination-in-aspnet-core-webapi/
    public class PagedResponse<TResponse>
    {
        public PagedResponse() { }
        public PagedResponse(TResponse data) => Data = data;

        public PagedResponse(TResponse data, PaginationFilter paginationFilter, int totalRecords)
        {
            Data = data;
            PageNumber = paginationFilter.PageNumber;
            PageSize = paginationFilter.PageSize;
            TotalRecords = totalRecords;
        }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int TotalPages => (int)Math.Ceiling(TotalRecords / (double)PageSize);

        public int TotalRecords { get; set; }

        public TResponse Data { get; set; }
    }
}
