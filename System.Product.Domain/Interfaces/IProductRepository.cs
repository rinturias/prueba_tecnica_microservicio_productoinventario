using Sharedkernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Product.Domain.Models.products;
using System.Text;
using System.Threading.Tasks;

namespace System.Product.Domain.Interfaces
{
    public   interface IProductRepository : InterfaceGeneric<Products, Guid>
    {
        Task UpdateAsync(Products obj);
        Task<Products> FindAllProducrByIdAsync(Guid id);

        Task UpdateDetalleStockAsync(ICollection<Products> obj);
    }

}

