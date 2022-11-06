using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Product.Infrastructure.EF.ReadModel
{
   public class ProductReadModel
    {
       
        public Guid Id { get; set; }
        public string name { get;  set; }
        public string description { get;  set; }
        public decimal price { get;  set; }
        public int stock { get;  set; }

        public Guid categoryId { get;  set; }
        public Guid userId { get;  set; }

        public int active { get; set; }
    }
}
