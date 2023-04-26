using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DOOR.EF.Models
{
    [Keyless]
    [Table("SCHOOL_USER")]
    public partial class SchoolUser
    {
        [Column("SCHOOL_ID")]
        [Precision(8)]
        public int SchoolId { get; set; }
        [Column("USER_ID")]
        [StringLength(450)]
        public string UserId { get; set; } = null!;
        [Column("STUDENT_ID")]
        [Precision(8)]
        public int StudentId { get; set; }
        [Column("INSTRUCTOR_ID")]
        [Precision(8)]
        public int InstructorId { get; set; }
        [Column("CREATED_BY")]
        [StringLength(30)]
        [Unicode(false)]
        public string CreatedBy { get; set; } = null!;
        [Column("CREATED_DATE", TypeName = "DATE")]
        public DateTime CreatedDate { get; set; }
        [Column("MODIFIED_BY")]
        [StringLength(30)]
        [Unicode(false)]
        public string ModifiedBy { get; set; } = null!;
        [Column("MODIFIED_DATE", TypeName = "DATE")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("SchoolId,InstructorId")]
        public virtual Instructor Instructor { get; set; } = null!;
        [ForeignKey("StudentId,SchoolId")]
        public virtual Student S { get; set; } = null!;
        [ForeignKey("SchoolId")]
        public virtual School School { get; set; } = null!;
        [ForeignKey("UserId")]
        public virtual AspNetUser User { get; set; } = null!;
    }
}
