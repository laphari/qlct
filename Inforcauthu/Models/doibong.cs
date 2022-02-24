using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inforcauthu.Models
{
    [Table("Doibong")]
    public class doibong
    {
        [Key]
        public int IDclub { get; set; }
        public string Nameclub { get; set;}
        public string Namthanhlap{get; set;}
        public string Chutichclb { get; set;}
        public string fan { get; set;}
        public string chitietclb { get; set;}
        public string logo { get; set;}
        public virtual ICollection<Thongtincauthu> Listct { get; set;}
    }
}