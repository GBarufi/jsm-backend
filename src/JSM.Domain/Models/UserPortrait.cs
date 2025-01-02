using JSM.Domain.Models.Base;

namespace JSM.Domain.Models
{
    public class UserPortrait : EntityBase
    {
        public int UserId { get; private set; }
        public string Large { get; private set; } = string.Empty;
        public string Medium { get; private set; } = string.Empty;
        public string Thumbnail { get; private set; } = string.Empty;

        private UserPortrait() { }

        public UserPortrait(string large, string medium, string thumbnail)
        {
            Large = large;
            Medium = medium;
            Thumbnail = thumbnail;
        }
    }
}
