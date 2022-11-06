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
    public class ProductCreatedCommand : IRequest<ResulService>
    {
        public RequestProductHigh Detail { get; set; }
        private ProductCreatedCommand() { }

        public ProductCreatedCommand(RequestProductHigh detail)
        {
            Detail = detail;
        }

    }
}
