namespace Abc.Northwind.Entities.Concrete
{
    // sepetimiz 1.09
    public class Cart
    {
        public Cart() {
            CartLines = new List<CartLine>();
        }
        public List<CartLine> CartLines { get; set; } 
        public decimal Total
        {
            get { return CartLines.Sum(c=>c.Product.UnitPrice*c.Quantity);}
        }
        public List<CartItem> Items { get; set; }

        // Toplam ürün sayısı
        public int TotalItems
        {
            get { return Items.Sum(item => item.Quantity); }
        }

        // Toplam fiyat
        public decimal TotalPrice
        {
            get { return Items.Sum(item => item.Price * item.Quantity); }
        }
    }

    public class CartItem
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}

