using VTC.Common.ViewModels;

namespace VTC.BLL.Services.Interfaces
{
    public interface IEventService
    {
        Task Add(EventViewModel model);
        Task Edit(EventViewModel model);
        Task Remove(int id);
        Task<EventViewModel> GetById(int id);
        Task<List<EventViewModel>> GetAll();
    }
}
