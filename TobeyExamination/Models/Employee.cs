using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TobeyExamination.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EnName { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateTime { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}