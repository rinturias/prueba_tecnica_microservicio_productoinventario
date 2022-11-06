using Sharedkernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Product.Domain.Models.kardex;
using System.Text;
using System.Threading.Tasks;

namespace System.Product.Domain.Interfaces
{
   public interface IKardexRepository : InterfaceGeneric<Kardex, Guid>
    {
        Task UpdateAsync(Kardex obj);
        Task SaveDetalleAsync(ICollection<Kardex> obj);
    }
}
