using MVC_CRud.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_CRud.DataConnection
{
    public class DB_context:DbContext
    {
        public DbSet<Employeee> Employee_table { get; set; }

        public System.Data.Entity.DbSet<MVC_CRud.Models.StudentDetails> StudentDetails { get; set; }
    }
}