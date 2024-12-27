using JSM.Domain.Models.Base;

namespace JSM.Domain.Models
{
    public class CustomerPortrait : EntityBase
    {
        public int CustomerId { get; private set; }
        public string Large { get; private set; } = string.Empty;
        public string Medium { get; private set; } = string.Empty;
        public string Thumbnail { get; private set; } = string.Empty;

        private CustomerPortrait() { }

        public CustomerPortrait(string large, string medium, string thumbnail)
        {
            Large = large;
            Medium = medium;
            Thumbnail = thumbnail;
        }
    }
}
