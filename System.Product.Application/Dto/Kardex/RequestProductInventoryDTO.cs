using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Product.Application.Dto.Kardex
{
  public  class RequestProductInventoryDTO
    {
        public Guid productId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public int amount { get; set; }
        public Guid saleId { get; set; }
        public Guid categoryId { get; set; }
    }
}
