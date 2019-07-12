using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Daily.Data;                                                                           
using Daily.Data.Models;
using Daily.Web.Models;
using Daily.Web.Models.Event;

namespace Daily.Web.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventService _context;

        public EventController(IEventService context)
        {
            _context = context;
        }

        // GET: @event 
        public IActionResult Index()    
        {
            var allEvents = _context.GetAll();

            //创建一个新的模型类
            var eventModels = allEvents
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
                Patrons = eventModels
            };

            return View(model);
        }

        // GET: @event /Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var @event = _context.Get(id);
            //创建一个新的模型类
            var models = new EventDetailModel
                {
                    EventId = @event .EventId,
                    Describe = @event .Describe,
                    Duration = @event .Duration,
                    Email = @event .Email,
                    NewPeriod = @event .NewPeriod,
                    NewPeriodTime = @event .NewPeriodTime,
                    Period = @event .Period,
                    StartTime = @event .StartTime,
                    Summary = @event .Summary

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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventId,Describe,Summary,StartTime,Duration,Email,Period,NewPeriod,NewPeriodTime")] Event @event)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@event);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@event);
        }

        // GET: @event /Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }
            return View(@event);
        }

        // POST: @event /Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventId,Describe,Summary,StartTime,Duration,Email,Period,NewPeriod,NewPeriodTime")] Event @event)
        {
            if (id != @event.EventId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@event);
                    await _context.SaveChangesAsync();
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
        //根据id删除
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events
                .FirstOrDefaultAsync(m => m.EventId == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: @event /Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @event = await _context.Events.FindAsync(id);
            _context.Events.Remove(@event);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.EventId == id);
        }
    }
}
