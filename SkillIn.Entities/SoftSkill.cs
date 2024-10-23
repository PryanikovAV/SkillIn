using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SkillIn.Entities
{
    public class SoftSkill
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        // "многие ко многим" со студенами
        public virtual ICollection<StudentSoftSkill> StudentSoftSkills { get; set; } = new List<StudentSoftSkill>();
    }
}
