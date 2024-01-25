using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abc.Northwind.Entities.Concrete;
using System.Text.Json;
using Newtonsoft.Json;


using Microsoft.AspNetCore.Http;
using Abc.Northwind.MvcWebUI.Middlewares;

namespace Abc.Northwind.MvcWebUI.Services
{
    public class CartSessionService: ICartSessionService  //-->concrete versiyonu
    {
        //sessionlar controller odaklı nesnelerdir. burada kullanmak için:--->
        private IHttpContextAccessor _httpContextAccessor;  //<---
        public CartSessionService(IHttpContextAccessor httpContextAccessor) { 
            _httpContextAccessor = httpContextAccessor;
        
        }

        public Cart GetCart()
        {
            Cart cartToCheck = _httpContextAccessor.HttpContext.Session.GetObject<Cart> ("cart");
            if(cartToCheck == null )
            {
                //sepet boşsa ilk kez oluşturmak için yapılıyor.
                _httpContextAccessor.HttpContext.Session.SetObject("cart",new Cart());
                cartToCheck = _httpContextAccessor.HttpContext.Session.GetObject <Cart> ("cart");
            }
            return cartToCheck;
        }

        public void SetCart(Cart cart)
        {
            _httpContextAccessor.HttpContext.Session.SetObject("cart", new Cart());
        }

    }
    
    
}
