using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkShortener.Common.Interfaces.Models
{
    public interface IStatistic
    {
        String Count { get; set; }
        String CreationDate { get; set; }
    }
}
