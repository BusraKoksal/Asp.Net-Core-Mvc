using Microsoft.AspNetCore.Mvc;
using Abc.Northwind.MvcWebUI.Services;
using Abc.Northwind.Business.Abstract;
using Abc.Northwind.MvcWebUI.Controllers.ViewComponents;

namespace Abc.Northwind.MvcWebUI.Controllers
{//4.9.23:
    public class CartController : Controller
    {   private ICartSessionService _sessionService;
        private ICartSessionService _cartSessionService;
        private ICartService _cartService;
        private IProductService _productService;
        public CartController(ICartSessionService cartSessionService,
            ICartService cartService, 
            IProductService productService)
        {
            _cartSessionService = cartSessionService;  
            _cartService = cartService;
            _productService = productService;
        }   public ActionResult AddToCart(int productId)
        {
            var productToBeAdded=_productService.GetById (productId);
            //sepete ulaşmamız lazım
            var cart = _cartSessionService.GetCart();
            _cartService.AddToCart(cart, productToBeAdded); 
            //cart nesnesini tekrar sessiona atmamız gerekiyor yani:
            _cartSessionService.SetCart(cart);

            TempData.Add("message", String.Format("Your product ,{0},was successfully added to the cart!",
            productToBeAdded.ProductName));             //tempdata sadece tek bir requestlik veri taşır.
                                                        //yani gittiğimiz sayfada mesaj göstermek istiyorsak
            return RedirectToAction("List","Product" ); }   
         public ActionResult List()
        {
            var cart =_cartSessionService.GetCart();
            CartListViewModel cartListViewModel = new CartListViewModel
            { Cart = cart  }; return View(cartListViewModel);

        }

    
    }
}
