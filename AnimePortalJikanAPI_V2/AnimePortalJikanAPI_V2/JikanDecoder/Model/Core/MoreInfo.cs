﻿using Newtonsoft.Json;

namespace AnimePortalJikanAPI.JikanDecoder.Model.Core
{
	/// <summary>
	/// Extra information stored in "more info" tab.
	/// </summary>
	public class MoreInfo
	{
		/// <summary>
		/// Extra information stored in "more info" tab.
		/// </summary>
		[JsonProperty(PropertyName = "moreinfo")]
		public string Info { get; set; }
	}
}