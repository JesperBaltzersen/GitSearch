using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GitStalker.Models
{
    public class GitUserSearchResponse
    {
        public int total_count { get; set; }
        public bool incomplete_results { get; set; }

        [JsonProperty("Items")]
        public List<GitUser> GitUsers { get; set; }
    }
}
