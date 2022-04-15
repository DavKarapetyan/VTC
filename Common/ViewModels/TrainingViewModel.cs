using VTC.Common.Enums;

namespace VTC.Common.ViewModels
{
    public class TrainingViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TrainingStatus Status { get; set; }
    }
}
