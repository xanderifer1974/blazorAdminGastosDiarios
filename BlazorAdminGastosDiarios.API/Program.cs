using BlazorAdminGastosDiarios.Data;
using BlazorAdminGastosDiarios.Data.Repositories.Interfaces;
using BlazorAdminGastosDiarios.Data.Repositories;

namespace BlazorAdminGastosDiarios.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

           //Conexão com o banco de dados
            string connectionString = builder.Configuration.GetConnectionString("SqlConnection");

            var SqlConnectionConfiguration = new SqlConfiguration(connectionString);
            
            builder.Services.AddSingleton(SqlConnectionConfiguration);

            // Add services to the container.

            builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}