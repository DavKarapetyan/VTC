using VTC.Common.ViewModels;

namespace VTC.BLL.Services.Interfaces
{
    public interface INewsService
    {
        Task Add(NewsViewModel model);
        Task Edit(NewsViewModel model);
        Task Remove(int id);
        Task<NewsViewModel> GetById(int id);
        Task<List<NewsViewModel>> GetAll();
    }
}
