using System.ComponentModel.DataAnnotations;
namespace P2_2020MS650_2020PM601_2020LM650.Models
{
    public class departamento
    {
        [Key]
        [Display(Name = "ID")]
        public int id_departamento { get; set; }

        [Display(Name = "Departamento")]
        public string nombredepartamento { get; set; }
    }
}
