﻿using Abc.Northwind.Business.Abstract;
using Abc.Northwind.DataAccess.Abstract;
using Abc.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abc.Northwind.Business.Concrete
{   public class ProductManager : IProductService
    {   //dependence injection; sınıfın ihtiyaç duyduğu farklı sınıfın
        //constroctur vasıtasıyla çağrılması
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        { _productDal = productDal; }
        public void Add(Product product)
        { _productDal.Add(product); }
        public void Delete(int productId)
        { _productDal.Delete(new Product { ProductId = productId } ); }
        public List<Product> GetAll()
        { return _productDal.GetList(); }  

        public List<Product> GetByCategory(int categoryId)
        { return _productDal.GetList(p=>p.CategoryId==categoryId || categoryId==0); }
        public void Update(Product product)
        { _productDal.Update(product); }
        public Product GetById(int productId)
        { return _productDal.Get(p => p.ProductId == productId); }
    }
}
