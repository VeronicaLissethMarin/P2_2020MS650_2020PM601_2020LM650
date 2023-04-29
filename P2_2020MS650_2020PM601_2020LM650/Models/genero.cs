using System.ComponentModel.DataAnnotations;
namespace P2_2020MS650_2020PM601_2020LM650.Models
{
    public class genero
    {
        [Key]
        [Display(Name = "ID")]
        public int id_genero { get; set; }
        [Display(Name = "Genero")]
        public string? nombregenero { get; set; }
    }
}
