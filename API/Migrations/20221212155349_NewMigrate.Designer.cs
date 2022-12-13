// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tier3___Server;

#nullable disable

namespace Tier3.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221212155349_NewMigrate")]
    partial class NewMigrate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("Db3.Models.Client.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "email");

                    b.Property<bool>("IsSubToElectricity")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsSubToHeating")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsSubToRent")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsSubToWater")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ManagerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "password");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "username");

                    b.Property<string>("dob")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "dob");

                    b.Property<string>("phonenumber")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "phonenumber");

                    b.HasKey("Id");

                    b.HasIndex("ManagerId");

                    b.ToTable("Clients");

                    b.HasAnnotation("Relational:JsonPropertyName", "clients");
                });

            modelBuilder.Entity("Db3.Models.Manager.Manager", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "password");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "username");

                    b.HasKey("Id");

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("Tier3_Db.Models.Bill.Bill", b =>
                {
                    b.Property<int>("billid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasAnnotation("Relational:JsonPropertyName", "billid");

                    b.Property<double>("amount")
                        .HasColumnType("REAL")
                        .HasAnnotation("Relational:JsonPropertyName", "amount");

                    b.Property<int?>("billid1")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("billingdate")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "billingdate");

                    b.Property<int>("clientid")
                        .HasColumnType("INTEGER")
                        .HasAnnotation("Relational:JsonPropertyName", "clientid");

                    b.Property<DateTime>("duedate")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "duedate");

                    b.Property<bool>("paidstatus")
                        .HasColumnType("INTEGER")
                        .HasAnnotation("Relational:JsonPropertyName", "paidstatus");

                    b.Property<double>("priceperitem")
                        .HasColumnType("REAL")
                        .HasAnnotation("Relational:JsonPropertyName", "priceperitem");

                    b.Property<string>("provider")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "provider");

                    b.Property<double>("total")
                        .HasColumnType("REAL")
                        .HasAnnotation("Relational:JsonPropertyName", "total");

                    b.HasKey("billid");

                    b.HasIndex("billid1");

                    b.HasIndex("clientid");

                    b.ToTable("Bill");

                    b.HasAnnotation("Relational:JsonPropertyName", "bills");
                });

            modelBuilder.Entity("Db3.Models.Client.Client", b =>
                {
                    b.HasOne("Db3.Models.Manager.Manager", null)
                        .WithMany("clients")
                        .HasForeignKey("ManagerId");
                });

            modelBuilder.Entity("Tier3_Db.Models.Bill.Bill", b =>
                {
                    b.HasOne("Tier3_Db.Models.Bill.Bill", null)
                        .WithMany("viewbills")
                        .HasForeignKey("billid1");

                    b.HasOne("Db3.Models.Client.Client", null)
                        .WithMany("bills")
                        .HasForeignKey("clientid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Db3.Models.Client.Client", b =>
                {
                    b.Navigation("bills");
                });

            modelBuilder.Entity("Db3.Models.Manager.Manager", b =>
                {
                    b.Navigation("clients");
                });

            modelBuilder.Entity("Tier3_Db.Models.Bill.Bill", b =>
                {
                    b.Navigation("viewbills");
                });
#pragma warning restore 612, 618
        }
    }
}
