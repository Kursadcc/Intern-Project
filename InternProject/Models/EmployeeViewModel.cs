using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InternProject.Models
{
    public class EmployeeViewModel
    {
        public List<tblEmployee> EmployeeList { get; set; }
        public tblSkill Skill { get; set; }
        public List<tblSkill> SkillList { get; set; }
    }
}
