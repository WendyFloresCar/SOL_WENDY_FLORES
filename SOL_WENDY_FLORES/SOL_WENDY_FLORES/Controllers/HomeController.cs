using SOL_WENDY_FLORES.Data;
using SOL_WENDY_FLORES.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SOL_WENDY_FLORES.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public HomeController()
        {
            _dbContext = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var lista = new List<PRESTAMOVIEWMODEL>();
            try
            {

                using (var ctx = new ApplicationDbContext())
                {
                    lista = (from a in ctx.PRESTAMOLIBROS
                               join b in ctx.USUARIOS on a.IDUSUARIOS equals b.ID
                               join c in ctx.LIBROS on a.IDLIBROS equals c.ID
                               orderby a.FECHAPRESTAMO
                               select new PRESTAMOVIEWMODEL
                               {
                                   IdPrestamo = a.ID,
                                   IdLibro = a.IDLIBROS,
                                   NombreLibro = c.NOMBRE,
                                   FechaPrestamo = a.FECHAPRESTAMO,
                                   DniUsuario = b.NUMERODNI,
                                   NombreUsuario = b.NOMBRES,
                                   ApellidoUsuario = b.APELLIDOS,
                                   TipoUsuario = b.TIPOUSUARIO,
                                   FechaDevolucion = a.FECHADEVOLUCION,
                                   TipoLectura = a.TIPOLECTURA
                               }).ToList();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return View(lista);
        }
        public ActionResult Create()
        {
            ViewBag.IDLIBROS = _dbContext.LIBROS.ToList();
            ViewBag.IDUSUARIOS = _dbContext.USUARIOS.ToList();
            return PartialView();
        }
        [HttpPost]
        public async Task<ActionResult> Create(PRESTAMOLIBROS model)
        {
            try
            {
                var prestamosPorUsuario = _dbContext.PRESTAMOLIBROS
                    .Where(t => t.IDUSUARIOS.Equals(model.IDUSUARIOS) && t.FECHAPRESTAMO.Equals(DateTime.Today)).Count();

                //valida cant máxima de prestamos
                if (prestamosPorUsuario >= 3)
                {
                    return Json(new { error = true, message = "Ha superado el máximo de préstamos del día" });
                }
                model.FECHAPRESTAMO = DateTime.Now.Date;
                _dbContext.PRESTAMOLIBROS.Add(model);
                await _dbContext.SaveChangesAsync();
                return Json(new { error = false });
            }
            catch (Exception EX)
            {
                throw;
            }
        }
        [HttpGet]
        public async Task<ActionResult> Devolucion(int id)
        {
            try
            {
                var prestamosPorUsuario = _dbContext.PRESTAMOLIBROS.Where(t => t.ID.Equals(id)).FirstOrDefault();
                var duracionEnMinutos = 1440; // 24 horas en minutos
                var fechaHoraDevolucionPermitida = prestamosPorUsuario.FECHAPRESTAMO.AddMinutes(duracionEnMinutos);
                if (DateTime.Now > fechaHoraDevolucionPermitida)
                {
                    var usuario = _dbContext.USUARIOS.Where(t => t.ID.Equals(prestamosPorUsuario.IDUSUARIOS)).FirstOrDefault();
                    usuario.ESTADO = "0";
                }

                prestamosPorUsuario.FECHADEVOLUCION = DateTime.Today;
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception EX)
            {
                throw;
            }
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}