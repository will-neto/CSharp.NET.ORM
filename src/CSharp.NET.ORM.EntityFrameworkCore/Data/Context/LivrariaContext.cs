using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Diagnostics.CodeAnalysis;

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
