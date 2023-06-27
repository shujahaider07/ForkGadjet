using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using DbContextForApplicationLayer;
using Gadgetstore.BusinessInterface;
using Gadgetstore.BusinessLayer;
using IRepository;
using Microsoft.EntityFrameworkCore;
using RepositoryBusiness;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//REPOSITORY 
builder.Services.AddScoped<ICustomerRepo, CustomerRepo>();
builder.Services.AddScoped<IProductRepo, ProductRepo>();
builder.Services.AddScoped<ICategory, CategoryRepo>();
builder.Services.AddScoped<IDeliveries, DeliveriesRepo>();
builder.Services.AddScoped<IShopping, ShoppingRepo>();


//BUSINESS
builder.Services.AddScoped<IproductBusiness, ProductBusiness>();
builder.Services.AddScoped<ICustomer, CustomerBusiness>();
builder.Services.AddScoped<IcategoryBusiness, Categorybusiness>();
builder.Services.AddScoped<IDeliveryBusiness, DeliveryBusiness>();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"), sqlServerOptions => sqlServerOptions.CommandTimeout(120));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);



});


builder.Services.AddNotyf(config => { config.DurationInSeconds = 10; config.IsDismissable = true; config.Position = NotyfPosition.BottomRight; });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Customer}/{action=ListCustomer}/{id?}");
app.UseNotyf();
app.Run();
