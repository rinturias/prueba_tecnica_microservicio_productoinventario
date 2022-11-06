using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Product.Domain.Interfaces;
using System.Product.Domain.Models.kardex;
using System.Product.Infrastructure.EF.Context;
using System.Text;
using System.Threading.Tasks;

namespace System.Product.Infrastructure.Repositories
{
    public class KardexRepository : IKardexRepository
    {
        public readonly DbSet<Kardex> _Kardex;

        public KardexRepository(WriteDbContext context)
        {
            _Kardex = context.Kardex;
        }
        public async Task CreateAsync(Kardex obj)
        {
            await _Kardex.AddAsync(obj);
        }

        public async Task<Kardex> FindByIdAsync(Guid id)
        {
            return await _Kardex.AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id && x.active == 0);
        }

        public async Task SaveDetalleAsync(ICollection<Kardex> obj)
        {
            await _Kardex.AddRangeAsync(obj);
        }

        public Task UpdateAsync(Kardex obj)
        {
            _Kardex.Update(obj);
            return Task.CompletedTask;
        }
    }
}
