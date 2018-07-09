using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BookeeShop.Models
{
    [Table("Comments")]
    public class CommentsModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentID { get; set; }
        [Required]
        [StringLength(maximumLength:100)]
        public string CommentTitle { get; set; }
        [Required]
        [StringLength(maximumLength: 500)]
        public string CommentContent { get; set; }
        public virtual CustomerModel Customer { get; set; }
    }
}