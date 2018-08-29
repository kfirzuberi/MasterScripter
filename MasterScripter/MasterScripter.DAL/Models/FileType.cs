using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MasterScripter.DAL.Models
{
    public class FileType
    {
        public int Id { get; set; }

        [MinLength(1), MaxLength(20), StringLength(20, MinimumLength = 1, ErrorMessage = Consts.MIN_MAX_ERROR_MSG)]
        public string Language { get; set; }

        [MinLength(2), MaxLength(4), StringLength(4, MinimumLength = 2, ErrorMessage = Consts.MIN_MAX_ERROR_MSG)]
        public string FileExt { get; set; }

        public virtual  ICollection<Script> Scripts { get; set; }
    }
}
