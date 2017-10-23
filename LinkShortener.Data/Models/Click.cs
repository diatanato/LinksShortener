using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinkShortener.Data.Models
{
    public class Click
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Id { get; set; }
        public Int32 LinkId { get; set; }
        public DateTime Timestamp { get; set; }

        [ForeignKey("LinkId")]
        public virtual Link Link { get; set; }
    }
}
