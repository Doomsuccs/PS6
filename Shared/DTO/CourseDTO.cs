using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DOOR.EF.Models;

#nullable disable
namespace DOOR.Shared.DTO
{
    public class CourseDTO
    {
        public int CourseNo { get; set; }
        [StringLength(50)]
        public string Description { get; set; } = null!;
        public decimal? Cost { get; set; }
        public int? Prerequisite { get; set; }
        [StringLength(30)]
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        [StringLength(30)]

        public string ModifiedBy { get; set; } = null!;
        public DateTime ModifiedDate { get; set; }
        public int SchoolId { get; set; }
        [Precision(8)]
        public int? PrerequisiteSchoolId { get; set; }

        public virtual School _School { get; set; } = null!;
    }
}
