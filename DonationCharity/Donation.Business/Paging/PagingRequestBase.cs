using System;
using System.Collections.Generic;
using System.Text;

namespace Donation.Business.Paging
{
    public class PagingRequestBase
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
