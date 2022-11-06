using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Product.Application.Dto;
using System.Product.Domain.Interfaces;
using System.Product.Domain.Models.products;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Product.Application.UseCases.Command.Product
{
   public class ProductActiveHandler : IRequestHandler<ProductActiveCommand, ResulService>
    {


        private const int MarcaActivoRegistro = 0;
        private readonly IProductRepository _ProductRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductActiveHandler(IProductRepository iProductRepository, IUnitOfWork unitOfWork)
        {
            _ProductRepository = iProductRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResulService> Handle(ProductActiveCommand request, CancellationToken cancellationToken)
        {

            try
            {

                Products objPro = await _ProductRepository.FindAllProducrByIdAsync(request.Detail.productId);

                if (objPro != null)
                {

                    objPro.productActivated(MarcaActivoRegistro);
                    await _ProductRepository.UpdateAsync(objPro);
                }
                else
                {
                    return new ResulService { codError = "COD403", messaje = "No existe el producto" };
                }


                await _unitOfWork.Commit();

                return new ResulService { messaje = "Estimado usuario, se activo el producto" };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return new ResulService { success = false, codError = "COD501", messaje = "ERROR al activar el producto" };

        }


    }
}

