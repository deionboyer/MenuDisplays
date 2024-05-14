using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MenuItems.Database.EF.Models;



namespace MenuItems.Database.EF.Context
{
    public class MenuItemsContext : DbContext
    {
        public MenuItemsContext()
        {

        }
        public MenuItemsContext(DbContextOptions<MenuItemsContext> options) : base(options)
        {

        }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<MenuTypes> MenuTypes { get; set; }
       
    }
}
