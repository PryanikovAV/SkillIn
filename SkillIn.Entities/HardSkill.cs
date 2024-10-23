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
    public class HardSkill
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        // "Многие ко многим" со студентами
        public virtual ICollection<StudentHardSkill> StudentHardSkills { get; set; } = new List<StudentHardSkill>();
    }
}
