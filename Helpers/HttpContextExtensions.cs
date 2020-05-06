using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crowdfunding_API.Helpers
{
    //this class helps with pagination implementation
    public static class HttpContextExtensions
    {
        public async static Task InsertPaginationParametersInResponse<T>(this HttpContext httpContext, IQueryable<T> querable, int recordsPerPage)
        {
            if (httpContext == null) { throw new ArgumentException(nameof(httpContext)); }

            double count = await querable.CountAsync();
            double totalAamountPages = Math.Ceiling(count / recordsPerPage);
            httpContext.Response.Headers.Add("totalAmountPages", totalAamountPages.ToString());
        }
    }
}
