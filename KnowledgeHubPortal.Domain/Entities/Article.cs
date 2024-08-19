using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KnowledgeHubPortal.Domain.Entities
{
    public class Article
    {
        [Key]
        public int ArticleId { get; set; }
        [Required]
        [MinLength(3,ErrorMessage ="Th minimum length of the title should be more than 3")]
        [MaxLength(100,ErrorMessage ="Not more than 100")]
        public string Title { get; set; }

        [Url]
        public string ArticleUrl { get; set; }

        [MinLength(10)]
        [MaxLength(50)]
        public string Description { get; set; }

        [ForeignKey("Category")]
        public int CateoryId { get; set; }
        public Category? Category { get; set; }
       
        public bool IsApproved { get; set; }

       // [Required] 
        public string? SubmittedBy { get; set; }
        public DateTime DateSubmitted { get; set; }
       

    }


   
}
