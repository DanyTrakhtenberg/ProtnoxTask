﻿// <auto-generated />
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(ProtnoxDbContext))]
    [Migration("20200811172659_CreateInitialDB")]
    partial class CreateInitialDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Models.NetworkEvent", b =>
                {
                    b.Property<string>("Device_Mac")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Event_id")
                        .HasColumnType("int");

                    b.Property<int>("Port_id")
                        .HasColumnType("int");

                    b.Property<string>("Switch_Ip")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("NetworkEvents");
                });
#pragma warning restore 612, 618
        }
    }
}
