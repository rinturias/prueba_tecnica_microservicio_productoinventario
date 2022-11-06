using Sharedkernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Product.Domain.Models.category
{
  public  class Category : AggregateRoot<Guid>
    {
        public string name { get; private set; }
        public int active { get; private set; }

    }
}
