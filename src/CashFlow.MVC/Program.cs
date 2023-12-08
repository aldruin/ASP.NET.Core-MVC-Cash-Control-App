using CashFlow.Application;
using CashFlow.Infrastructure;
using CashFlow.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CashFlow.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);



//connectiondb
string sqlServerConnection = builder.Configuration.GetConnectionString("DefaultConnection")
           ?? throw new Exception("A string de conex?o 'DefaultConnection' n?o foi configurada");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(sqlServerConnection));


builder.Services
            .RegisterApplication(builder.Configuration)
            .RegisterRepository(builder.Configuration.GetConnectionString("DefaultConnection"));


// Add services to the container.
builder.Services.AddControllersWithViews();



//identity configure
builder.Services.AddIdentity<User, IdentityRole<Guid>>
    (options =>{
        options.SignIn.RequireConfirmedAccount = false; 
        options.User.RequireUniqueEmail = true;
    })
        .AddEntityFrameworkStores<AppDbContext>()
        .AddDefaultTokenProviders();



var app = builder.Build();


//middleware exception
app.UseStatusCodePages(async statusCodeContext
            => await Results.Problem(statusCode: statusCodeContext.HttpContext.Response.StatusCode)
            .ExecuteAsync(statusCodeContext.HttpContext));


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

app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
