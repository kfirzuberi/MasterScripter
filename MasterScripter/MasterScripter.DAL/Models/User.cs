using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterScripter.DAL.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [MinLength(3), MaxLength(50), StringLength(50, MinimumLength = 3, ErrorMessage = Consts.MIN_MAX_ERROR_MSG)]
        public string FullName { get; set; }

        [RegularExpression(Consts.EMAIL_REGEX, ErrorMessage = "Invalid email"), MinLength(3), MaxLength(50)]
        public string Email { get; set; }

        public Role Role { get; set; }

        public bool IsDeleted { get; set; }

        public int CompanyCode { get; set; }
       
        [Column(TypeName = "datetime2")]
        public DateTime? CreationDate { get; set; }
        public virtual ICollection<Script> Scripts { get; set; }
        public virtual ICollection<Execution> Executions { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual Company Company { get; set; }
    }
}
