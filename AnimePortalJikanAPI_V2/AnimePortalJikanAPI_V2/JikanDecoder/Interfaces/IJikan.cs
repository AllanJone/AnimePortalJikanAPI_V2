using AnimePortalJikanAPI.JikanDecoder.Model.Core;
using AnimePortalJikanAPI.JikanDecoder.Model.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimePortalJikanAPI.JikanDecoder.Interfaces
{
    /// <summary>
	/// Interface for Jikan.net client
	/// </summary>
    public interface IJikan
    {
        /// <summary>
        /// Returns anime with given MAL id.
        /// </summary>
        /// <param name="id">MAL id of anime.</param>
        /// <returns>Anime with given MAL id.</returns>
        Anime GetAnime(long id);

        /// <summary>
        /// Returns list of top anime.
        /// </summary>
        /// <returns>List of top anime.</returns>
        AnimeTop GetAnimeTop();

        /// <summary>
        /// Returns list of top anime.
        /// </summary>
        /// <param name="page">Index of page folding 50 records of top ranging (e.g. 1 will return first 50 records, 2 will return record from 51 to 100 etc.)</param>
        /// <returns>List of top anime.</returns>
        AnimeTop GetAnimeTop(int page);

        /// <summary>
        /// Returns list of results related to search.
        /// </summary>
        /// <param name="query">Search query.</param>
        /// <returns>List of result related to search query.</returns>
        AnimeSearchResult SearchAnime(string query);

        /// <summary>
        /// Returns list of results related to search.
        /// </summary>
        /// <param name="query">Search query.</param>
        /// <param name="page">Index of page folding 50 records of top ranging (e.g. 1 will return first 50 records, 2 will return record from 51 to 100 etc.)</param>
        /// <returns>List of result related to search query.</returns>
        AnimeSearchResult SearchAnime(string query, int page);

        /// <summary>
        /// Returns list of results related to search.
        /// </summary>
        /// <param name="query">Search query.</param>
        /// <returns>List of result related to search query.</returns>
        MangaSearchResult SearchManga(string query);

        /// <summary>
        /// Returns list of results related to search.
        /// </summary>
        /// <param name="query">Search query.</param>
        /// <param name="page">Index of page folding 50 records of top ranging (e.g. 1 will return first 50 records, 2 will return record from 51 to 100 etc.)</param>
        /// <returns>List of result related to search query.</returns>
        MangaSearchResult SearchManga(string query, int page);

        /// <summary>
        /// Returns manga with given MAL id.
        /// </summary>
        /// <param name="id">MAL id of manga.</param>
        /// <returns>Manga with given MAL id.</returns>
        Manga GetManga(long id);

        /// <summary>
		/// Returns list of top manga.
		/// </summary>
		/// <returns>List of top manga.</returns>
		MangaTop GetMangaTop();

        /// <summary>
        /// Returns list of top manga.
        /// </summary>
        /// <param name="page">Index of page folding 50 records of top ranging (e.g. 1 will return first 50 records, 2 will return record from 51 to 100 etc.)</param>
        /// <returns>List of top manga.</returns>
        MangaTop GetMangaTop(int page);
    }
}
