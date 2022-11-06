using System.Product.Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharedkernel.Core;
using System.Product.Domain.Event;

namespace System.Product.Domain.Models.products
{
    public class Products : AggregateRoot<Guid>
    {
        public StringEmptyValue name { get; private set; }
        public string description { get; private  set; }
        public PrecioValue price { get; private set; }
        public CantidadValue stock { get; private set; }
        public Guid categoryId { get; private set; }
        public Guid userId { get; private set; }
        public int active { get; private  set; }

        public readonly ICollection<Products> _DetalleProductStock;
        public Products() {
            _DetalleProductStock = new List<Products>();
        }
        public Products(StringEmptyValue name, string description , PrecioValue price, CantidadValue stock, Guid categoryId, Guid userId,int active)
        {
            Id = Guid.NewGuid();
            this.name = name;
            this.description = description;
            this.price = price;
            this.stock = stock;
            this.categoryId = categoryId;
            this.userId = userId;
            this.active = active;
           
        }
        internal Products(Guid idProducto, StringEmptyValue name, string description, PrecioValue price, CantidadValue stock, Guid categoryId, Guid userId, int active)
        {
            Id = idProducto;
            this.name = name;
            this.description = description;
            this.price = price;
            this.stock = stock;
            this.categoryId = categoryId;
            this.userId = userId;
            this.active = active;

        }
        public void consolidatedProduct()
        {
            var evento = new productCreated(this, DateTime.Now);
            AddDomainEvent(evento);
        }

        public void productDeactivated( int pInactive)
        {
            var evento = new ProductDeactivated(this);
            this.active = pInactive;
            AddDomainEvent(evento);
        }

        public void productActivated(int pActive)
        {
            var evento = new ProductActivated(this);
            this.active = pActive;
            AddDomainEvent(evento);
        }
        public void productModified(StringEmptyValue name, string description, PrecioValue price, CantidadValue stock, Guid categoryId)
        {
            var evento = new productModified(this);
            this.name = name;
            this.description = description;
            this.price = price;
            this.stock = stock;
            this.categoryId = categoryId;
            AddDomainEvent(evento);

        }

        public void updatedStock(Guid idProducto, StringEmptyValue name, string description, PrecioValue price, int stockActual, int stockOut, Guid categoryId,Guid UserId,int active)
        {
            
            this.Id = idProducto;
            this.name = name;
            this.description = description;
            this.price = price;
            this.stock = (stockActual - stockOut);
            this.categoryId = categoryId;
            this.userId = UserId;
            this.active = active;
           var evento =new  Products(idProducto,  name,description,  price,  stock,  categoryId,userId,active);
            _DetalleProductStock.Add(evento);

        }
    }
}
