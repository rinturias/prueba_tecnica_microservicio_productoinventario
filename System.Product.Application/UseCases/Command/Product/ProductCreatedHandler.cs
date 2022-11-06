using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Product.Application.Dto;
using System.Product.Domain.Factories;
using System.Product.Domain.Interfaces;
using System.Product.Domain.Models.products;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Product.Application.UseCases.Command.Product
{
    public class ProductCreatedHandler : IRequestHandler<ProductCreatedCommand, ResulService>
    {
        private const int MarcaAltaRegistro= 0;
        private readonly IProductRepository _ProductRepository;
        private readonly IProductFactory _IProductFactory;
        private readonly IUnitOfWork _unitOfWork;

        public ProductCreatedHandler(IProductFactory iProductFactory, IProductRepository iProductRepository, IUnitOfWork unitOfWork)
        {
            _ProductRepository = iProductRepository;
            _IProductFactory = iProductFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResulService> Handle(ProductCreatedCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Products objProduct =  _IProductFactory.Create(request.Detail.name,request.Detail.description,request.Detail.price,
                request.Detail.stock,request.Detail.categoryId,request.Detail.userId, MarcaAltaRegistro);
                objProduct.consolidatedProduct();

                await _ProductRepository.CreateAsync(objProduct);
                await _unitOfWork.Commit();

                return new ResulService { data = objProduct.Id, messaje = "producto creado correctamente" };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new ResulService { success = false, error = ex.Message, codError = "COD501", messaje = "ERROR al crear el producto" };
            }
        
        }
    }
}
