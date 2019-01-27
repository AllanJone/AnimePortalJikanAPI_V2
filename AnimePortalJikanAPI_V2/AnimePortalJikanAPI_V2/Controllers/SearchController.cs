using AnimePortalJikanAPI.JikanDecoder;
using AnimePortalJikanAPI.JikanDecoder.Interfaces;
using AnimePortalJikanAPI.JikanDecoder.Model.Search;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AnimePortalJikanAPI_V2.Controllers
{
    public class SearchController : Controller
    {
        IJikan jikan = new Jikan(true);

        // GET: Search
        public ActionResult Index()
        {
            ViewBag.NavBarActive = "Search";
            return View();
        }

        public ActionResult Result(string type, string keyword, int? page)
        {
            int pageNumber = (page ?? 1);
            ViewBag.NavBarActive = "Search";
            if (type.Equals("Anime"))
            {
                AnimeSearchResult animeSearchResult = null;
                List<AnimeSearchEntry> animeSearchEntry = new List<AnimeSearchEntry>();
                try
                {
                    animeSearchResult = jikan.SearchAnime(keyword, pageNumber);
                    if (pageNumber > animeSearchResult.ResultLastPage)
                    {
                        pageNumber = 1;
                        animeSearchResult = jikan.SearchAnime(keyword, pageNumber);
                    }
                    animeSearchEntry = animeSearchResult.Results.ToList();
                    ViewBag.Keyword = keyword;
                    ViewBag.Type = "Anime";
                    ViewBag.Result = animeSearchEntry;
                    ViewBag.PageNumber = pageNumber;
                    return View();
                }
                catch
                {
                    return Index();
                }
            }
            else if (type.Equals("Manga"))
            {
                MangaSearchResult mangaSearchResult = null;
                List<MangaSearchEntry> mangaSearchEntry = new List<MangaSearchEntry>();
                try
                {
                    mangaSearchResult = jikan.SearchManga(keyword, pageNumber);
                    if (pageNumber > mangaSearchResult.ResultLastPage)
                    {
                        pageNumber = 1;
                        mangaSearchResult = jikan.SearchManga(keyword, pageNumber);
                    }
                    mangaSearchEntry = mangaSearchResult.Results.ToList();
                    ViewBag.Keyword = keyword;
                    ViewBag.Type = "Manga";
                    ViewBag.Result = mangaSearchEntry;
                    ViewBag.PageNumber = pageNumber;
                    return View();
                }
                catch
                {
                    return Index();
                }
            }
            else
            {
                pageNumber = 1;
                return Index();
            }            
        }
    }
}