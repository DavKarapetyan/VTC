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

        List<TrainingParticipantViewModel> trainingParticipants();
        Task AddTrainingPart(TrainingParticipantViewModel model);
        Task RemoveTrainingPart(int id);

        List<TrainingTopicViewModel> TrainingTopics(int id);
    }
}
