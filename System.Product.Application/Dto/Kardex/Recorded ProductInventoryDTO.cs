using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Product.Application.Dto.Kardex
{
   public class RecordedProductInventoryDTO
    {

        //public string description { get; set; }
        //public string codeOperation { get; set; }
        //public int quantityInput { get; set; }
        //public int quantityOut { get; set; }
        //public decimal priceUnit { get; set; }
        //public DateTime date { get; set; }
        //public Products product { get; set; }
        //public Guid userId { get; set; }

        public DateTime date { get; set; }
        public string note { get; set; }

        public Guid clienteId { get; set; }
        public Guid userId { get; set; }

        public decimal amountTotal { get; set; }

        public decimal amountNominal { get; set; }

        public decimal discount { get; set; }

        public decimal iva { get; set; }
        public string status { get; set; }

        public List<RequestProductInventoryDTO> productInventory { get; set; }
    }
}
