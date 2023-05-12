using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Inventory_Management_System.Models {
    public class SampleOrder {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string ShipCountry { get; set; }
        public string ShipCity { get; set; }
    }
}
