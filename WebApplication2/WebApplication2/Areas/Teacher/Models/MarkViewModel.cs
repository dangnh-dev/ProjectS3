using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace WebApplication2.Areas.Teacher.Models
{
    public class MarkViewModel
    {
        public int? MarkId { get; set; }
        public string Image { get; set; }
        public int SubmissionId { get; set; }
        public string Description { get; set; }
        public string Comment { get; set; }
        public int? Mark { get; set; }
        public string StudentName { get; set; }

    }
}