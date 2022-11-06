using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Product.Application.Dto;
using System.Product.Application.Dto.Kardex;
using System.Text;
using System.Threading.Tasks;

namespace System.Product.Application.UseCases.Command.Kardex
{
  public  class recordedInventoryIncomeCommand : IRequest<ResulService>
    {
        public RecordedProductInventoryDTO Detail { get; set; }
        private recordedInventoryIncomeCommand() { }

        public recordedInventoryIncomeCommand(RecordedProductInventoryDTO detail)
        {
            Detail = detail;
        }
    }
}
