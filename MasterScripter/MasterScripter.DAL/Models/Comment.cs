using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterScripter.DAL.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime CreationDate { get; set; }
        public int UserId { get; set; }
        public int ExecutionId { get; set; }
        public virtual User User { get; set; }
        public virtual Execution Execution { get; set; }

    }
}