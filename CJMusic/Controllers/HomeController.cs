using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CJMusic.Models;

namespace CJMusic.Controllers
{

    public class HomeController : Controller
    {
        EventosBL _bl = new EventosBL();
        ArtistasBL _bl1 = new ArtistasBL();

        public ActionResult Index()
        {
            ViewBag.ListaEventos = _bl.ConsultarEventos().ToList();
            return View();
        }

        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(EventosEN pEN)
        {
            _bl.AgregarEventos(pEN);
            return RedirectToAction("Index");

        }
        public ActionResult Actualizar()
        {
            ViewBag.ListaEventos = _bl.ConsultarEventos().ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Actualizar(EventosEN pEN)
        {
            _bl.ActualizarEventos(pEN);
            ViewBag.ListaEventos = _bl.ConsultarEventos().ToList();
            return RedirectToAction("Index");
        }
        public ActionResult Eliminar()
        {
            ViewBag.ListaEventos = _bl.ConsultarEventos().ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Eliminar(EventosEN pEN)
        {
            _bl.EliminarEventos(pEN);
            return RedirectToAction("Index");
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
        public ActionResult Artistas()
        {
            ViewBag.ListaArtistas = _bl1.ConsultarArtistas().ToList();

            return View();
        }
        public ActionResult AgregarArtista()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarArtista(ArtistasEn pEN)
        {
            _bl1.AgregarArtistas(pEN);
            return RedirectToAction("Artistas");

        }
        public ActionResult ActualizarArtista()
        {
            ViewBag.ListaArtistas = _bl1.ConsultarArtistas().ToList();
            return View();
        }

        [HttpPost]
        public ActionResult ActualizarArtista(ArtistasEn pEN)
        {
            _bl1.ActualizarArtista(pEN);
           
            return RedirectToAction("Artistas");
        }
        public ActionResult EliminarArtista()
        {
          
            return View();
        }

        [HttpPost]
        public ActionResult EliminarArtista(ArtistasEn pEN)
        {
            _bl1.EliminarArtista(pEN);
            return RedirectToAction("Artistas");
        }

        public ActionResult Noticias()
        {
            return View();
        }
        public ActionResult Ubicación()
        {
            return View();
        }
    }
}