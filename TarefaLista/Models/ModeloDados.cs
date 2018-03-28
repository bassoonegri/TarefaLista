namespace TarefaLista.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModeloDados : DbContext
    {
        public ModeloDados()
            : base("name=ModeloDados")
        {
        }

        public virtual DbSet<TarefaLista> TarefaLista { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TarefaLista>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<TarefaLista>()
                .Property(e => e.Anotacao)
                .IsUnicode(false);
        }
    }
}
