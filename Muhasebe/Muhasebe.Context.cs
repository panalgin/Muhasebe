﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Muhasebe
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MuhasebeEntities : DbContext
    {
        public MuhasebeEntities()
            : base("name=MuhasebeEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<UnitType> UnitTypes { get; set; }
        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<DeviceType> DeviceTypes { get; set; }
        public virtual DbSet<InvoiceNode> InvoiceNodes { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<PaymentType> PaymentTypes { get; set; }
        public virtual DbSet<Income> Incomes { get; set; }
        public virtual DbSet<IncomeType> IncomeTypes { get; set; }
        public virtual DbSet<Expenditure> Expenditures { get; set; }
        public virtual DbSet<ExpenditureType> ExpenditureTypes { get; set; }
        public virtual DbSet<JobPosition> JobPositions { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventCategory> EventCategories { get; set; }
        public virtual DbSet<PropertyReminder> PropertyReminders { get; set; }
        public virtual DbSet<PropertyRemindingMethod> PropertyRemindingMethods { get; set; }
        public virtual DbSet<BarcodeTemplate> BarcodeTemplates { get; set; }
        public virtual DbSet<ConnectionType> ConnectionTypes { get; set; }
        public virtual DbSet<ItemGroup> ItemGroups { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<AccountType> AccountTypes { get; set; }
        public virtual DbSet<OrderNode> OrderNodes { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<AccountMovement> AccountMovements { get; set; }
        public virtual DbSet<AccountMovementType> AccountMovementTypes { get; set; }
        public virtual DbSet<StockMovementNode> StockMovementNodes { get; set; }
        public virtual DbSet<StockMovement> StockMovements { get; set; }
        public virtual DbSet<OfferNode> OfferNodes { get; set; }
        public virtual DbSet<Offer> Offers { get; set; }
    }
}
