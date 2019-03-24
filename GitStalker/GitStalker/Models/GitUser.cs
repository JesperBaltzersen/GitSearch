using System;

namespace GitStalker.Models
{
    public class GitUser : IComparable
    {
        public string login { get; set; }
        public int id { get; set; }
        public string node_id { get; set; }
        public string avatar_url { get; set; }
        public string gravatar_id { get; set; }
        public string url { get; set; }
        public string html_url { get; set; }
        public string followers_url { get; set; }
        public string following_url { get; set; }
        public string gists_url { get; set; }
        public string starred_url { get; set; }
        public string subscriptions_url { get; set; }
        public string organizations_url { get; set; }
        public string repos_url { get; set; }
        public string events_url { get; set; }
        public string received_events_url { get; set; }
        public string type { get; set; }
        public bool site_admin { get; set; }
        public double score { get; set; }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            GitUser otherGitUser = obj as GitUser;
            if (this.id == otherGitUser.id) return 0;
            if (this.id < otherGitUser.id) return -1;
            if (this.id > otherGitUser.id) return 1;

            return 1;
        }
    }
}
