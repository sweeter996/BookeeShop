using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BookeeShop.Models
{
    [Table("BookInformation")]
    public class BookInformationModel
    {
        [Key]
        public string BookID { get; set; }
        public string BookName { get; set; }
        public string BookIntroduction { get; set; }
        public string BookPrice { get; set; }
        public string BookCoverImage { get; set; }
        public string Bookauthor { get; set; }
        public string BookPublisher { get; set; }
        public string YearReleased { get; set; }
        public string BookForm { get; set; }
        public string BookLanguage { get; set; }
        public DateTime BookAddedDate { get; set; }
        public DateTime BookModifiedDate { get; set; }
        public virtual BookCategoriesModel CategoryID { get; set; }
    }
}