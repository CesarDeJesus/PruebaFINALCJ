using CJMusic.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            ViewBag.ListaArtistas = _bl1.ConsultarArtistas().ToList();
            
            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
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

        public ActionResult EliminarNews()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EliminarNews(NewsEN pEN)
        {
            _bl3.EliminarNews(pEN);
            return RedirectToAction("Noticias");
        }

        public ActionResult Ubicación()
        {
            return View();
        }

        public ActionResult PatyCanciones()
        {
            ViewBag.ListaArtista = GetFiless().ToList();
            return View();
        }

        //CANCIONES SERVICE

        [HttpPost]
        public ActionResult Envia(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Content/Canciones/PatyCantu"),
                                               Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    ViewBag.Message = "File uploaded successfully";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }

            var itemss = GetFiless();
            return RedirectToAction("PatyCanciones");

        }


        public FileResult Download(string ImageName)
        {
            var FileVirtualPath = "~/Content/Canciones/PatyCantu/" + ImageName;
            return File(FileVirtualPath, "application/force- download", Path.GetFileName(FileVirtualPath));
        }

        private List<string> GetFiless()
        {
            var dir = new System.IO.DirectoryInfo(Server.MapPath("~/Content/Canciones/PatyCantu/"));
            System.IO.FileInfo[] fileNames = dir.GetFiles("*.*");

            List<string> itemss = new List<string>();
            foreach (var file in fileNames)
            {
                itemss.Add(file.Name);
            }

            return itemss;
        }

        public ActionResult Canciones()
        {
            return View();
        }

    }
}