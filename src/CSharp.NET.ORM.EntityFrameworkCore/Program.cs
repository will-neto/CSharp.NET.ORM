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
             * AddDbContext é o método capaz de incluir um banco de dados (através do Contexto) no contêiner de dependências
             * Desta forma, não se faz necessário a configuração através do método OnConfiguring da classe DbContext
             * 
             * Através do objeto DbContextOptionsBuilder (opt), é possível atribuir as configurações necessárias para funcionamento
             * da conexão com o banco de dados
             */
            builder.Services.AddDbContext<LivrariaContext>(opt =>
            {
                /*
                 * Abaixo, é usado o método UseSqlServer do provedor MS Sql Server para definir a string de conexão
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
