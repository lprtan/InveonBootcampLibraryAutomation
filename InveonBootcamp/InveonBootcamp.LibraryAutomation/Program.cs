using BusinessLayer.Services.Abstract;
using BusinessLayer.Services.Concrete;
using CoreLayer.Mapping;
using DataAccessLayer.Context;
using DataAccessLayer.Repositories;
using DataAccessLayer.UnitOfWork;
using EntityLayer.Concrete;
using InveonBootcamp.LibraryAutomation.Models.ErrorHandling;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using FluentValidation.AspNetCore;
using BusinessLayer.Validation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MsSqlConnection")));
// Add services to the container.

builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddAutoMapper(typeof(BookMappingProfile));
builder.Services.AddAutoMapper(typeof(UserMappingProfile));
builder.Services.AddScoped<IBookMappingService, BookMappingService>();
builder.Services.AddScoped<IUserMappingService, UserMappingService>();

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddLogging();

builder.Services.AddScoped<IExceptionHandler, NullReferenceExceptionHandler>();
builder.Services.AddScoped<IExceptionHandler, UnauthorizedAccessExceptionHandler>();
builder.Services.AddScoped<IExceptionHandler, TimeoutExceptionHandler>();

builder.Services.AddScoped<IUserRoleService, UserRoleService>();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); 
    options.Cookie.HttpOnly = true; 
    options.Cookie.IsEssential = true; 
});

builder.Services.AddIdentity<UserApp, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateUserValidate>());

builder.Services.AddControllersWithViews();

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();  
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=CreateUser}");

app.Run();
