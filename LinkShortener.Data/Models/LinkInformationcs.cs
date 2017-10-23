using System;

namespace LinkShortener.Data.Models
{
    using Common.Interfaces.Models;

    public class LinkInformationcs : ILinkInformation
    {
        public String ShortLink { get; set; }
        public String OriginalLink { get; set; }
        public Int32 Count { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
