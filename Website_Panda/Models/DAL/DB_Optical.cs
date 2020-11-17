using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Website_Panda.Models.DAL
{
    public class DB_Optical : DbContext
    {
        public DB_Optical() : base("name=DB_Optical")
        {

        }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<BestSale> BestSales { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Shipping> Shippings { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<Credential> Credentials { get; set; }

    }
}