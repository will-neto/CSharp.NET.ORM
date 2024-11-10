using CSharp.NET.ORM.EntityFrameworkCore.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CSharp.NET.ORM.EntityFrameworkCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            /*
             * AddDbContext � o m�todo capaz de incluir um banco de dados (atrav�s do Contexto) no cont�iner de depend�ncias
             * Desta forma, n�o se faz necess�rio a configura��o atrav�s do m�todo OnConfiguring da classe DbContext
             * 
             * Atrav�s do objeto DbContextOptionsBuilder (opt), � poss�vel atribuir as configura��es necess�rias para funcionamento
             * da conex�o com o banco de dados
             */
            builder.Services.AddDbContext<LivrariaContext>(opt =>
            {
                /*
                 * Abaixo, � usado o m�todo UseSqlServer do provedor MS Sql Server para definir a string de conex�o
                 * do servidor de banco de dados
                 */
                opt.UseSqlServer(builder.Configuration.GetConnectionString("LivrariaConexao"));
            });

            var app = builder.Build();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
