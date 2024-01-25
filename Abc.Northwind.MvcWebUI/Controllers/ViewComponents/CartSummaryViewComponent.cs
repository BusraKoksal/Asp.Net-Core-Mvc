using Abc.Northwind.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Abc.Northwind.MvcWebUI.Controllers.ViewComponents
{
    //04.09.23
    public class CartSummaryViewComponent : ViewComponent
    {
        private readonly ICartService _cartService;

        public CartSummaryViewComponent(ICartService cartService)
        {
            _cartService = cartService;
        }

        public IViewComponentResult Invoke()
        {
            var cart = _cartService.GetCart(); // Sepet verilerini alma işlemi
            var viewModel = new CartListViewModel
            {
                Cart = cart,
                TotalItems = cart.TotalItems,
                TotalPrice = cart.TotalPrice
            };

            return View(viewModel);
        }
    }
}
