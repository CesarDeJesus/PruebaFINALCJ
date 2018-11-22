using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using CJMusic.Models;

namespace CJMusic.Controllers
{

    public class HomeController : Controller
    {
        EventosBL _bl = new EventosBL();
        ArtistasBL _bl1 = new ArtistasBL();
        FotosBL _bl2 = new FotosBL();
        NewsBL _bl3 = new NewsBL();

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

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(String para, String asunto, String mensaje, HttpPostedFileBase fichero)
        {
           
        }
        public ActionResult Artistas()
        {
            ViewBag.ListaArtistas = _bl1.ConsultarArtistas().ToList();
            ViewBag.Fotos = _bl2.ConsultarGaleria().ToList();

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
        public ActionResult ActualizarArtista(int? Id)
        {
            var artistas = _bl1.ConsultarArtistas().ToList();
            foreach(var a in artistas)
            {
               if (Id == a.Id)
                {
                    ViewBag.Nombre = a.Nombre;
                    ViewBag.Descripcion = a.Descripcion;
                    ViewBag.img = a.img;
                    ViewBag.facebook = a.facebook;
                    ViewBag.twitter = a.twitter;
                    ViewBag.youtube = a.youtube;
                }
            }
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

        public ActionResult AgregarGaleria()
        {
            return RedirectToAction("Artistas");
        }

        [HttpPost]
        public ActionResult AgregarGaleria(FotosEN pEN)
        {
            _bl2.AgregarGaleria(pEN);
            return RedirectToAction("Artistas");

        }

        public ActionResult AgregarNews()
        {
            return RedirectToAction("Noticias");
        }

        [HttpPost]
        public ActionResult AgregarNews(NewsEN pEN)
        {
            _bl3.AgregarNews(pEN);
            return RedirectToAction("Noticias");

        }
        public ActionResult ActualizaNews(int? Id)
        {
            var News = _bl3.ConsultarNews().ToList();
            foreach (var a in News)
            {
                if (Id == a.Id)
                {
                    ViewBag.Artista = a.Artista;
                    ViewBag.TNoticia = a.TNoticia;
                    ViewBag.foto = a.foto;
                    ViewBag.DNoticia = a.DNoticia;
                }
            }
            return RedirectToAction("Noticias");
        }

        [HttpPost]
        public ActionResult ActualizaNews(NewsEN pEN)
        {
            _bl3.ActualizaNews(pEN);

            return RedirectToAction("Noticias");
        }
        
        public ActionResult Noticias()
        {
            ViewBag.News = _bl3.ConsultarNews().ToList();
            return View();
        }
        public ActionResult Ubicación()
        {
            return View();
        }
    }
}