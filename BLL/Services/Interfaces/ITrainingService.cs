using VTC.Common.ViewModels;

namespace VTC.BLL.Services.Interfaces
{
    public interface ITrainingService
    {
        Task Add(TrainingViewModel model);
        Task Edit(TrainingViewModel model);
        Task Remove(int id);
        Task<TrainingViewModel> GetById(int id);
        List<TrainingViewModel> GetAll(int statusId);
    }
}
