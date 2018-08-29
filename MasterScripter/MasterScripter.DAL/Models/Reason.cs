using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MasterScripter.DAL.Models
{
    public class Reason
    {
        public int Id { get; set; }

        [MinLength(5), MaxLength(50), StringLength(50, MinimumLength = 5, ErrorMessage = Consts.MIN_MAX_ERROR_MSG)]
        public string ReasonName { get; set; }
        public virtual ICollection<Execution> Executions { get; set; }

    }
}
