using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DOOR.EF.Models
{
    [Keyless]
    [Table("ASP_NET_USER_ROLES")]
    [Index("RoleId", Name = "IX_ASP_NET_USER_ROLES_ROLE_ID")]
    [Index("UserId", "RoleId", Name = "PK_ASP_NET_USER_ROLES", IsUnique = true)]
    public partial class AspNetUserRole
    {
        [Column("USER_ID")]
        public string UserId { get; set; } = null!;
        [Column("ROLE_ID")]
        public string RoleId { get; set; } = null!;
    }
}
