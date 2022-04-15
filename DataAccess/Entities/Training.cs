using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VTC.Common.Enums;

namespace VTC.DataAccess.Entities
{
    public class Training : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TrainingType Type { get; set; }
        public TrainingStatus Status { get; set; }
        public virtual ICollection<TrainingParticipant> TrainingParticipants { get; set; }
        public virtual ICollection<TrainingLevel> TrainingLevels { get; set; }
        public virtual ICollection<TrainingTopic> TrainingTopics { get; set; }
    }
}
