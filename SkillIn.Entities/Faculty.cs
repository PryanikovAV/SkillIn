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
    public enum FacultyName
    {
        Architectural = 1,
        MedicalBiological,
        ElectronicsComputerScience,
        Linguistics,
        Humanities,
        NaturalSciences,
        SportsTourismService,
        PolytechnicInstitute,
        LawInstitute
    }

    public class Faculty
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public FacultyName FacultyName { get; set; }
    }
}
