using Sharedkernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Product.Domain.Models.category;
using System.Product.Domain.Models.products;
using System.Text;
using System.Threading.Tasks;

namespace System.Product.Domain.Event
{
   public class productCreated : DomainEvent
    {
        public Products product { get; set; }
        public productCreated(Products product, DateTime occuredOn) : base(occuredOn)
        {
            this.product = product;

        }
    }
}
