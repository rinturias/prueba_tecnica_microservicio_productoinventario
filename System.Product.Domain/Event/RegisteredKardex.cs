using Sharedkernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Product.Domain.Models.kardex;
using System.Text;
using System.Threading.Tasks;

namespace System.Product.Domain.Event
{
    public class RegisteredKardex : DomainEvent
    {
        public Kardex kardexMade { get; set; }
        public RegisteredKardex(Kardex kardex, DateTime occuredOn) : base(occuredOn)
        {
            kardexMade = kardex;

        }
    }
}