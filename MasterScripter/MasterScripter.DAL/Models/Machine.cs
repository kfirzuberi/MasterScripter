using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterScripter.DAL.Models
{
    public class Machine
    {
        //public int Id { get; set; }
        
        [RegularExpression(Consts.IP_REGEX, ErrorMessage = "Invalid IP address"), MinLength(5), MaxLength(20)]
        [Key, Column(Order = 0)]
        public string IP { get; set; }
        [Key, Column(Order = 1)]
        public int VLan { get; set; }
        public bool IsDeleted { get; set; }
        public int CompanyCode { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? CreationDate { get; set; }
        public double Lon { get; set; }
        public double Lat { get; set; }
        public virtual ICollection<Execution> Executions { get; set; }
        public virtual Company Company { get; set; }
        
    }
}
