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
    class ProductModifiedHandler : IRequestHandler<ProductModifiedCommand, ResulService>
    {

        private readonly IProductRepository _ProductRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductModifiedHandler(IProductRepository iProductRepository, IUnitOfWork unitOfWork)
        {
            _ProductRepository = iProductRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResulService> Handle(ProductModifiedCommand request, CancellationToken cancellationToken)
        {

            try
            {

                Products objPro = await _ProductRepository.FindByIdAsync(request.Detail.productId);

                if (objPro != null)
                {

                    objPro.productModified(request.Detail.name, request.Detail.description, request.Detail.price, request.Detail.stock, request.Detail.categoryId);
                    await _ProductRepository.UpdateAsync(objPro);
                }
                else
                {
                    return new ResulService { codError = "COD403", messaje = "No existe el producto" };
                }


                await _unitOfWork.Commit();

                return new ResulService { messaje = "Estimado usuario, se modifico el producto" };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return new ResulService { success = false, codError = "COD501", messaje = "ERROR al modificar el producto" };

        }


    }
}
