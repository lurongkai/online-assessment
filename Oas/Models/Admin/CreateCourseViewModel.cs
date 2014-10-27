using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Oas.Models.Admin
{
    public class CreateCourseViewModel
    {
        [Required]
        [DisplayName("课程缩写")]
        public string CourseAbbr { get; set; }
        [Required]
        [DisplayName("课程名称")]
        public string CourseName { get; set; }
        [Required]
        [DisplayName("课程描述")]
        public string Description { get; set; }
    }
}