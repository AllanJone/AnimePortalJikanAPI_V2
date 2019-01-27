using AnimePortalJikanAPI.JikanDecoder;
using AnimePortalJikanAPI.JikanDecoder.Interfaces;
using AnimePortalJikanAPI.JikanDecoder.Model.Core;
using AnimePortalJikanAPI.JikanDecoder.Model.Secondary;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AnimePortalJikanAPI.Controllers
{
    public class AnimeController : Controller
    {

        IJikan jikan = new Jikan(true);

        // GET: Anime
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            AnimeTop topAnimeList = null;
            List<AnimeTopEntry> animeList = new List<AnimeTopEntry>();
            try
            {
                topAnimeList = jikan.GetAnimeTop(pageNumber);
                animeList = topAnimeList.Top.ToList();
                ViewBag.PageNumber = pageNumber;
                ViewBag.NavBarActive = "Anime";
                return View(animeList);
            }
            catch
            {
                return Index(1);
            }
        }

        public ActionResult Details(int id = 1)
        {
            ViewBag.NavBarActive = "Anime";
            Anime anime = jikan.GetAnime(id);
            return View(anime);
        }

    }
}