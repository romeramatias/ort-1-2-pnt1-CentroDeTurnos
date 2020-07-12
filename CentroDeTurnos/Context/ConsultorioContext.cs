using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CentroDeTurnos.Models;

namespace Consultorio.Context
{
    public class ConsultorioContext : DbContext
    {
        public DbSet<Paciente> pacientes { get; set; }
        public DbSet<Turno> turnos { get; set; }
        public DbSet<Admin> admins { get; set; }

        public ConsultorioContext(DbContextOptions<ConsultorioContext> options) : base(options)
        {

        }

    }
}
