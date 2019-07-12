    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Daily.Web.Models.Event
{
    public class EventIndexModel
    {
        public IEnumerable<EventDetailModel> Patrons { get; set; }
    }
}
