using System;
using System.ComponentModel.DataAnnotations;

namespace LinkShortener.Models.RequestPatameters.Links
{
    public class CreateRequestParameter
    {
        [Required]
        [DataType(DataType.Url)]
        public String Link { get; set; }
    }
}