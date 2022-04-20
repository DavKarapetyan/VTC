using VTC.Common.ViewModels;

namespace VTC.BLL.Services.Interfaces
{
    public interface IServiceService
    {
        Task Add(ServiceViewModel model);
        Task Edit(ServiceViewModel model);
        Task Remove(int id);
        Task<ServiceViewModel> GetById(int id);
        Task<List<ServiceViewModel>> GetAll();
    }
}
