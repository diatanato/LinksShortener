using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkShortener.Common.Interfaces.Models
{
    public interface IStatistic
    {
        Int32 Count { get; set; }
        DateTime CreationDate { get; set; }
    }
}
