using Abc.Northwind.Business.Abstract;
using Abc.Northwind.Business.Concrete;
using Abc.Northwind.DataAccess.Abstract;
using Abc.Northwind.DataAccess.Concrete.EntityFramework;
using Abc.Northwind.MvcWebUI.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IProductDal, EfProductDal>();
// Add services to the container.
builder.Services.AddScoped<IProductService, ProductManager>();
//IProductservice istenirse ona productmanager �rne�i olu�tur ve onu ver.23.08
builder.Services.AddScoped<ICategoryService, CategoryManager>();
// categorymanagerde public class olmas�na dikkat et,hata sebebi!
builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();
//31.08-->
builder.Services.AddSession();
builder.Services.AddDistributedMemoryCache(); //bunu eklemezsek session aktifle�medi diye hata alabililriz
builder.Services.AddHttpContextAccessor();
//4.9.23--> controller �cartservice vb bilmiyor tan�mlayal�m.
builder.Services.AddSingleton<ICartSessionService, CartSessionService>();
builder.Services.AddSingleton<ICartService, CartService>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); 


builder.Services.AddRazorPages();
builder.Services.AddMvc();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//kulland���n kadar �de -> middle veri �r:hata yakalama ,loglama 22.08

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
//app.UseMvcWithDefaultRoute();//-->default olarak home controller �n index sayfas�na git demek.

