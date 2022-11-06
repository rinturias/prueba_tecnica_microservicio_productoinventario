using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Product.Application.Dto;
using System.Product.Application.Dto.Product;
using System.Text;
using System.Threading.Tasks;

namespace System.Product.Application.UseCases.Queries.Product.searchProduct
{
   public class ListAllProductsQuery : IRequest<ResulService>
    {
        public ListAllProductsQuery() { }
        public ListAllProductsQuery(Guid requestIdProducto)
        {
            searchProductoID = requestIdProducto;
        }
        public Guid searchProductoID { get; set; }
    }
}
