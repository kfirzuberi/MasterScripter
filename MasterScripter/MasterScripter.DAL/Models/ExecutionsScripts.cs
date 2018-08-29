using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterScripter.DAL.Models
{
    public class ExecutionsScripts
    {
        [Key, Column(Order = 0)]
        public int ScriptId { get; set; }
        [Key, Column(Order = 1)]
        public int ScriptVersion { get; set; }
        [Key, Column(Order = 2)]
        public int ExecutionId { get; set; }
        public int Order { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? SrartTime { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? EndTime { get; set; }
        public Status Status { get; set; }
        public virtual Script Script { get; set; }
        public virtual Execution Execution { get; set; }
    }
}
