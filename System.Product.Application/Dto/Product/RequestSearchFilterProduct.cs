using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Product.Application.Dto.Product
{
   public class RequestSearchFilterProduct
    {
        public Guid productoId { get; set; }

        public bool listAllProducto { get; set; } = false;
    }
}
