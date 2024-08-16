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
        [Required]
        [MinLength(3)]
        [MaxLength(100)]

        public string CategoryName { get; set; }
        [StringLength(500)]
        [Required]

        public string CategoryDescription { get; set; }
    }
}
