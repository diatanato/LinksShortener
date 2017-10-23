using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinkShortener.Data.Models
{
    using Common.Interfaces.Models;

    public class Link : ILink
    {
        public Link()
        {
            Clicks = new List<Click>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Id { get; set; }
        public Int32 UserId { get; set; }
        public String ShortLink { get; set; }
        public String OriginalLink { get; set; }
        public DateTime CreationDate { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public ICollection<Click> Clicks { get; set; }
    }
}
