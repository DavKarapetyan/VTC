using VTC.BLL.Services.Interfaces;
using VTC.Common.ViewModels;
using System.Linq;
using VTC.DataAccess.Data;

namespace VTC.BLL.Services
{
    public class MainService : IMainService
    {
        private readonly VTCContext _context;

        public MainService(VTCContext context)
        {
            _context = context;
        }

        public async Task AboutUsEdit(AboutUsViewModel model)
        {
            var aboutUs =  _context.AboutUs.FirstOrDefault();

            aboutUs.Description = model.Description;

            await _context.SaveChangesAsync();
        }

        public async Task ContactUsEdit(ContactUsViewModel model)
        {
            var contactUs = _context.ContactUs.FirstOrDefault(); 

            contactUs.Address = model.Address;
            contactUs.PhoneNumber = model.PhoneNumber;
            contactUs.Email = model.Email;
            contactUs.Latitude = model.Latitude;
            contactUs.Longitude = model.Longitude;

            await _context.SaveChangesAsync();
        }

        public List<AboutUsViewModel> GetAboutUs()
        {
            var aboutUs = _context.AboutUs.Select(a => new AboutUsViewModel {
                Id = a.Id,
                Description = a.Description,
            }).ToList();

            return aboutUs;
        }

        public ContactUsViewModel GetConactUs() {
            var contactUs = _context.ContactUs.Select(a => new ContactUsViewModel
            {
                Address = a.Address,
                PhoneNumber = a.PhoneNumber,
                Id = a.Id,
                Email = a.Email,
                Latitude = a.Latitude,
                Longitude = a.Longitude,
            }).FirstOrDefault();

            return contactUs;
        }
    }
}
