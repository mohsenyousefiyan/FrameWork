using System;
using System.Collections.Generic;
using System.Text;

namespace FrameWork.Core.Domain.ApplicationServices.Queries
{
    public class SearchPageingQuery : IQuery
    {
        private int page_size = 10;
        private int page = 1;
        public int PageSize
        {
            get => page_size;
            set
            {
                if (value <= 0)
                    page_size = 10;
                else
                    page_size = value;
            }
        }
        public int Page
        {
            get => page;
            set
            {
                if (value <= 0)
                    page = 1;
                else
                    page = value;
            }
        }
    }
    public class SearchPageingWithDateQuery : SearchPageingQuery
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
