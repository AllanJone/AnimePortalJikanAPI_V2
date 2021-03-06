﻿using AnimePortalJikanAPI.JikanDecoder.Model.Secondary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimePortalJikanAPI.JikanDecoder.Model.Core
{
	/// <summary>
	/// Model class for collection of MyAnimeList forum topic.
	/// </summary>
	public class ForumTopics
	{
		/// <summary>
		/// Forum topics related to anime.
		/// </summary>
		[JsonProperty(PropertyName = "topics")]
		public ICollection<ForumTopic> Topics { get; set; }
	}
}
