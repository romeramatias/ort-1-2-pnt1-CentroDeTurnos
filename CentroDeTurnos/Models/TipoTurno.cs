using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CentroDeTurnos.Models
{
    public enum TipoTurno
    {
        [Display(Name = "Consulta")]
        Consulta = 1,

        [Display(Name = "Urgencia")]
        Urgencia = 2,

        [Display(Name = "Prioridad")]
        Prioridad = 3,

        [Display(Name = "Discapacitado")]
        Discapacitado = 4,

    }
}
