using MassTransit;
using MediatR;
using Sharedkernel.IntegrationEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Product.Application.Dto.Kardex;
using System.Product.Application.UseCases.Command.Kardex;
using System.Product.Domain.Models.products;
using System.Text;
using System.Threading.Tasks;

namespace System.Product.Application.UseCases.Consumers
{
   public class SaleMadeConsumer : IConsumer<SaleRegister>
    {
        private readonly IMediator _mediator;
        public const string ExchangeName = "sale-mode-exchange";
        public const string QueueName = "sale-mode-inventory";

        public SaleMadeConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<SaleRegister> context)
        {
            SaleRegister @event = context.Message;

            Console.WriteLine(@event);
           var listDetailProduct = new List<RequestProductInventoryDTO>();

            foreach (var item in @event.detalleSale)
            {

                RequestProductInventoryDTO ObjProduct = new RequestProductInventoryDTO() { 
                 productId=item.productId,
                 categoryId=item.categoryId,
                 amount=item.quantity,
                 price = item.price,

                };  
            

                listDetailProduct.Add(ObjProduct);

            }


            RecordedProductInventoryDTO objDto = new()
            {
                date = @event.date,
                note=@event.note,
                clienteId = @event.clienteId,
                userId = @event.userId,
                amountTotal = @event.amountTotal,
                amountNominal = @event.amountNominal,
                discount = @event.discount,
                iva=@event.iva,
                status=@event.status,
                productInventory = listDetailProduct

            };

            recordedInventoryIncomeCommand command = new recordedInventoryIncomeCommand(objDto);

            await _mediator.Send(command);

        }
    }
}
