using SistemaReservasRestaurante.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace SistemaReservasRestaurante.Controllers
{
    public class MesasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // Solo el rol Admin puede acceder a esta acción
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var mesas = db.Mesas.Include(m => m.CategoriaMesa).ToList();
            return View(mesas);
        }
    }
}