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
    public enum DisciplineName
    {
        Mathematics = 1,
        Physics,
        ElectricalEngineering,
        BasicsOfProgramming,
        Databases,
        Modeling3D,
        TheoryOfAutomata
    }

    public class Discipline
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public DisciplineName DisciplineName { get; set; }

        // Внешний ключ на сущность Course
        public Guid CourseID { get; set; }
        [ForeignKey(nameof(CourseID))]
        public virtual Course Course { get; set; }
    }
}
