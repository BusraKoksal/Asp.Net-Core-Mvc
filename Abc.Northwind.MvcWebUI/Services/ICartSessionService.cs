using Abc.Northwind.Entities.Concrete;

namespace Abc.Northwind.MvcWebUI.Services
{
    public interface ICartSessionService  //-->abstract versiyonu
    {
        Cart GetCart();
        
        void SetCart(Cart cart);

        
    }
}
