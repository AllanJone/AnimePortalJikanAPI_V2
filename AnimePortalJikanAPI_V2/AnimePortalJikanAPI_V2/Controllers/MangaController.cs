using AnimePortalJikanAPI.JikanDecoder;
using AnimePortalJikanAPI.JikanDecoder.Interfaces;
using AnimePortalJikanAPI.JikanDecoder.Model.Core;
using AnimePortalJikanAPI.JikanDecoder.Model.Secondary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimePortalJikanAPI_V2.Controllers
{
    public class MangaController : Controller
    {
        IJikan jikan = new Jikan(true);

        // GET: Manga
        public ActionResult Index(int? page)
        {
            ViewBag.NavBarActive = "Manga";
            int pageNumber = (page ?? 1);
            MangaTop topMangaList = null;
            List <MangaTopEntry> mangaTopEntries = new List<MangaTopEntry>();
            try
            {
                topMangaList = jikan.GetMangaTop(pageNumber);
                mangaTopEntries = topMangaList.Top.ToList();
                ViewBag.PageNumber = pageNumber;
                return View(mangaTopEntries);
            }
            catch
            {
                return Index(1);             
            }
            
        }
        public ActionResult Details(int id = 1)
        {
            ViewBag.NavBarActive = "Manga";
            Manga manga = jikan.GetManga(id);
            return View(manga);
        }
    }
}