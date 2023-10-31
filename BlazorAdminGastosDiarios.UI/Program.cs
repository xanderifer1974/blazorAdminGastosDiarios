using BlazorAdminGastosDiarios.UI.Interfaces;
using BlazorAdminGastosDiarios.UI.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorAdminGastosDiarios.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var urlApi = builder.Configuration.GetSection("UrlLocalHost").Get<string>();

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor().AddCircuitOptions(options => { options.DetailedErrors = true; });
            builder.Services.AddHttpClient<ICategoriaService, CategoriaService>(                             

                client => { client.BaseAddress = new Uri(urlApi); });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}