using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace crm.Models.Organisation
{
    public class OrganisationModel
    {        
        public int id { get; set; }

        public int type { get; set; }

        public string name { get; set; }

        [DefaultValue("getutcdate()")]
        public DateTime created_at { get; set; }

        [DefaultValue("getutcdate()")]
        public DateTime updated_at { get; set; }

        [DefaultValue(false)]
        public bool ghosted { get; set; }
    }
}