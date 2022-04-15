using VTC.DataAccess.Entities;
using VTC.BLL.Services.Interfaces;
using VTC.Common.ViewModels;
using VTC.DataAccess.Data;

namespace VTC.BLL.Services
{
    public class ServiceService : IServiceService
    {
        private readonly VTCContext _context;


        public ServiceService(VTCContext context)
        {
            _context = context;
        }
        public async Task Add(ServiceViewModel model)
        {
            Service service = new Service()
            {
                CreatedDate = DateTime.Now,
                Description = model.Description,
                Name = model.Name,
            };

            _context.Services.Add(service);
            _context.SaveChanges();
        }

        public async Task Edit(ServiceViewModel model)
        {
            var service = _context.Services.Where(a => a.Id == model.Id).FirstOrDefault();

            service.Name = model.Name;
            service.Description = model.Description;

            _context.SaveChanges();
        }

        public async Task<List<ServiceViewModel>> GetAll()
        {
            List<ServiceViewModel> service = _context.Services.Where(a => !a.IsDeleted).Select(a => new ServiceViewModel
            {
                Description = a.Description,
                Id = a.Id,
                Name = a.Name,
            }).ToList();

            return service;
        }

        public async Task<ServiceViewModel> GetById(int id)
        {
            var service = _context.Services
                .Where(a => a.Id == id)
                .Select(a => new ServiceViewModel
                {
                    Description = a.Description,
                    Id = a.Id,
                    Name = a.Name,
                }).FirstOrDefault();

            return service;
        }

        public async Task Remove(int id)
        {
            var service = _context.Services.Where(a => a.Id == id).FirstOrDefault();
            service.IsDeleted = true;
            _context.SaveChanges();
        }
    }
}
