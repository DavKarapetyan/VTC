using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace VTC.DataAccess.Entities
{
    public class TrainingLevel : BaseEntity
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Price { get; set; }
        public int TrainingId { get; set; }
        [ForeignKey("TrainingId")]
        public virtual Training Training { get; set; }
    }
}
