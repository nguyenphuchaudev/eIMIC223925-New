using eIMIC223925.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace eIMIC223925.ViewModels.Catalog.Products
{
    public class GetPublicProductPagingRequest: PagingRequestBase
    {
        public int? CategoryId { get; set; }
    }
}
