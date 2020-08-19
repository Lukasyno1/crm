using crm.Models.Organisation;
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
        public DbSet<OrganisationModel> Organisations { get; set; }
    }
}