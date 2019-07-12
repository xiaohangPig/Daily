using Daily.Data;
using Daily.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Daily.Service
{
    public class EventService : IEventService
    {
        private readonly EventDbContext _context;
        

        public EventService(EventDbContext context)
        {
            _context = context;
        }

        public void Add(Event newEvent)
        {
            _context.Add(newEvent);
            _context.SaveChanges();
        }

        public void DeletById(int id)
        {
            var deletEvent =  _context.Events
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.EventId == id);
            
            db.DimCustomer.Update(updatedCustomer);
            db.Savechanges();

            return RedirectToAction("CustomerList");
        }

        public Event Get(int id)
        {
            return _context.Events.FirstOrDefault(e => e.EventId == id);
        }

        public IEnumerable<Event> GetAll()
        {
            return _context.Events;
        }

        public void UpdateById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
