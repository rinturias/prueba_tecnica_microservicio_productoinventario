using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Product.Application.Dto.Product
{
   public class RequestProductModified
    {
        public Guid productId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public int stock { get; set; }
        public Guid categoryId { get; set; }

    }
}
