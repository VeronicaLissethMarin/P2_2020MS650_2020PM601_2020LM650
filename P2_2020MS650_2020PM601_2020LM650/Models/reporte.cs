using System.ComponentModel.DataAnnotations;
namespace P2_2020MS650_2020PM601_2020LM650.Models
{
    public class reporte
    {
        [Key]
        [Display(Name = "ID")]
        public int reporte_id { get; set; }

        [Display(Name = "ID de deparmento")]
        public int? id_departamento { get; set; }

        public int? id_genero { get; set; }

        [Display(Name = "Casos confirmados")]
        public int confirmados { get; set; }

        [Display(Name = "Casos recuperados")]
        public int recuperados { get; set; }

        [Display(Name = "Fallecidos")]
        public int fallecidos { get; set; }
    }
}
