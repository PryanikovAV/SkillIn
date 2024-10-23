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
    public enum SpecialityName
    {
        IVT090301 = 1,
        IST090302,
        PI090303,
        PI090304
    }
    public class Speciality
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public SpecialityName SpecialityName { get; set; }

        // Внешний ключ на сущность Faculty
        public Guid FacultyID { get; set; }
        [ForeignKey(nameof(FacultyID))]
        public virtual Faculty Faculty { get; set; }
    }
}
