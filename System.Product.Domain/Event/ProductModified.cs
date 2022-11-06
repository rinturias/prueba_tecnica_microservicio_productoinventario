using Sharedkernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Product.Domain.Models.products;
using System.Text;
using System.Threading.Tasks;

namespace System.Product.Domain.Event
{
   public class productModified : DomainEvent 
    { 
    public Products _product { get; private set; }
    public productModified(Products product) : base(DateTime.Now)
    {

        _product = product;


    }
}
}
