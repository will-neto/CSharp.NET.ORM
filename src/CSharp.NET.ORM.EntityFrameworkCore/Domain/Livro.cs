namespace CSharp.NET.ORM.EntityFrameworkCore.Domain
{
    /*
     * As tabelas serão mapeadas através do nome da classe caso não seja específicado através de Annotations ou Fluent API
     */
    public class Livro
    {
        public Guid Id { get; set; }
        /* 
         * Sem utilizar Annotations e Fluent API, os campos são declarados como obrigatórios 
         *  - Para que sejam declarados como anuláveis (nullables), deve ser usada a tipagem nula: string?
         * Campos textos caso não declarados o tamanho, são tratados como tamanho máximo
         */
        public string Nome { get; set; }
        public int Unidades { get; set; }
        public DateTime DataLancamento { get; set; }

        /*
         * Para definirmos os relacionamentos sem utilizarmos Annotations, podemos seguir a convenção do nome da tabela + Id
         *  - O EF Core é capaz entender e mapear automaticamente as chaves-estrangeiras desta forma
         *  - Além disto, se faz necessária a declaração das propriedades de navegação
         */
        public Guid AutorId { get; set; }
        public Autor Autor { get; set; }
        public Guid LivrariaId { get; set; }
        public Livraria Livraria { get; set; }
    }
}
