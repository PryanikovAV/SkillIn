using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SkillIn.Entities
{
    public class StudentHardSkill
    {
        public Guid StudentId { get; set; }

        [ForeignKey(nameof(StudentId))]
        public virtual Student Student { get; set; }

        public Guid HardSkillId { get; set; }
        
        [ForeignKey(nameof(HardSkillId))]
        public virtual HardSkill HardSkill { get; set; }

        // Составной ключ, т.к. "многие ко многим"
        public class StudentHardSkillConfiguration : IEntityTypeConfiguration<StudentHardSkill>
        {
            public void Configure(EntityTypeBuilder<StudentHardSkill> builder)
            {
                builder.HasKey(shs => new { shs.StudentId, shs.HardSkillId });
            }
        }
    }
}
