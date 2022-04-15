using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace VTC.DataAccess.Entities
{
    public class TrainingParticipant : BaseEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Level { get; set; }
        public int TrainingId { get; set; }
        [ForeignKey("TrainingId")]
        public virtual Training Training { get; set; }
    }
}
