using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterScripter.DAL.Models
{
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Code { get; set; }

        [MinLength(3), MaxLength(50), StringLength(50, MinimumLength = 3, ErrorMessage = Consts.MIN_MAX_ERROR_MSG)]
        public string Name { get; set; }

        public string Logo { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Machine> Machines { get; set; }
    }
}
