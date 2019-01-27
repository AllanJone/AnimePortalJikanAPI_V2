﻿using AnimePortalJikanAPI.JikanDecoder.Model.Secondary;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AnimePortalJikanAPI.JikanDecoder.Model.Core
{
	/// <summary>
	/// Anime news list model class.
	/// </summary>
	public class AnimeNews
	{
		/// <summary>
		/// News related to anime.
		/// </summary>
		[JsonProperty(PropertyName = "articles")]
		public ICollection<News> News { get; set; }
	}
}