using eTicket;
using eTicket.Data;
using eTicket.Data.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        

        // Add services to the container.

        builder.Services.AddScoped<IActorsService, ActorService>();
        builder.Services.AddScoped<IProducerService, ProducerService>();
        
        builder.Services.AddControllersWithViews();

        builder.Services.AddDbContext<AppDbcontext>(options => 
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

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
            pattern: "{controller=Movies}/{action=Index}/{id?}");

        //seed database    
        AppDbInitiazer.Seed(app);

        app.Run();
    }

}