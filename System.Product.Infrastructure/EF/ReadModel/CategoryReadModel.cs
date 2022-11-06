using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Product.Infrastructure.EF.ReadModel
{
   public class CategoryReadModel
    {
      
        public Guid Id { get; set; }
        public string name { get;  set; }
        public int active { get;  set; }


    }
}
