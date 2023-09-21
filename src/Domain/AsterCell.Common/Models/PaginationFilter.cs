using AsterCell.Common.Enums;

namespace AsterCell.Common.Models
{
    public class PaginationFilter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SortColumn { get; set; }
        public SortDirectionEnum SortDirection { get; set; } = SortDirectionEnum.Ascending;

        public PaginationFilter()
        {
            PageNumber = 1;
            PageSize = 1;
        }

        public PaginationFilter(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
