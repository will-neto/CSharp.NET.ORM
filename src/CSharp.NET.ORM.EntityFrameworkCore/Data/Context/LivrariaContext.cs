using Microsoft.EntityFrameworkCore;

namespace CSharp.NET.ORM.EntityFrameworkCore.Data.Context
{
    public class LivrariaContext : DbContext
    {
        public LivrariaContext(DbContextOptions<LivrariaContext> dbContext) : base(dbContext)
        {
            /* 
             * DbContextOptions é a classe responsável para aplicar configurações customizadas do contexto.
             * Essas configurações são aplicadas a partir do método OnConfiguring e devem ser aplicadas através do builder.           
            */
        }

        /*
         * Método responsável pela configuração do DbContext.
         * É executado antes da abertura de conexão do DbContext
         * Se caso utilizado Injeção de Dependência, não se faz necessário a utilização do método OnConfiguring
            - As configurações podem ser feitas através do conteiner de serviços (ServiceCollections) do Program.cs
         */
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*
             * Como comentado anteriormente, a DbContextOptionsBuilder é responsável pela configuração de um DbContext.
             * Configurações como provedor (BD), Logs, Lazy Loading, interceptores, Retry, etc.
             */

            

            base.OnConfiguring(optionsBuilder);
        }
    }
}
