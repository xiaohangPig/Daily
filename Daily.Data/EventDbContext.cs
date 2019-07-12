using Daily.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Daily.Data
{
    public class EventDbContext : DbContext
    {
        public EventDbContext()
        {
        }
        public EventDbContext(DbContextOptions options): base(options)
        {
        }
        public virtual DbSet<Event> Events { get; set; }        
    }
}
