using Sharedkernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Product.Domain.Models.products;
using System.Text;
using System.Threading.Tasks;

namespace System.Product.Domain.Event
{
    public class ProductDeactivated : DomainEvent
    {
        public Products _product { get; private set; }
        public ProductDeactivated(Products product) : base(DateTime.Now)
        {

            _product = product;


        }
    }
}
