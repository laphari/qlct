using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inforcauthu.Models
{
    [Table("Inforcauthu")]
    public class Thongtincauthu
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Age { get; set; }
        public string Country { get; set;}
        public string infor { get; set;}
        public string inforcaothap { get; set; }
        public string Salary { get; set; }
        public string Value { get; set; }
        public string Image { get; set; }
        public int IDdoibongcauthu { get; set; }
        [ForeignKey("IDdoibongcauthu")]
        public virtual doibong Doibong { get; set;}
    }
}