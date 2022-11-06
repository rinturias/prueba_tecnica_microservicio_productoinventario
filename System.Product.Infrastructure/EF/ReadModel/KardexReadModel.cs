using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Product.Infrastructure.EF.ReadModel
{
  public  class KardexReadModel
    {
        public Guid Id { get; set; }
        public string description { get;  set; }
        public string codeOperation { get; set; }
        public int quantityInput { get;  set; }
        public int quantityOut { get;  set; }
        public decimal priceUnit { get;  set; }
        public DateTime date { get; set; }
        public ProductReadModel  product { get;  set; }
        public Guid userId { get;  set; }

        public int active { get; set; }
    }
}
