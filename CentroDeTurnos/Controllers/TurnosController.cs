using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CentroDeTurnos.Models;
using Consultorio.Context;
using System.Collections;
using Microsoft.AspNetCore.Http;

namespace CentroDeTurnos.Controllers
{
    public class TurnosController : Controller
    {
        private readonly ConsultorioContext _context;

        public TurnosController(ConsultorioContext context)
        {
            _context = context;
        }

        // GET: Turnoes
        public async Task<IActionResult> Index()
        {
            var consultorioContext = _context.turnos.Include(c => c.paciente);
            return View(await consultorioContext.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Index(string stringBusqueda)
        {

            var adminLog = HttpContext.Session.GetString("admin");

            if (String.IsNullOrEmpty(adminLog))
            {
                return RedirectToAction("Login", "Admins");
            }

            ViewData["Obtenerpacientes"] = stringBusqueda;

            var varPacientes = from p in _context.turnos.Include(c => c.paciente) select p;

            if (!String.IsNullOrEmpty(stringBusqueda))
            {
                varPacientes = varPacientes.Where(s => s.paciente.Apellido.Contains(stringBusqueda));
            }
            return View(await varPacientes.AsNoTracking().ToListAsync());

        }

        public async Task<IActionResult> IndexUrgencia()
        {
            var consultorioContext = _context.turnos.Include(c => c.paciente);
            return View(await consultorioContext.ToListAsync());

        }

        [HttpGet]
        public async Task<IActionResult> IndexUrgencia(string stringBusqueda)
        {
            var adminLog = HttpContext.Session.GetString("admin");

            if (String.IsNullOrEmpty(adminLog))
            {
                return RedirectToAction("Login", "Admins");
            }

            ViewData["Obtenerpacientes"] = stringBusqueda;

            var varPacientes = from p in _context.turnos.Include(c => c.paciente) select p;

            if (!String.IsNullOrEmpty(stringBusqueda))
            {
                varPacientes = varPacientes.Where(s => s.paciente.Apellido.Contains(stringBusqueda));
            }
            return View(await varPacientes.AsNoTracking().ToListAsync());

        }

        // GET: Turnoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turno = await _context.turnos
                .Include(c => c.paciente)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (turno == null)
            {
                return NotFound();
            }

            return View(turno);
        }

        public IActionResult Create()
        {

            ViewData["PacienteID2"] =
                new SelectList((from s in _context.pacientes
                                select new
                                {
                                    ID = s.ID,
                                    FullName = s.Apellido + " " + s.Nombre
                                }),
                    "ID",
                    "FullName");


            //ViewData["PacienteID"] = new SelectList(_context.pacientes, "ID", "Apellido");

            return View();
        }

        // POST: Turnoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TipoTurno,FechaTurno,PacienteID")] Turno turno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(turno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["PacienteID2"] =
            new SelectList((from s in _context.pacientes
                            select new
                            {
                                ID = s.ID,
                                FullName = s.Apellido + " " + s.Nombre
                            }),
                "ID",
                "FullName",
                turno.PacienteID);

            //ViewData["PacienteID"] = new SelectList(_context.pacientes, "ID", "Apellido", turno.PacienteID);
            return View(turno);
        }

        // GET: Turnoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turno = await _context.turnos.FindAsync(id);
            if (turno == null)
            {
                return NotFound();
            }
            ViewData["PacienteID"] = new SelectList(_context.pacientes, "ID", "Apellido", turno.PacienteID);
            return View(turno);
        }

        // POST: Turnoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TipoTurno,FechaTurno")] Turno turno)
        {
            if (id != turno.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(turno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TurnoExists(turno.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PacienteID"] = new SelectList(_context.pacientes, "ID", "Apellido", turno.PacienteID);
            return View(turno);
        }

        // GET: Turnoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turno = await _context.turnos
                .Include(c => c.paciente)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (turno == null)
            {
                return NotFound();
            }

            return View(turno);
        }

        // POST: Turnoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var turno = await _context.turnos.FindAsync(id);
            _context.turnos.Remove(turno);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TurnoExists(int id)
        {
            return _context.turnos.Any(e => e.ID == id);
        }
    }
}
