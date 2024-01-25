using Abc.Northwind.Entities.Concrete;

namespace Abc.Northwind.MvcWebUI.Models
{
    public class CategoryListViewModel
    {
        public CategoryListViewModel()
        {
        }

        public CategoryListViewModel(List<Category> categories)
        {
            Categories = categories;
        }

        public List<Category> Categories { get; internal set; }
        public int CurrentCategory { get; internal set; }
    }
}
