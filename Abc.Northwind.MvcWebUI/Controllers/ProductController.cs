using Abc.Northwind.Business.Abstract;
using Abc.Northwind.MvcWebUI.Models;
using Microsoft.AspNetCore.Mvc;


namespace Abc.Northwind.MvcWebUI.Controllers
{
    public class ProductController:Controller
    {
        //dependency injection!!
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        //ürünleri sayfalama ve kategoriye göre filtreleme  işlemleri <--25.08-->
        public ActionResult Index(int page=1,int category=0 )// 0 olmasının nedeni tüm ürünleri getirmek 
        {
            int pageSize = 10;
            //var products= _productService GetByCategory(category);//-->getbycategory hata veriyor.Çözümü:
            //var products = _productService.GetAll();
            //HATA DÜZELTME CHATGPT products Değişkeni Çakışması: İki defa products adında bir değişken tanımlamış gibi
            //görünüyorsunuz. İkinci defa var products = _productService.GetAll(); satırını kullandığınızda,
            //önceki products değişkenini ezersiniz ve bu da hata sebebi olabilir. İsim çakışmasını önlemek için
            //farklı isimler kullanabilirsiniz.
            //productsByCategory  allProducts
            var products = _productService.GetByCategory(category);
            //var allProducts = _productService.GetAll();
            ProductListViewModel model =new ProductListViewModel { 
            Products=products.Skip((page-1)*pageSize).Take(pageSize).ToList(),
            //25.08--->        ilk 10 ürünü atla       sonraki 10 ürünü al demek


            //-----> 28.08:
            PageCount=(int)Math.Ceiling(products.Count/(double)pageSize),
            PageSize=pageSize,
            CurrentCategory=category,
            CurrentPage=page,
            
            }; 



            return View(model);//-->içine direkt products yazarsak
                          //ileride başka birşeyi de o sayfaya göndermek istersek(encapsulation oalyına denk gelir.)
                          //bu açıdan bizim view model oluşturmamız gerekir.23.08
        }

        private object PageCount(int v)
        {
            throw new NotImplementedException();
        }
        //business concrete de bulunan productmanagere ulaşmamız gerekiyor.23.08
        //productmanageri direk kullanmak yerine productmanagerin soyutu olan IProductservicesi çağırmalıyız.

        //31.08-_-_->
        //public string Sessions()
        //{
        //    HttpContext.Session.SetString("city", "Ankara");
        //    HttpContext.Session.SetInt32("age", 32);

        //    HttpContext.Session.GetString("city");
        //    HttpContext.Session.GetInt32("age");
        //}

    }



}
