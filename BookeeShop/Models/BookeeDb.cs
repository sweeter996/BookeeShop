namespace BookeeShop.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BookeeDb : DbContext
    {
        // Your context has been configured to use a 'BookeeDb' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'BookeeShop.Models.BookeeDb' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'BookeeDb' 
        // connection string in the application configuration file.
        public BookeeDb()
            : base("name=BookeeDb")
        {
        }
        public virtual DbSet<BookCategoriesModel> BookCategories { get; set; }
        public virtual DbSet<BookInformationModel> BookInformation { get; set; }
        public virtual DbSet<CustomerModel> Customers { get; set; }
        public virtual DbSet<OrdersModel> Orders { get; set; }
    }
    // Add a DbSet for each entity type that you want to include in your model. For more information 
    // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

    // public virtual DbSet<MyEntity> MyEntities { get; set; }
}