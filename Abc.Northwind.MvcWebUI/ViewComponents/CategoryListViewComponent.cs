using Abc.Northwind.Business.Abstract;
using Abc.Northwind.MvcWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace Abc.Northwind.MvcWebUI.ViewComponents
{
    public class CategoryListViewComponent:ViewComponent
    {
        private ICategoryService _categoryService;
        public CategoryListViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService; 
        }
        //public ViewViewComponentResult Invoke(): Bu metot, View Component'in çalıştırıldığında çağrılan ana metottur.
        //View Component, bir controller aksiyonu gibi çağrılabilir ve
        //genellikle bir Razor view (cshtml) dosyasını döndürerek belirli bir görsel bileşeni temsil eder.----->
        public ViewViewComponentResult Invoke()
        {
            var model = new CategoryListViewModel()
            {
                Categories = _categoryService.GetAll(),
                //mevcut kategoriyi de yollayabilmeliyiz bu sebeple:
                CurrentCategory = Convert.ToInt32(HttpContext.Request.Query["category"])//25.08
            };
            return View(model);
        }
        //----> bu kod parçacığı :Sonuç olarak, bu örnek kod parçası bir View Component'i temsil eder.
        //Çağrıldığında, ilgili Razor view dosyasını döndürerek belirli bir görsel bileşeni oluşturur.
        //Bu sayede, bu View Component'i farklı sayfalar veya bölgeler arasında
        //tekrar kullanabilir ve kodun tekrarını önleyebilirsiniz.


        
    }
}
