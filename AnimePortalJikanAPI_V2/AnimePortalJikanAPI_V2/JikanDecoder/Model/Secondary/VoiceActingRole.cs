﻿using Newtonsoft.Json;

namespace AnimePortalJikanAPI.JikanDecoder.Model.Secondary
{
	/// <summary>
	/// Voice acting role model class for person's class.
	/// </summary>
	public class VoiceActingRole
	{
		/// <summary>
		/// Anime associated with voice acting role.
		/// </summary>
		[JsonProperty(PropertyName = "anime")]
		public MALImageSubItem Anime { get; set; }

		/// <summary>
		/// Character associated with voice acting role.
		/// </summary>
		[JsonProperty(PropertyName = "character")]
		public MALImageSubItem Character { get; set; }

		/// <summary>
		/// Status of the role: Main/Supporting.
		/// </summary>
		[JsonProperty(PropertyName = "role")]
		public string Role { get; set; }
	}
}