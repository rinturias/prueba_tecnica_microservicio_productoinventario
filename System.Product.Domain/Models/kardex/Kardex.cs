using Sharedkernel.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Product.Domain.Event;
using System.Product.Domain.ValueObjects;
using System.Text;
using System.Threading.Tasks;

namespace System.Product.Domain.Models.kardex
{
    public class Kardex : AggregateRoot<Guid>
    {
        public StringEmptyValue description { get; private set; }
        public string codeOperation { get; set; }
        public CantidadValueConCero quantityInput { get; private set; }
        public CantidadValueConCero quantityOut { get; private set; }
        public PrecioValue priceUnit { get; private set; }
        public DateTime date { get; set; }
        public Guid productId { get; private set; }
        public Guid userId { get; private set; }
        public int active { get; private set; }

        public readonly ICollection<Kardex> _KardexAlta;

        public IReadOnlyCollection<Kardex> KardeDetatail
        {
            get
            {
                return new ReadOnlyCollection<Kardex>(_KardexAlta.ToList());
            }
        }
        internal Kardex()
        {
            Id = Guid.NewGuid();
            _KardexAlta  = new List<Kardex>();
            this.date = DateTime.UtcNow;
        }
        internal Kardex( StringEmptyValue description,string codeOperation, CantidadValueConCero quantityInput , CantidadValueConCero quantityOut,
            PrecioValue priceUnit,  Guid productId, Guid userId, int active)
        {
            Id = Guid.NewGuid();
            this.description = description;
            this.codeOperation = codeOperation;
            this.quantityInput = quantityInput;
            this.quantityOut = quantityOut;
            this.userId = userId;
            this.active = active;
            this.productId = productId;
            this.date = DateTime.UtcNow;
            this.priceUnit = priceUnit;
        }
        internal void ModificarKardex(CantidadValueConCero quantityInput, CantidadValueConCero quantityOut,PrecioValue priceUnit)
        {

            this.quantityInput = quantityInput;
            this.quantityOut = quantityOut;
            this.priceUnit = priceUnit;
        }
        public void AgregarItem(StringEmptyValue description, string codeOperation, CantidadValueConCero quantityInput, CantidadValueConCero quantityOut,
            PrecioValue priceUnit, Guid productId, Guid userId, int active)
        {

            var detailsProduct = _KardexAlta.FirstOrDefault(x => x.productId == productId);
            if (detailsProduct is null)
            {
                detailsProduct = new Kardex(description, codeOperation, quantityInput, quantityOut, priceUnit, productId, userId, active);
                _KardexAlta.Add(detailsProduct);
            }
            else
            {
                detailsProduct.ModificarKardex(quantityInput, quantityOut, priceUnit);
            }

        }

        public void consolidateKardex()
        {
            var evento = new RegisteredKardex(this, DateTime.Now);
            AddDomainEvent(evento);
        }
    }
}
