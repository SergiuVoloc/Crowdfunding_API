using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crowdfunding_API.DTOs
{
    public class PaginationDTO
    {
        public int Page { get; set; } = 1;
        public int recordsPerPage = 10;
        public readonly int maxRecordsPerPage = 50;

        public int RecordsPerPage
        {
            get
            {
                return recordsPerPage;
            }
            set
            {
                recordsPerPage = (value > maxRecordsPerPage) ? maxRecordsPerPage : value;
                // user can indicate how many recors per page shoud be displayed but if
                // the value indicated is bigger than maxRecordsPerPage allowed (witch is 50)
                // the amount of recors per page will be maxRecorsPerPage.
            }
        }
    }
}
