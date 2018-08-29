using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterScripter.DAL.Models
{
    public class Execution
    {
        public int Id { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? CreationDate { get; set; }
        public Status Status { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? SrartTime { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? EndTime { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? ScheduleTime { get; set; }
        public int UserId { get; set; }
        public int ReasonId { get; set; }
        public int MachineVLan { get; set; }
        public string MachineIP { get; set; }
        public virtual User User { get; set; }
        public virtual Machine Machine { get; set; }
        public virtual Reason Reason { get; set; }
        public virtual ICollection<ExecutionsScripts> ExecutionsScriptses { get; set; }
        public virtual ICollection<Comment> Comments{ get; set; }
    }
}
