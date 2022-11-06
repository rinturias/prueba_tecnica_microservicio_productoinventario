using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Product.Application.Dto;
using System.Product.Application.UseCases.Queries.Product.searchProduct;
using System.Product.Infrastructure.EF.Context;
using System.Product.Infrastructure.EF.ReadModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Product.Infrastructure.EF.UseCases.Queries.Product
{
  public class SearchProductsHandler :IRequestHandler<ListAllProductsQuery, ResulService>
    {

        private readonly DbSet<ProductReadModel> _ProductReadModel;


        public SearchProductsHandler(ReadDbContext context)
        {
            _ProductReadModel = context.Product;
 
        }
        public async Task<ResulService> Handle(ListAllProductsQuery request, CancellationToken cancellationToken)
        {

            var stringMensaje = "listado 100 primeros productos";
            var vcodError = "COD200";

            dynamic vueloList;
             
            if(request.searchProductoID.ToString() == "00000000-0000-0000-0000-000000000000")
            {

                vueloList= await _ProductReadModel
              .AsNoTracking()
              .Where(x => x.active == 0)
               .Take(100).ToListAsync();
               
            }
            else
            {
              vueloList = await _ProductReadModel
           .AsNoTracking()
           .Where(x => x.active == 0 && x.Id== request.searchProductoID)
            .Take(100).ToListAsync();
             stringMensaje = "datos del idProducto: "+request.searchProductoID.ToString();
            }

            if (vueloList == null)
            {
                stringMensaje = "No existe registros de productos";
                vcodError = "COD403";
            }

            return new ResulService { data = vueloList, messaje = stringMensaje, codError = vcodError };

        }

    }
}
