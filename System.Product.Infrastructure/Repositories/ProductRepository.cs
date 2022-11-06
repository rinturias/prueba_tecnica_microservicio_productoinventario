using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Product.Domain.Interfaces;
using System.Product.Domain.Models.products;
using System.Product.Infrastructure.EF.Context;
using System.Text;
using System.Threading.Tasks;

namespace System.Product.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public readonly DbSet<Products> _Products;

        public ProductRepository(WriteDbContext context)
        {
            _Products = context.Product;
        }
        public async Task CreateAsync(Products obj)
        {
            await _Products.AddAsync(obj);
        }

        public async Task<Products> FindAllProducrByIdAsync(Guid id)
        {
            return await _Products.AsNoTracking()
                 .SingleOrDefaultAsync(x => x.Id == id );
        }

        public async Task<Products> FindByIdAsync(Guid id)
        {
            return await _Products.AsNoTracking()
                 .SingleOrDefaultAsync(x => x.Id == id && x.active == 0);
        }

        public Task UpdateAsync(Products obj)
        {
            _Products.Update(obj);
            return Task.CompletedTask;
        }

        public Task UpdateDetalleStockAsync(ICollection<Products> obj)
        {
            _Products.UpdateRange(obj);
            return Task.CompletedTask;
        }
    }
}
