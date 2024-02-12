using System.ComponentModel.DataAnnotations;

namespace P1_Ap1_LuisManuelDuarte.Models
{
    public class Metas
    {
        [Key]
        public int MetaId { get; set; }

        
        [DataType(DataType.Date)]
        public DateTime Fecha {  get; set; }= DateTime.Now;

        [Required(ErrorMessage = "La Descripcion es Requerida")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "")]
        public float Monto { get; set; }

    }
}
