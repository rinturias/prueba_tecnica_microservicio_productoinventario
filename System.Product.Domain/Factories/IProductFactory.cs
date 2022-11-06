using System;
using System.Collections.Generic;
using System.Linq;
using System.Product.Domain.Models.products;
using System.Product.Domain.ValueObjects;
using System.Text;
using System.Threading.Tasks;

namespace System.Product.Domain.Factories
{
   public interface IProductFactory
    {
        public Products Create(StringEmptyValue name, string description, PrecioValue price, CantidadValue stock, Guid categoryId, Guid userId, int active);
    }
}
