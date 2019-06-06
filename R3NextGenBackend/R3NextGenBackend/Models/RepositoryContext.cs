using BackendNextGen.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace R3NextGenBackend
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Form> Form { get; set; }
        public DbSet<CompletedForm> CompletedForm { get; set; }
        public DbSet<FormField> FormField { get; set; }
        public DbSet<Component> Component { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Create one to one relationship
            modelBuilder.Entity<FormField>()
                .HasOne(a => a.Component)
                .WithOne(b => b.FormField)
                .HasForeignKey<Component>(b => b.FormFieldId);

            //Seed data 
            modelBuilder.Entity<Form>().HasData(
                new Form { Id = 1, Name = "Brand" },
                new Form { Id = 2, Name = "Affaldssortering" },
                new Form { Id = 3, Name = "Biluheld" },
                new Form { Id = 4, Name = "Overfald" },
                new Form { Id = 5, Name = "Underet Borgmesterkontoret" },
                new Form { Id = 6, Name = "Kemikaliebrand" },
                new Form { Id = 7, Name = "Tilkald helikopter" }
                );

            modelBuilder.Entity<CompletedForm>().HasData(
                new CompletedForm { Id = 1, UserId = 1, CompletedDate = DateTime.Now.Date, FormId = 1 },
                new CompletedForm { Id = 2, UserId = 2, CompletedDate = DateTime.Now.Date, FormId = 2 },
                new CompletedForm { Id = 3, UserId = 3, CompletedDate = DateTime.Now.Date, FormId = 3 },
                new CompletedForm { Id = 4, UserId = 1, CompletedDate = DateTime.Now.Date, FormId = 4 },
                new CompletedForm { Id = 5, UserId = 2, CompletedDate = DateTime.Now.Date, FormId = 5 },
                new CompletedForm { Id = 6, UserId = 1, CompletedDate = DateTime.Now.Date, FormId = 6 },
                new CompletedForm { Id = 7, UserId = 1, CompletedDate = DateTime.Now.Date, FormId = 7 }
                );

            modelBuilder.Entity<FormField>().HasData(
               new FormField { Id = 1, Column = 3, Row = 3, Width = 3, Height = 3, Headline = "Indtast Dit Navn", Static = false, FormId = 1 },
               new FormField { Id = 2, Column = 2, Row = 3, Width = 2, Height = 3, Headline = "Er der en affaldsspand", Static = false, FormId = 2 },
               new FormField { Id = 3, Column = 3, Row = 3, Width = 3, Height = 4, Headline = "Antal kvæstede", Static = false, FormId = 3 },
               new FormField { Id = 4, Column = 3, Row = 3, Width = 3, Height = 5, Headline = "Overfaldsvåben", Static = false, FormId = 4 },
               new FormField { Id = 5, Column = 3, Row = 3, Width = 5, Height = 2, Headline = "Skal komunaldirektøren underrettes", Static = false, FormId = 5 },
               new FormField { Id = 6, Column = 3, Row = 3, Width = 5, Height = 5, Headline = "Hvilken type kemikalie er i brand?", Static = false, FormId = 6 },
               new FormField { Id = 7, Column = 3, Row = 3, Width = 3, Height = 2, Headline = "Hvor skal helikopteren lande?", Static = false, FormId = 7 }
               );

            modelBuilder.Entity<Component>().HasData(
               new Component { Id = 1, ComponentName = "appInputFieldComponent", FormFieldId = 1 },
               new Component { Id = 2, ComponentName = "appInputFieldComponent", FormFieldId = 2 },
               new Component { Id = 3, ComponentName = "appInputFieldComponent", FormFieldId = 3 },
               new Component { Id = 4, ComponentName = "appInputFieldComponent", FormFieldId = 4 },
               new Component { Id = 5, ComponentName = "appInputFieldComponent", FormFieldId = 5 },
               new Component { Id = 6, ComponentName = "appInputFieldComponent", FormFieldId = 6 },
               new Component { Id = 7, ComponentName = "appInputFieldComponent", FormFieldId = 7 }
               );

        }
    }
}
