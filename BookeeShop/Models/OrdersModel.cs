using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BookeeShop.Models
{
    [Table("Orders")]
    public class OrdersModel
    {
        [Key]
        public string OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }
        public double TotalPrice { get; set; }
        public virtual CustomerModel CustomerID { get; set; }
        public ICollection<BookInformationModel> ListBook{ get; set; }
    }
}