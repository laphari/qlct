using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Inforcauthu.Models
{
    public class InforcauthuContext :DbContext
    {
        public InforcauthuContext() : base("name=Inforcauthu") { }
        public virtual DbSet<Thongtincauthu> Thongtincauthus { get; set;}
        public virtual DbSet<doibong> Doibongs { get;set; }

    }
}