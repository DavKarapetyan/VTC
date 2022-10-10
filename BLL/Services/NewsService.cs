using VTC.BLL.Services.Interfaces;
using VTC.Common.ViewModels;
using VTC.DataAccess.Data;
using VTC.DataAccess.Entities;

namespace VTC.BLL.Services
{
    public class NewsService : INewsService
    {
        private readonly VTCContext _context;


        public NewsService(VTCContext context)
        {
            _context = context;
        }
        public async Task Add(NewsViewModel model)
        {
            News news = new News()
            {
                CreatedDate = DateTime.Now,
                Description = model.Description,
                IsDeleted = false,
                MainImage = model.MainImage,
                Title = model.Title,
            };

            _context.News.Add(news);
            _context.SaveChanges();
        }

        public async Task Edit(NewsViewModel model)
        {
            var news = _context.News.Where(a => a.Id == model.Id).FirstOrDefault();

            news.Description = model.Description;
            news.MainImage = model.MainImage;
            news.Title = model.Title;

            _context.SaveChanges();
        }

        public async Task<List<NewsViewModel>> GetAll()
        {
            List<NewsViewModel> news = _context.News.Where(a => !a.IsDeleted).Select(a => new NewsViewModel
            {
                Description = a.Description,
                Id = a.Id,
                Title = a.Title,
                MainImage = a.MainImage,
                CreatedDate = a.CreatedDate,
                ShortDescription = a.Description.Remove(350) + "..."
            }).ToList();

            return news;
        }

        public async Task<NewsViewModel> GetById(int id)
        {
            var news = _context.News
                .Where(a => a.Id == id)
                .Select(a => new NewsViewModel
                {
                    Description = a.Description,
                    Id = a.Id,
                    Title= a.Title,
                    MainImage = a.MainImage,
                }).FirstOrDefault();

            return news;
        }

        public async Task Remove(int id)
        {
            var news = _context.News.Where(a => a.Id == id).FirstOrDefault();
            news.IsDeleted = true;
            _context.SaveChanges();
        }
    }
}
