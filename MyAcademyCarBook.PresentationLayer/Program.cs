using MyAcademyCarBook.BusinessLayer.Abstrsct;
using MyAcademyCarBook.BusinessLayer.Concrete;
using MyAcademyCarBook.DataAccessLayer.Abstract;
using MyAcademyCarBook.DataAccessLayer.Concrete;
using MyAcademyCarBook.DataAccessLayer.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CarBookContext>();
builder.Services.AddScoped<IBrandDal,EfBrandDal>();
builder.Services.AddScoped<IBrandService,BrandManager>();
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ICarStatusDal, EfCarStatusDal>();
builder.Services.AddScoped<ICarStatusService, CarStatusManager>();

builder.Services.AddScoped<ICarDal,EfCarDal>();
builder.Services.AddScoped<ICarService,CarMenager>();

builder.Services.AddScoped<IPriceDal, EfPriceDal>();
builder.Services.AddScoped<IPriceService, PriceManager>();

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
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
