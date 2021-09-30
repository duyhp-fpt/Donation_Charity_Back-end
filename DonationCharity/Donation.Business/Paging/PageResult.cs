using System;
using System.Collections.Generic;
using System.Text;

namespace Donation.Business.Paging
{
    public class PageResult<T> : PagedResultBase
    {
        public List<T> Items { get; set; }
        public int TotalRecord { get; set; }
    }
}
