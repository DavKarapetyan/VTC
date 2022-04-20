using VTC.BLL.Services.Interfaces;
using VTC.Common.ViewModels;
using VTC.DataAccess.Entities;
using VTC.Common.Enums;
using VTC.DataAccess.Data;

namespace VTC.BLL.Services
{
    public class EventService : IEventService
    {
        private readonly VTCContext _context;


        public EventService(VTCContext context)
        {
            _context = context;
        }
        public async Task Add(EventViewModel model)
        {
            Event event1 = new Event()
            {
                CreatedDate = DateTime.Now,
                Date = model.Date,
                Description = model.Description,
                IsDeleted = false,
                MainImage = model.MainImage,
                Name = model.Name,
                Time = model.Time,
            };

            _context.Events.Add(event1);
            _context.SaveChanges();
        }

        public async Task Edit(EventViewModel model)
        {
            var event1 = _context.Events.Where(a => a.Id == model.Id).FirstOrDefault();
            
            event1.Time = model.Time;
            event1.Name = model.Name;
            event1.Description = model.Description;
            event1.Date = model.Date;
            event1.MainImage = model.MainImage;

            _context.SaveChanges();
        }

        public async Task<List<EventViewModel>> GetAll()
        {
            List<EventViewModel> events = _context.Events.Where(a => !a.IsDeleted).Select(a => new EventViewModel
            {
                Date = a.Date,
                Description = a.Description,
                Id = a.Id,
                MainImage = a.MainImage,
                Name = a.Name,
                Time = a.Time,
            }).ToList();

            return events;
        }

        public async Task<EventViewModel> GetById(int id)
        {
            var event1 = _context.Events
                .Where(a => a.Id == id)
                .Select(a => new EventViewModel
                    {
                        Date = a.Date,
                        Description = a.Description,
                        Id = a.Id,
                        MainImage = a.MainImage,
                        Name = a.Name,
                        Time = a.Time,
                    }).FirstOrDefault();

            return event1;
        }

        public async Task Remove(int id)
        {
            var event1 = _context.Events.Where(a => a.Id == id).FirstOrDefault();
            event1.IsDeleted = true;
            _context.SaveChanges();
        }
    }
}
