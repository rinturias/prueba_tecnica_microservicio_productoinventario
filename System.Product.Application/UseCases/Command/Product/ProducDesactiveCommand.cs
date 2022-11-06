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
  public  class ProducDesactiveCommand : IRequest<ResulService>
    {
        public RequestProductDesactive Detail { get; set; }
        private ProducDesactiveCommand() { }

        public ProducDesactiveCommand(RequestProductDesactive detail)
        {
            Detail = detail;
        }
    }
}
