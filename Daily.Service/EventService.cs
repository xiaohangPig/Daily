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

        public void Creat(Event newEvent)
        {
            _context.Add(newEvent);
            _context.SaveChanges();
        }

        public void DeletById(int id)
        {
            var deletEvent =  _context.Events.Find(id);
            _context.Events.Remove(deletEvent);
             _context.SaveChangesAsync();
        }

        public Event Get(int id)
        {
            return _context.Events.FirstOrDefault(e => e.EventId == id);
        }

        public IEnumerable<Event> GetAll()
        {
            return _context.Events;
        }

        //public void UpdateById(int id)
        //{
        //    _context.Find(id);
        //    _context.Update(updateEvent);
        //    _context.SaveChanges();

        //}

        public void UpdateByEntity(Event @event)
        {
            _context.Update(@event);
            _context.SaveChanges();

        }
    }
}
