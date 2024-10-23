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
    public enum CourseLevel
    {
        FirstCourse = 1,
        SecondCourse,
        ThirdCourse,
        FourthCourse,
        FifthCourse,
        Master,  // Магистр
        PhD      // Аспирант
    }

    public class Course
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public CourseLevel CourseLevel { get; set; }

        public virtual ICollection<Discipline> Disciplines { get; set; } = new List<Discipline>();
    }
}
