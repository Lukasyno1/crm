using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace crm.Models
{
    public class Organisation
    {
        public int id { get; set; }

        public int type { get; set; }

        public string name { get; set; }

        public DateTime created_at { get; set; }

        public DateTime updated_at { get; set; }

        [DefaultValue(false)]
        public bool ghosted { get; set; }
    }
}