using Abc.Northwind.MvcWebUI.Models;
namespace Abc.Northwind.MvcWebUI.Controllers.ViewComponents
{
    public class CartListViewModel
    {
        public object Cart { get; set; }
        public object TotalItems { get; set; }
        public object TotalPrice { get; set; }
    }
}