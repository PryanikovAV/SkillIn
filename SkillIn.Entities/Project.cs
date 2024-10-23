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
    public class Project
    {
        [Key]
        public Guid Id { get; set; }

        // Внешний ключ на сущность Student
        public Guid StudentID { get; set; }
        [ForeignKey(nameof(StudentID))]
        public virtual Student Student { get; set; }

        // Название проекта
        [Required]
        [MaxLength(100)]
        public string ProjectTitle { get; set; }

        // Описание проекта
        [MaxLength(500)]
        public string ProjectDescription { get; set; }
    }
}
