using AnimePortalJikanAPI.JikanDecoder.Consts;
using AnimePortalJikanAPI.JikanDecoder.Exceptions;
using AnimePortalJikanAPI.JikanDecoder.Helpers;
using AnimePortalJikanAPI.JikanDecoder.Interfaces;
using AnimePortalJikanAPI.JikanDecoder.Model.Core;
using AnimePortalJikanAPI.JikanDecoder.Model.Search;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace AnimePortalJikanAPI.JikanDecoder
{
    public class Jikan : IJikan

    {
        #region Field

        private readonly bool useHttps;

        private readonly bool surpressException;

        private readonly HttpClient httpClient;

        #endregion Field

        #region Properties

        /// <summary>
        /// End to which request will be send to.
        /// </summary>
        public string Endpoint
        {
            get
            {
                return this.useHttps ? HttpProvider.httpsEndpoint : HttpProvider.httpEndpoint;
            }
        }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="useHttps">Should client send SSL encrypted requests.</param>
        /// <param name="surpressException">Should exception be thrown in case of failed request. If true, failed request return null.</param>
        public Jikan(bool useHttps, bool surpressException = true)
        {
            this.useHttps = useHttps;
            this.surpressException = surpressException;
            httpClient = HttpProvider.GetHttpClient(useHttps);
        }

        #endregion Constructors

        #region Anime methods

        #region GetAnime

        public Anime GetAnime(long id)
        {
            string[] endpointParts = new string[] { Endpoint, JikanEndPointCategories.Anime, id.ToString() };
            return ExecuteGetRequest<Anime>(endpointParts);
        }

        #endregion GetAnime

        #endregion Anime methods

        #region Manga methods

        #region SearchManga

        /// <summary>
        /// Return list of results related to search.
        /// </summary>
        /// <param name="query">Search query.</param>
        /// <returns>List of result related to search query.</returns>
        public MangaSearchResult SearchManga(string query)
        {
            query = string.Concat("?q=", query.Replace(' ', '_'));
            string[] endpointParts = new string[] { Endpoint, JikanEndPointCategories.Search, JikanEndPointCategories.Manga, query };
            return ExecuteGetRequest<MangaSearchResult>(endpointParts);
        }

        /// <summary>
        /// Return list of results related to search.
        /// </summary>
        /// <param name="query">Search query.</param>
        /// <param name="page">Indexx of page folding 50 records of top ranging (e.g. 1 will return first 50 records, 2 will return record from 51 to 100 etc.)</param>
        /// <returns>List of result related to search query.</returns>
        public MangaSearchResult SearchManga(string query, int page)
        {
            query = string.Concat("?q=", query.Replace(' ', '_'));
            string[] endpointParts = new string[] { Endpoint, JikanEndPointCategories.Search, JikanEndPointCategories.Manga, query, page.ToString() };
            return ExecuteGetRequest<MangaSearchResult>(endpointParts);
        }

        #endregion SearchManga

        #region GetManga

        /// <summary>
        /// Return manga with given MAL id.
        /// </summary>
        /// <param name="id">MAL id of manga.</param>
        /// <returns>Manga with given MAL id.</returns>
        public Manga GetManga(long id)
        {
            string[] endpointParts = new string[] { Endpoint, JikanEndPointCategories.Manga, id.ToString() };
            return ExecuteGetRequest<Manga>(endpointParts);
        }

        #endregion GetManga

        #region GetMangaTop

        /// <summary>
        /// Return list of top manga.
        /// </summary>
        /// <returns>List of top manga.</returns>
        public MangaTop GetMangaTop()
        {
            string[] endpointParts = new string[] { Endpoint, JikanEndPointCategories.TopList, JikanEndPointCategories.Manga };
            return ExecuteGetRequest<MangaTop>(endpointParts);
        }

        /// <summary>
        /// Return list of top manga.
        /// </summary>
        /// <param name="page">Indexx of page folding 50 records of top ranging (e.g. 1 will return first 50 records, 2 will return record from 51 to 100 etc.)</param>
        /// <returns>List of top manga.</returns>
        public MangaTop GetMangaTop(int page)
        {
            string[] endpointParts = new string[] { Endpoint, JikanEndPointCategories.TopList, JikanEndPointCategories.Manga, page.ToString() };
            return ExecuteGetRequest<MangaTop>(endpointParts);
        }

        #endregion GetMangaTop

        #endregion Manga methods

        #region Top methods

        #region GetAnimeTop

        /// <summary>
        /// Return list of top anime.
        /// </summary>
        /// <returns>List of top anime.</returns>
        public AnimeTop GetAnimeTop()
        {
            string[] endpointParts = new string[] { Endpoint, JikanEndPointCategories.TopList, JikanEndPointCategories.Anime };
            return ExecuteGetRequest<AnimeTop>(endpointParts);
        }

        /// <summary>
        /// Return list of top anime.
        /// </summary>
        /// <param name="page">Indexx of page folding 50 records of top ranging (e.g. 1 will return first 50 records, 2 will return record from 51 to 100 etc.)</param>
        /// <returns>List of top anime.</returns>
        public AnimeTop GetAnimeTop(int page)
        {
            string[] endpointParts = new string[] { Endpoint, JikanEndPointCategories.TopList, JikanEndPointCategories.Anime, page.ToString() };
            return ExecuteGetRequest<AnimeTop>(endpointParts);
        }

        #endregion GetAnimeTop

        #endregion Top methods

        #region SearchAnime

        /// <summary>
        /// Return list of results related to search.
        /// </summary>
        /// <param name="query">Search query.</param>
        /// <returns>List of result related to search query.</returns>
        public AnimeSearchResult SearchAnime(string query)
        {
            query = string.Concat("?q=", query.Replace(' ', '_'));
            string[] endpointParts = new string[] { Endpoint, JikanEndPointCategories.Search, JikanEndPointCategories.Anime, query };
            return ExecuteGetRequest<AnimeSearchResult>(endpointParts);
        }

        /// <summary>
        /// Return list of results related to search.
        /// </summary>
        /// <param name="query">Search query.</param>
        /// <param name="page">Indexx of page folding 50 records of top ranging (e.g. 1 will return first 50 records, 2 will return record from 51 to 100 etc.)</param>
        /// <returns>List of result related to search query.</returns>
        public AnimeSearchResult SearchAnime(string query, int page)
        {
            query = string.Concat("?q=", query.Replace(' ', '_'));
            string[] endpointParts = new string[] { Endpoint, JikanEndPointCategories.Search, JikanEndPointCategories.Anime, query, page.ToString() };
            return ExecuteGetRequest<AnimeSearchResult>(endpointParts);
        }

        #endregion SearchAnime

        #region Private Methods

        /// <summary>
        /// Vasic method for handling requests and responses from endpoint.
        /// </summary>
        /// <typeparam name="T">Class type received from GET requests.</typeparam>
        /// <param name="args">Arguments building endpoint.</param>
        /// <returns>Requested object if successfull, null otherwise.</returns>
        private T ExecuteGetRequest<T>(string[] args) where T : class
        {
            T returnedObject = null;
            string requestUrl = String.Join("/", args);
            try
            {
                string json = "";
                var client = new HttpClient();
                var getDataTask = httpClient.GetAsync(requestUrl)
                    .ContinueWith(response =>
                    {
                        var result = response.Result;
                        if (result.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var responseData = result.Content.ReadAsStringAsync();
                            responseData.Wait();
                            json = responseData.Result;
                        }
                        else if (!surpressException)
                        {
                            throw new JikanRequestException();
                        }
                    });

                getDataTask.Wait();
                returnedObject = JsonConvert.DeserializeObject<T>(json);
            }
            catch (JsonSerializationException ex)
            {
                if (!surpressException)
                {
                    throw new JikanRequestException(ex.Message);
                }
            }
            return returnedObject;

            #endregion Private Methods
        }
    }
}