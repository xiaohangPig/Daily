using System;
using System.Collections.Generic;
using System.Text;

namespace Daily.Data.Models
{
    public class Calendar
    {
        public int id { get; set; }
        public DateTime eventTime { get; set; }
        public int eventId { get; set; }

        
        public virtual List<Event> Events { get; set; }
    }
}
