using System;
using System.Collections.Generic;
using System.Linq;
using System.Product.Domain.Models.kardex;
using System.Product.Domain.ValueObjects;
using System.Text;
using System.Threading.Tasks;

namespace System.Product.Domain.Factories
{
    public class KardexFactory : IKardexFactory
    {
        public Kardex Create(StringEmptyValue description, string codeOperation, CantidadValueConCero quantityInput, CantidadValueConCero quantityOut, PrecioValue priceUnit, Guid productId, Guid userId, int active)
        {
            return new Kardex(description, codeOperation, quantityInput, quantityOut, priceUnit, productId, userId, active);
        }

        public Kardex CreateInit()
        {
            return new Kardex();
        }
    }
}
