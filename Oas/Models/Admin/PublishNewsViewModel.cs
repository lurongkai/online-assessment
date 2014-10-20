using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Oas.Models.Admin
{
    public class PublishNewsViewModel
    {
        [Required]
        [DisplayName("标题")]
        public string Title { get; set; }
        [Required]
        [DisplayName("内容")]
        public string Content { get; set; }
    }
}