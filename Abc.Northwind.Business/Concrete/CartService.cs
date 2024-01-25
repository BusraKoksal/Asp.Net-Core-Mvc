using Abc.Northwind.Business.Abstract;
using Abc.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abc.Northwind.Business.Concrete
{
    //01.09.23
    public class CartService : ICartService
    {   public void AddToCart(Cart cart, Product product)
        {
            // önce sepeti kontrol etmeliyiz;öyle bir ürün var mı diye
            CartLine cartLine=cart.CartLines.FirstOrDefault(c=>c.Product.ProductId==product.ProductId);
                                             //cartlinesi gez
           if (cartLine!=null)  //----->sepette ürün varsa ekle
            {
                cartLine.Quantity++; //sepette aynı üründen varsa arttır
                return;
            }
         cart.CartLines.Add(new CartLine { Product=product,Quantity=1 }); // yoksa 1 değeri ver.
           
        }
        public void RemoveFromCart(Cart cart, int productId)
        { cart.CartLines.Remove(cart.CartLines.FirstOrDefault(c=> c.Product.ProductId==productId));   }
        public List<CartLine> List(Cart cart)
        { return cart.CartLines; }

        public Cart GetCart()
        {
            throw new NotImplementedException();
        }
    }
}
