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
    public class Student : User
    {
        // Имя
        [MaxLength(64)]
        public string? FirstName { get; set; }

        // Отчество
        [MaxLength(64)]
        public string? MiddleName { get; set; }

        // Фамилия
        [MaxLength(64)]
        public string? LastName { get; set; }

        // Фото
        public byte[]? Photo { get; set; } // ?

        public Guid CourseID { get; set; }
        
        [ForeignKey(nameof(CourseID))]
        public virtual Course? Course { get; set; }
  
        public virtual Project? Project { get; set; }

        public Guid FacultyID { get; set; }
        [ForeignKey(nameof(FacultyID))]
        public virtual Faculty? Faculty { get; set; }


        public Guid SpecialityID { get; set; }
        [ForeignKey(nameof(SpecialityID))]
        public virtual Speciality? Speciality { get; set; }

        // "многие ко многим" c HardSkill
        public virtual ICollection<StudentHardSkill> StudentHardSkills { get; set; } = new List<StudentHardSkill>();

        // "многие ко многим" c SoftSkill
        public virtual ICollection<StudentSoftSkill> StudentSoftSkills { get; set; } = new List<StudentSoftSkill>();
    }
}
