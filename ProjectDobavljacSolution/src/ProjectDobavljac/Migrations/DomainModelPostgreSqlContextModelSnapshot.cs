using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ProjectDobavljac;

namespace ProjectDobavljac.Migrations
{
    [DbContext(typeof(DomainModelPostgreSqlContext))]
    partial class DomainModelPostgreSqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("ProjectDobavljac.Model.Dobavljac", b =>
                {
                    b.Property<int>("dobavljacId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("dobavljacAdresa");

                    b.Property<string>("dobavljacNaziv");

                    b.HasKey("dobavljacId");

                    b.ToTable("Dobavljac");
                });
        }
    }
}
