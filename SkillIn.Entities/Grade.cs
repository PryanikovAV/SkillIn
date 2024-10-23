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
    public enum GradeName
    {
        Unrated = 1,
        Unsatisfactory,
        Satisfactory,
        Good,
        Excellent
    }

    public class Grade
    {
        [Key]
        public Guid Id { get; set; }

        // Внешний ключ на сущность Student
        public Guid StudentID { get; set; }
        [ForeignKey(nameof(StudentID))]
        public virtual Student Student { get; set; }

        // Внешний ключ на сущность Discipline
        public Guid DisciplineID { get; set; }
        [ForeignKey(nameof(DisciplineID))]
        public virtual Discipline Discipline { get; set; }

        [Required]
        public GradeName GradeName { get; set; }
    }
}
