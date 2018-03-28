using System.Web.Mvc;

namespace TarefaLista.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TarefaLista")]
    [Bind(Exclude = "Id")]
    public partial class TarefaLista
    {

        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Descricao { get; set; }
        
        [StringLength(200)]
        public string Anotacao { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}" )]
        [Column(TypeName = "smalldatetime")]
        public DateTime DataCriacao { get; set; }

        [Required(ErrorMessage = "A data da atividade é obrigatória")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Column(TypeName = "smalldatetime")]
        public DateTime DataAtividade { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataFinalizacao { get; set; }

        [Required]
        public int Prioridade { get; set; }

        [Required]
        public int Status { get; set; }
    }

    public enum EnumPrioridade : int
    {
        Alta = 0,
        Media = 1,
        Baixa = 2
    }

    public enum EnumStatus : int
    {
        Aberta = 0,
        Finalizada = 1
    }
}
