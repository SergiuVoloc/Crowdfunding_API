using Crowdfunding_API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crowdfunding_API.Helpers
{
    //this class helps with pagination implementation
    public static class QueryableExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, PaginationDTO pagination)
        {
            return queryable
             .Skip((pagination.Page - 1) * pagination.RecordsPerPage)
            .Take(pagination.RecordsPerPage);
        }
    }
}
