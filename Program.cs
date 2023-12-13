
using Microsoft.EntityFrameworkCore;
using SistemaAcademicoCoruja.Application;
using SistemaAcademicoCoruja.Repositories;
using SistemaAcademicoCoruja.Repositories.Interfaces;

namespace SistemasDeTarefas2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //criando a conexão
            builder.Services.AddEntityFrameworkSqlServer().AddDbContext<SistemaAcademicoCorujaDBContex>(
                    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
                );

            //Configurando as dependências do Repositório
            //Toda vez que a interface for chamada a classe instanciada será a que se encontra aui na dependência
            builder.Services.AddScoped<IAlunoRepositories, AlunoRepositories>();
            builder.Services.AddScoped<IDisciplinaRepositories, DisciplinaRepositories>();


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
