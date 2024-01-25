using Abc.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abc.Northwind.Business.Abstract
{
    public interface IProductService
    {
        //arayüzlerin ihtiyaç duyduğu operasyonları yazabiliriz. 
        List<Product> GetAll();
        List<Product> GetByCategory(int categoryId);
        void Add(Product product);
        void Update(Product product);
        void Delete(int productId); 
  Product GetById(int productId); //4.9
             
    }
    public interface ICategoryService
    {
        List<Category> GetAll();
    }
}
