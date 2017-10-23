using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinkShortener.Data.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Id { get; set; }

        [Index(IsUnique = true)]
        public Guid UserKey { get; set; }
    }
}