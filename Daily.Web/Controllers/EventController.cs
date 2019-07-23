using Daily.Data;
using Daily.Data.Models;
using Daily.Web.Models.Event;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace Daily.Web.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventService _service;
        private readonly EventDbContext _context;

        public EventController(IEventService service, EventDbContext context)
        {
            _service = service;
            _context = context;

        }

        // GET: @event 
        public IActionResult Index()    
        {
            
            //创建一个新的模型类
            var eventModels = _service.GetAll()
                .Select(p => new EventDetailModel
                {
                    EventId = p.EventId,
                    Describe = p.Describe,
                    Duration = p.Duration,
                    Email = p.Email,
                    NewPeriod = p.NewPeriod,
                    NewPeriodTime = p.NewPeriodTime,
                    Period = p.Period,
                    StartTime = p.StartTime,
                    Summary = p.Summary
                }).ToList();

            var model = new EventIndexModel
            {
                Events = eventModels
            };

            return View(model);
        }

        // GET: @event /Details/5
        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var @event = _service.Get(id);
            //创建一个新的模型类
            var models = new EventDetailModel
                {
                    EventId = @event.EventId,
                    Describe = @event.Describe,
                    Duration = @event.Duration,
                    Email = @event.Email,
                    NewPeriod = @event.NewPeriod,
                    NewPeriodTime = @event.NewPeriodTime,
                    Period = @event.Period,
                    StartTime = @event.StartTime,
                    Summary = @event.Summary

                };
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // GET: @event /Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: @event /Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("EventId,Describe,Summary,StartTime,Duration,Email,Period,NewPeriod,NewPeriodTime")] Event @event)
        {
            if (ModelState.IsValid)
            {
                _service.Creat(@event);
                return RedirectToAction(nameof(Index));
            }
            return View(@event);
        }        

        // GET: @event /Edit/5
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var eventToUpdate = _service.Get(id);
            if (eventToUpdate == null)
            {
                return NotFound();
            }
            return View(eventToUpdate);
        }

        // POST: @event /Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("EventId,Describe,Summary,StartTime,Duration,Email,Period,NewPeriod,NewPeriodTime")] Event @event)
        {
            if (id != @event.EventId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _service.UpdateByEntity(@event);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(@event.EventId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(@event);
        }

        // GET: @event /Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = _context.Events
                .FirstOrDefault(m => m.EventId == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: @event /Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var confirmedEvent = _context.Events.Find(id);
            _context.Events.Remove(confirmedEvent);
            _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.EventId == id);
        }
    }
}
