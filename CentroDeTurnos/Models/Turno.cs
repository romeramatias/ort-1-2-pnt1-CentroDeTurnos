using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CentroDeTurnos.Models
{
    public class Turno 
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Paciente")]
        public int PacienteID { get; set; }
   
        [EnumDataType(typeof(TipoTurno))]
        [Display(Name = "Tipo de consulta")]
        public TipoTurno TipoTurno { get; set; }


        [Required]
        [Display(Name = "Fecha de turno")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FechaTurno { get; set; }

        [Display(Name = "Paciente")]
        public Paciente paciente { get; set; }
    }
}