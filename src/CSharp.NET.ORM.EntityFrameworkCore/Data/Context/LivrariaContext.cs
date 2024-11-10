using CSharp.NET.ORM.EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Diagnostics.CodeAnalysis;

namespace CSharp.NET.ORM.EntityFrameworkCore.Data.Context
{
    /*
     * Classe DbContext é uma das principais classes do Framework do EF Core
     * Atua como uma unidade de trabalho que encapsula a lógica de acesso e persistência a um banco de dados 
     * Pode ser usada diretamente, mas comumente usada utilizando uma classe especializada (como no exemplo abaixo - LivrariaContext)
     * Cada classe especializada só pode trabalhar com apenas um provedor de Banco de Dados
     * Em caso de múltiplas conexões, criar multiplas classes especializadas
     */

    public class LivrariaContext : DbContext
    {
        public LivrariaContext(DbContextOptions<LivrariaContext> dbContext) : base(dbContext)
        {
            /* 
             * DbContextOptions é a classe responsável para aplicar configurações customizadas do contexto.
             * Essas configurações são aplicadas a partir do método OnConfiguring e devem ser aplicadas através do builder.
             * 
             * Usar o DbContextOptions<T> (genérico) quando estamos trabalhando com uma subclasse especializada (LivrariaContext)
             * Usar o DbContextOptions (não-genérico) quando pretendemos utilizar a subclasse como herança para outra subclase mais especializada
            */
        }


        #region . . . Coleção de Entidades . . .

        /*
         * A classe DbSet representa uma coleção de entidades
         * Cada propriedade definida através do tipo DbSet<T> representa uma tabela no banco de dados
         * Porém, não existe uma necessidade obrigatória de declarar via propriedade
         *  - Mais detalhes nos comentários método OnModelConfiguration
         */

        public DbSet<Livraria> Livraria { get; set; }
        public DbSet<Livro> Livro { get; set; }
        public DbSet<Autor> Autor { get; set; }

        #endregion


        #region . . . Métodos de Configuração . . .


        /*
         * Método responsável pela configuração do DbContext.
         * É executado sempre que a classe ou subclasse DbContext é instânciada
         * Se caso utilizado Injeção de Dependência (declaração do DbContext via Program.cs - ServiceCollections):
            - Não se faz necessário a utilização do método OnConfiguring
            - As configurações podem ser feitas através do conteiner de serviços (ServiceCollections) do Program.cs
            - Configurações aplicadas no contêiner de serviços são prioritárias
         */

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*
             * Como comentado anteriormente, a DbContextOptionsBuilder é responsável pela configuração de um DbContext.
             * Configurações como provedor (BD), Logs, Lazy Loading, interceptores, Retry, etc.
             */

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
             * Como comentado anteriormente, podemos contornar a necessidade de declarar um DbSet para cada classe utilizando
             * um scan de assemblies de duas formas:
             *  
             *  - Através da entidade, passando o assembly da classe através do método AddEntityType. Essa abordagem
             *  possibilita que todas as classes no mesmo assembly também sejam mapeadas.
             *  
             *  - Através da Fluent API Configuration, passando o assembly da classe especializada de configuração de uma
             *  entidade. Essa abordagem possibilita que todas as classes especializadas de configurações no mesmo assembly
             *  também sejam mapeadas.
             */

            /* Através do Assembly da Entidade (consequentemente mapeando as demais) */
            /*
                modelBuilder.Model.AddEntityType(typeof(Livraria));
            */

            /* Através do Assembly da Fluent API Configuration */
            /*
                modelBuilder.ApplyConfigurationsFromAssembly(typeof(LivrariaContext).Assembly);
             */

            base.OnModelCreating(modelBuilder);
        }

        #endregion

        #region . . . Métodos de Persistencia . . .


        /*
            O EntityFramework Core permite a sobrescrita de métodos de persistências, para que possa ser possível
            interceptar chamadas para tratativas personalizadas, tais como logs, auditoria, tratativas de erros, etc.
         */

        // INCLUSAO
        public override EntityEntry Add(object entity)
        {
            return base.Add(entity);
        }

        public override ValueTask<EntityEntry> AddAsync(object entity, CancellationToken cancellationToken = default)
        {
            return base.AddAsync(entity, cancellationToken);
        }

        public override void AddRange(IEnumerable<object> entities)
        {
            base.AddRange(entities);
        }

        public override Task AddRangeAsync(IEnumerable<object> entities, CancellationToken cancellationToken = default)
        {
            return base.AddRangeAsync(entities, cancellationToken);
        }

        // ATUALIZACAO
        public override EntityEntry Update(object entity)
        {
            return base.Update(entity);
        }

        public override void UpdateRange(IEnumerable<object> entities)
        {
            base.UpdateRange(entities);
        }

        // BUSCA
        public override TEntity? Find<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties | DynamicallyAccessedMemberTypes.Interfaces)] TEntity>(params object?[]? keyValues) where TEntity : class
        {
            return base.Find<TEntity>(keyValues);
        }

        public override ValueTask<object?> FindAsync([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties | DynamicallyAccessedMemberTypes.Interfaces)] Type entityType, params object?[]? keyValues)
        {
            return base.FindAsync(entityType, keyValues);
        }

        // REMOCAO
        public override EntityEntry Remove(object entity)
        {
            return base.Remove(entity);
        }

        public override void RemoveRange(IEnumerable<object> entities)
        {
            base.RemoveRange(entities);
        }

        // COMMIT
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        // FECHAR CONEXAO
        /*
         * Se o DbContext for utilizado via DI (por exemplo, ServiceCollection no Program.cs), não se faz necessário chamar o método de fechamento da conexão
         * Ao contrário, é importante a chamada manual
         */
        public override void Dispose()
        {
            base.Dispose();
        }

        #endregion


    }

}
