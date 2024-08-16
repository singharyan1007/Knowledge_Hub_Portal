using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace KnowledgeHubPortal.Domain.Entities
{
    public class Category
    {
        [Key]
        public int CateoryId { get; set; }
        [Required(ErrorMessage ="Please enter a category")]
        [MinLength(3,ErrorMessage ="Minimum Length should be 3")]
        [MaxLength(100,ErrorMessage ="Maximum length should not exceed 100")]

        public string CategoryName { get; set; }
        [StringLength(500, ErrorMessage ="Length should not exceed 500")]
        [Required(ErrorMessage ="Please enter a description")]

        public string CategoryDescription { get; set; }

        public List<Article>? Articles { get; set; }
    }
}
