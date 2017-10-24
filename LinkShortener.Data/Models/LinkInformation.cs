using System;

namespace LinkShortener.Data.Models
{
    using Common.Interfaces.Models;

    public class LinkInformation : ILinkInformation
    {
        public String ShortLink { get; set; }
        public String OriginalLink { get; set; }
        public String Count { get; set; }
        public String CreationDate { get; set; }
    }
}
