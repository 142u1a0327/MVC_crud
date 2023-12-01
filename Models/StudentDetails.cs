using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_CRud.Models
{
    public class StudentDetails
    {
        [Key]
        public int ID { get; set; }
        public string Studentname { get; set; }
        public string Fathername { get; set; }
        public string Mothername { get; set; }
    }
}