using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuotingSystem.Models
{
    interface ITrackable
    {
        DateTime CreationDate { get; set; }
        DateTime LastChangedDate { get; set; }
    }
}
