using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InternProject.Models
{
    public class tblSkill
    {
        [Key]
        public int SkillID { get; set; }

        [Display(Name = "Type of Skill")]
        public string Title { get; set; }
    }
}
