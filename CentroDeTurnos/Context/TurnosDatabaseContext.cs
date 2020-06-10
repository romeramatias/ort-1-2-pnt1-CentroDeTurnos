using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CentroDeTurnos.Models;


namespace CentroDeTurnos.Context
{
    public class TurnosDatabaseContext : DbContext
    {
        public
    TurnosDatabaseContext(DbContextOptions<TurnosDatabaseContext> options)
    : base(options)
        {
        }
        public DbSet<Turno> Turnos { get; set; }
    }



}

