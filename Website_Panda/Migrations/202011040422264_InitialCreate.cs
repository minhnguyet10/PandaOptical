namespace Website_Panda.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Banners",
                c => new
                    {
                        IDBanner = c.Int(nullable: false, identity: true),
                        Image = c.String(maxLength: 250),
                        DisplayOrder = c.Int(),
                        Link = c.String(maxLength: 250),
                        Description = c.String(maxLength: 250),
                        CreatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.IDBanner);
            
            CreateTable(
                "dbo.BestSales",
                c => new
                    {
                        IDPro = c.Long(nullable: false, identity: true),
                        NamePro = c.String(maxLength: 250),
                        Image = c.String(maxLength: 250),
                        Price = c.Decimal(precision: 18, scale: 2),
                        Quantity = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.IDPro);
            
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        IDBill = c.Long(nullable: false, identity: true),
                        IDOrder = c.Long(nullable: false),
                        IdCus = c.Long(nullable: false),
                        CreateDay = c.DateTime(),
                        ShippingPrice = c.Decimal(precision: 18, scale: 2),
                        TotalPrice = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.IDBill)
                .ForeignKey("dbo.Customers", t => t.IdCus, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.IDOrder, cascadeDelete: true)
                .Index(t => t.IDOrder)
                .Index(t => t.IdCus);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        IdCus = c.Long(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false),
                        ConfirmPassword = c.String(nullable: false),
                        Email_Cus = c.String(maxLength: 100),
                        FirstName = c.String(maxLength: 10),
                        LastName = c.String(maxLength: 10),
                        Address_Cus = c.String(maxLength: 200),
                        Phone_Cus = c.String(maxLength: 15),
                        CreatedDay = c.DateTime(),
                        Score = c.Int(),
                    })
                .PrimaryKey(t => t.IdCus);
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        CartID = c.Int(nullable: false, identity: true),
                        IdCus = c.Long(nullable: false),
                        IDProduct = c.Long(nullable: false),
                        ProductName = c.String(),
                        Quantity = c.Int(),
                        CartTotalQuantity = c.Int(),
                        Price = c.Decimal(precision: 18, scale: 2),
                        CartTotalPrice = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.CartID)
                .ForeignKey("dbo.Customers", t => t.IdCus, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.IDProduct, cascadeDelete: true)
                .Index(t => t.IdCus)
                .Index(t => t.IDProduct);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        IDProduct = c.Long(nullable: false, identity: true),
                        ProductName = c.String(maxLength: 250),
                        Title = c.String(maxLength: 50),
                        Description = c.String(maxLength: 500),
                        Image = c.String(maxLength: 250),
                        MoreImage1 = c.String(),
                        MoreImage2 = c.String(),
                        Price = c.Decimal(precision: 18, scale: 2),
                        PromotionPrice = c.Decimal(precision: 18, scale: 2),
                        Quantity = c.Int(),
                        Color = c.String(),
                        CategoryID = c.Long(),
                        BrandID = c.Long(),
                        CreatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.IDProduct)
                .ForeignKey("dbo.Brands", t => t.BrandID)
                .ForeignKey("dbo.Categories", t => t.CategoryID)
                .Index(t => t.CategoryID)
                .Index(t => t.BrandID);
            
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        BrandID = c.Long(nullable: false, identity: true),
                        BrandName = c.String(maxLength: 250),
                        Note = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.BrandID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Long(nullable: false, identity: true),
                        CategoryName = c.String(maxLength: 250),
                        Note = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        IDOrderDetail = c.Long(nullable: false, identity: true),
                        IDOrder = c.Long(nullable: false),
                        IDProduct = c.Long(nullable: false),
                        Price = c.Decimal(precision: 18, scale: 2),
                        QuantitySale = c.Int(),
                        OrderTotalPrice = c.Decimal(precision: 18, scale: 2),
                        CreateDay = c.DateTime(),
                    })
                .PrimaryKey(t => t.IDOrderDetail)
                .ForeignKey("dbo.Orders", t => t.IDOrder, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.IDProduct, cascadeDelete: true)
                .Index(t => t.IDOrder)
                .Index(t => t.IDProduct);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        IDOrder = c.Long(nullable: false, identity: true),
                        OrderDate = c.DateTime(),
                        Descriptions = c.String(maxLength: 500),
                        IdCus = c.Long(),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.IDOrder)
                .ForeignKey("dbo.Customers", t => t.IdCus)
                .Index(t => t.IdCus);
            
            CreateTable(
                "dbo.Shippings",
                c => new
                    {
                        ShipID = c.Int(nullable: false, identity: true),
                        IDOrder = c.Long(nullable: false),
                        IDUser = c.Long(nullable: false),
                        ShippingDate = c.DateTime(),
                        Status = c.Boolean(),
                        Issue = c.String(),
                    })
                .PrimaryKey(t => t.ShipID)
                .ForeignKey("dbo.Orders", t => t.IDOrder, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.IDUser, cascadeDelete: true)
                .Index(t => t.IDOrder)
                .Index(t => t.IDUser);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        IDUser = c.Long(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        ConfirmPassword = c.String(nullable: false),
                        FirstName = c.String(maxLength: 10),
                        LastName = c.String(maxLength: 10),
                        Address = c.String(maxLength: 50),
                        Phone = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 50),
                        GroupID = c.String(maxLength: 20),
                        IdRole = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDUser)
                .ForeignKey("dbo.Roles", t => t.IdRole, cascadeDelete: true)
                .ForeignKey("dbo.UserGroups", t => t.GroupID)
                .Index(t => t.GroupID)
                .Index(t => t.IdRole);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        IDRole = c.Int(nullable: false, identity: true),
                        NameRole = c.String(maxLength: 50),
                        Note = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.IDRole);
            
            CreateTable(
                "dbo.UserGroups",
                c => new
                    {
                        GroupID = c.String(nullable: false, maxLength: 20),
                        GroupName = c.String(maxLength: 50),
                        Note = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.GroupID);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        IDContact = c.Long(nullable: false, identity: true),
                        ShopName = c.String(maxLength: 20),
                        ShopAddress = c.String(maxLength: 200),
                        ShopPhone = c.String(maxLength: 15),
                        ShopEmail = c.String(maxLength: 50),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.IDContact);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bills", "IDOrder", "dbo.Orders");
            DropForeignKey("dbo.Bills", "IdCus", "dbo.Customers");
            DropForeignKey("dbo.Carts", "IDProduct", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "IDProduct", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "IDOrder", "dbo.Orders");
            DropForeignKey("dbo.Shippings", "IDUser", "dbo.Users");
            DropForeignKey("dbo.Users", "GroupID", "dbo.UserGroups");
            DropForeignKey("dbo.Users", "IdRole", "dbo.Roles");
            DropForeignKey("dbo.Shippings", "IDOrder", "dbo.Orders");
            DropForeignKey("dbo.Orders", "IdCus", "dbo.Customers");
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Products", "BrandID", "dbo.Brands");
            DropForeignKey("dbo.Carts", "IdCus", "dbo.Customers");
            DropIndex("dbo.Users", new[] { "IdRole" });
            DropIndex("dbo.Users", new[] { "GroupID" });
            DropIndex("dbo.Shippings", new[] { "IDUser" });
            DropIndex("dbo.Shippings", new[] { "IDOrder" });
            DropIndex("dbo.Orders", new[] { "IdCus" });
            DropIndex("dbo.OrderDetails", new[] { "IDProduct" });
            DropIndex("dbo.OrderDetails", new[] { "IDOrder" });
            DropIndex("dbo.Products", new[] { "BrandID" });
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropIndex("dbo.Carts", new[] { "IDProduct" });
            DropIndex("dbo.Carts", new[] { "IdCus" });
            DropIndex("dbo.Bills", new[] { "IdCus" });
            DropIndex("dbo.Bills", new[] { "IDOrder" });
            DropTable("dbo.Contacts");
            DropTable("dbo.UserGroups");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.Shippings");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Categories");
            DropTable("dbo.Brands");
            DropTable("dbo.Products");
            DropTable("dbo.Carts");
            DropTable("dbo.Customers");
            DropTable("dbo.Bills");
            DropTable("dbo.BestSales");
            DropTable("dbo.Banners");
        }
    }
}
