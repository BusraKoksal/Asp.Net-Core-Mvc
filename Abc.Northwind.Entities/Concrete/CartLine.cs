using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Abc.Northwind.Entities.Concrete
{
    //1.09-_-_-> 
    // CartLine yani sepetteki her bir eleman.
    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; } // sessions da tutacağımız sepetin herbir elamanı
        public decimal Price { get; set; }
        public CartItem Items { get; set; }
    }
}
