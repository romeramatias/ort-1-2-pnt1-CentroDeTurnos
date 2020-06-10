using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
// Add-Migration CentroDeTurnos.Context.TurnosDatabaseContext

namespace CentroDeTurnos.Models
{
    public class Turno 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string NombrePaciente { get; set; }
        public int Documento { get; set; }
        [Display(Name = "Fecha de turno")]
        public DateTime FechaTurno { get; set; }

    }
}
