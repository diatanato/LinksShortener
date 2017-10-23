using System;

namespace LinkShortener.Common.Interfaces.Models
{
    public interface ILink
    {
        String ShortLink    { get; set; }
        String OriginalLink { get; set; }
    }
}
