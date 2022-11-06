using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Product.Application.Dto;
using System.Product.Application.Dto.Product;
using System.Text;
using System.Threading.Tasks;

namespace System.Product.Application.UseCases.Command.Product
{
    public class ProductModifiedCommand : IRequest<ResulService>
    {
        public RequestProductModified Detail { get; set; }
        private ProductModifiedCommand() { }

        public ProductModifiedCommand(RequestProductModified detail)
        {
            Detail = detail;
        }
    }
}
