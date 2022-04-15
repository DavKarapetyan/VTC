using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTC.DataAccess.Entities
{
    public class TrainingTopic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TrainingId { get; set; }
        [ForeignKey("TrainingId")]
        public virtual Training Training { get; set; }
    }
}
