using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterScripter.DAL.Models
{
    public class Script
    {
        [Key, Column(Order = 0)]
        public int Id { get; set; }
        [Key, Column(Order = 1)]
        public int Version { get; set; }
        public string Content { get; set; }

        [MinLength(3), MaxLength(50), StringLength(50, MinimumLength = 3, ErrorMessage = Consts.MIN_MAX_ERROR_MSG)]
        public string Name { get; set; }

        [MinLength(3), MaxLength(500), StringLength(500, MinimumLength = 3, ErrorMessage = Consts.MIN_MAX_ERROR_MSG)]
        public string Description { get; set; }
        public int UserId { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? CreationDate { get; set; }
        public double Cost { get; set; }

        public int FileTypeId { get; set; }
        public virtual FileType FileType { get; set; }

        public virtual User User { get; set; }
    }
}
