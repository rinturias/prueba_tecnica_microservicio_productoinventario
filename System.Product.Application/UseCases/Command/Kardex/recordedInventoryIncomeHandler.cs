using MediatR;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Product.Application.Dto;
using System.Product.Domain.Factories;
using System.Product.Domain.Interfaces;
using System.Product.Domain.Models.products;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Product.Application.UseCases.Command.Kardex
{
   public class recordedInventoryIncomeHandler : IRequestHandler<recordedInventoryIncomeCommand, ResulService>
    {
       const string COD_OPERACION = "VENTA";
        private readonly IProductRepository _ProductRepository;
        private readonly IKardexRepository _IKardexRepository;
        private readonly IProductFactory _IProductFactory;
        private readonly IKardexFactory _IKardexFactory;
        private readonly IUnitOfWork _unitOfWork;

        public recordedInventoryIncomeHandler(IProductFactory iProductFactory, IProductRepository iProductRepository, IKardexRepository iKardexRepository, IKardexFactory iKardexFactory, IUnitOfWork unitOfWork)
        {
            _ProductRepository = iProductRepository;
            _IProductFactory = iProductFactory;
            _IKardexFactory = iKardexFactory;
            _IKardexRepository = iKardexRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResulService> Handle(recordedInventoryIncomeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                string description = "Salida por venta";
                int marcaAltaRegitro = 0;
                //ICollection<Products> _DetalleProductStock = new Collection<Products>();
                Domain.Models.kardex.Kardex objKardex = _IKardexFactory.CreateInit();
                var objProductoFactory = new Products();
                foreach (var item in request.Detail.productInventory)
                {
                    Products objProduct = await _ProductRepository.FindByIdAsync(item.productId);
                    if (objProduct != null)
                    {
                        int stockActual = objProduct.stock;
                        objKardex.AgregarItem(description, COD_OPERACION, stockActual, item.amount, item.price, item.productId, request.Detail.userId, marcaAltaRegitro);
                        objProductoFactory.updatedStock(objProduct.Id, objProduct.name, objProduct.description, objProduct.price, objProduct.stock, item.amount, objProduct.categoryId, objProduct.userId, objProduct.active);
                    }
                    else
                    {
                        return new ResulService { codError = "COD503", messaje = "No existe el producto... proceso de rollback" };
                    }

                }
                objKardex.consolidateKardex();
          
              
                await _IKardexRepository.SaveDetalleAsync(objKardex._KardexAlta);
                await _ProductRepository.UpdateDetalleStockAsync(objProductoFactory._DetalleProductStock);

                await _unitOfWork.Commit();

                return new ResulService {  messaje = "Karder creado correctamente" };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new ResulService { success = false, error = ex.Message, codError = "COD501", messaje = "ERROR al crear el detalle de inventario" };
            }

        }
    }
}