using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIFILME.models
{
    [Table("Filmes")]
    public class FILME
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Categoria { get; set; }

        public string? Streaming { get; set; }
        public int ano { get; set; }
        public string? Descricao { get; set; }
        public string? Foto { get; set; }
        public string? Desenvolvedor { get; set; }
        public string? Publicador { get; set; }
        public float? Imdbnota { get; set; }
        [Required]
        public string Status { get; set; }

    }
}
