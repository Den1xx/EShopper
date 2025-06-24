using BLL.Abstract;
using BLL.Concrete;
using DAL.EFCore;
using DAL.EFCore.Abstract;
using DAL.EFCore.Context;
using DAL.Mapping;
using ENTITY;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<DataContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); //default connection'u burasý yapýyor.

//Dependency Injection

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
              .AddEntityFrameworkStores<DataContext>()
              .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    //password
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 6;

    options.Lockout.MaxFailedAccessAttempts = 5; //5 hatal? giri? hakk?
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); //5 hatal? giri? sonras? 5dk giri? kilitlensin
    options.Lockout.AllowedForNewUsers = true; //Her yeni üye için bu özelli?i ver.


    //user
    options.User.RequireUniqueEmail = true; //Benzersiz Email zorunlulu?u
                                            //options.User.AllowedUserNameCharacters = ""; //Username de izin verilen özel karakterler

    options.SignIn.RequireConfirmedEmail = false; //Kay?t sonras? giri? yapabilmek için Emaili onaylamal?
    options.SignIn.RequireConfirmedPhoneNumber = false; //Kay?t sonras? giri? yapabilmek için Telefon numaras? onaylamal?
});

//Configure Cookie
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    //options.LogoutPath = "/User/Logout";
    //options.AccessDeniedPath = "/User/AccessDenied";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60); //Oturum süresi
    options.SlidingExpiration = true; //Herhangi bir harekette süresi tekrar ba?lat
    options.Cookie = new CookieBuilder
    {
        HttpOnly = true,
        Name = "Organic.Security.Cookie",
        SameSite = SameSiteMode.Strict //Oturumu serverdan kullan?c? browser?na ta??d?k
    };
});

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductDal, ProductDal>();

builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IBrandDal, BrandDal>();

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryDal, CategoryDal>();

builder.Services.AddScoped<IMailService, MailService>();
builder.Services.AddScoped<IMailDal, MailDal>();

builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<ICartDal, CartDal>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

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
    pattern: "{controller=Cart}/{action=Index}/{id?}");

app.Run();
