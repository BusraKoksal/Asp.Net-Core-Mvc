using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abc.Northwind.Entities.Concrete;
using Abc.Coree.DataAccess;


namespace Abc.Northwind.DataAccess.Abstract
{
    //dataaccess in core ; product ise entity içerisinde olduğundan
    //core ve entity e referans vermemiz gerekiyor.
    public interface IProductDal: IEntityRepository<Product>
    // neden public hale getiriyoruz?--> erişim olması için.
    {
        //custom operations
    }
}
