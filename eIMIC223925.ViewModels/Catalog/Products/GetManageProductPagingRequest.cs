using eIMIC223925.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace eIMIC223925.ViewModels.Catalog.Products
{
    public class GetManageProductPagingRequest: PagingRequestBase
    {
        public string Keyword { get; set; }
        public List<int> CategoryIds { get; set; }
    }
}
