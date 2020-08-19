using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace crm.Models
{
    public class CrmDbContext : DbContext
    {
        public CrmDbContext()
           : base("name=CrmDbContext")
        {          
        }
        public DbSet<Organisation> Organisations { get; set; }
    }
}