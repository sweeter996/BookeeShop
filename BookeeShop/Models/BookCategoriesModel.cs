using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BookeeShop.Models
{
    [Table("BookCategories")]
    public class BookCategoriesModel
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        // public ICollection<BookInformationModel> ListBook { get; set; }
    }
}