namespace CSharp.NET.ORM.EntityFrameworkCore.Domain
{
    public class Autor
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Livro> Livros { get; set; }
    }
}
