﻿// <auto-generated />
using System;
using Get_Help.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Get_Help.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240420120817_UpdatedAgentAndClientModels")]
    partial class UpdatedAgentAndClientModels
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Get_Help.Infrastructure.Data.Models.ApplicationRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Get_Help.Infrastructure.Data.Models.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("nvarchar(21)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("ApplicationUser");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Get_Help.Infrastructure.Data.Models.DeleteType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Delete Type Identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasComment("Delete Type Name");

                    b.HasKey("Id");

                    b.ToTable("DeleteTypes", t =>
                        {
                            t.HasComment("Delete Type");
                        });
                });

            modelBuilder.Entity("Get_Help.Infrastructure.Data.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Message Identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AgentId")
                        .HasColumnType("int")
                        .HasComment("Agent Identifier");

                    b.Property<int>("ClientId")
                        .HasColumnType("int")
                        .HasComment("Client Identifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(600)
                        .HasColumnType("nvarchar(600)")
                        .HasComment("Message Content");

                    b.Property<int?>("DeleteTypeId")
                        .HasColumnType("int")
                        .HasComment("Delete Type Identifier");

                    b.Property<DateTime>("SentTime")
                        .HasColumnType("datetime2")
                        .HasComment("Time of sending the message");

                    b.Property<int>("TicketId")
                        .HasColumnType("int")
                        .HasComment("Ticket Identifier");

                    b.HasKey("Id");

                    b.HasIndex("AgentId");

                    b.HasIndex("ClientId");

                    b.HasIndex("DeleteTypeId");

                    b.HasIndex("TicketId");

                    b.ToTable("Messages", t =>
                        {
                            t.HasComment("Ticket Message");
                        });
                });

            modelBuilder.Entity("Get_Help.Infrastructure.Data.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Service Identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("DeleteTypeId")
                        .HasColumnType("int")
                        .HasComment("Delete Type Identifier");

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Service title Image Url");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Service Name");

                    b.HasKey("Id");

                    b.HasIndex("DeleteTypeId");

                    b.ToTable("Services", t =>
                        {
                            t.HasComment("Service");
                        });
                });

            modelBuilder.Entity("Get_Help.Infrastructure.Data.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Ticket Identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AgentId")
                        .HasColumnType("int")
                        .HasComment("Agent Identifier");

                    b.Property<int>("ClientId")
                        .HasColumnType("int")
                        .HasComment("Client Identifier");

                    b.Property<int?>("DeleteTypeId")
                        .HasColumnType("int")
                        .HasComment("Delete Type Identifier");

                    b.Property<DateTime?>("TimeClosed")
                        .HasColumnType("datetime2")
                        .HasComment("Time of closing the Ticket");

                    b.Property<DateTime>("TimeOpened")
                        .HasColumnType("datetime2")
                        .HasComment("Time of opening the Ticket");

                    b.Property<int>("TopicId")
                        .HasColumnType("int")
                        .HasComment("Topic Identifier");

                    b.HasKey("Id");

                    b.HasIndex("AgentId");

                    b.HasIndex("ClientId");

                    b.HasIndex("DeleteTypeId");

                    b.HasIndex("TopicId");

                    b.ToTable("Ticket", t =>
                        {
                            t.HasComment("Ticket");
                        });
                });

            modelBuilder.Entity("Get_Help.Infrastructure.Data.Models.Topic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Topic Identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("DeleteTypeId")
                        .HasColumnType("int")
                        .HasComment("Delete Type Identifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasComment("Topic Title");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int")
                        .HasComment("Service Identifier");

                    b.HasKey("Id");

                    b.HasIndex("DeleteTypeId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Topics", t =>
                        {
                            t.HasComment("Service Topic");
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Get_Help.Infrastructure.Data.Models.Agent", b =>
                {
                    b.HasBaseType("Get_Help.Infrastructure.Data.Models.ApplicationUser");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Agent Name");

                    b.HasDiscriminator().HasValue("Agent");
                });

            modelBuilder.Entity("Get_Help.Infrastructure.Data.Models.Client", b =>
                {
                    b.HasBaseType("Get_Help.Infrastructure.Data.Models.ApplicationUser");

                    b.HasDiscriminator().HasValue("Client");
                });

            modelBuilder.Entity("Get_Help.Infrastructure.Data.Models.Message", b =>
                {
                    b.HasOne("Get_Help.Infrastructure.Data.Models.Agent", "Agent")
                        .WithMany("Messages")
                        .HasForeignKey("AgentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Get_Help.Infrastructure.Data.Models.Client", "Client")
                        .WithMany("Messages")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Get_Help.Infrastructure.Data.Models.DeleteType", "DeleteType")
                        .WithMany()
                        .HasForeignKey("DeleteTypeId");

                    b.HasOne("Get_Help.Infrastructure.Data.Models.Ticket", "Ticket")
                        .WithMany("Messages")
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Agent");

                    b.Navigation("Client");

                    b.Navigation("DeleteType");

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("Get_Help.Infrastructure.Data.Models.Service", b =>
                {
                    b.HasOne("Get_Help.Infrastructure.Data.Models.DeleteType", "DeleteType")
                        .WithMany()
                        .HasForeignKey("DeleteTypeId");

                    b.Navigation("DeleteType");
                });

            modelBuilder.Entity("Get_Help.Infrastructure.Data.Models.Ticket", b =>
                {
                    b.HasOne("Get_Help.Infrastructure.Data.Models.Agent", "Agent")
                        .WithMany("Tickets")
                        .HasForeignKey("AgentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Get_Help.Infrastructure.Data.Models.Client", "Client")
                        .WithMany("Tickets")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Get_Help.Infrastructure.Data.Models.DeleteType", "DeleteType")
                        .WithMany()
                        .HasForeignKey("DeleteTypeId");

                    b.HasOne("Get_Help.Infrastructure.Data.Models.Topic", "Topic")
                        .WithMany("Tickets")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Agent");

                    b.Navigation("Client");

                    b.Navigation("DeleteType");

                    b.Navigation("Topic");
                });

            modelBuilder.Entity("Get_Help.Infrastructure.Data.Models.Topic", b =>
                {
                    b.HasOne("Get_Help.Infrastructure.Data.Models.DeleteType", "DeleteType")
                        .WithMany()
                        .HasForeignKey("DeleteTypeId");

                    b.HasOne("Get_Help.Infrastructure.Data.Models.Service", "Service")
                        .WithMany("Topics")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("DeleteType");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Get_Help.Infrastructure.Data.Models.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Get_Help.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Get_Help.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Get_Help.Infrastructure.Data.Models.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Get_Help.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("Get_Help.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Get_Help.Infrastructure.Data.Models.Service", b =>
                {
                    b.Navigation("Topics");
                });

            modelBuilder.Entity("Get_Help.Infrastructure.Data.Models.Ticket", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("Get_Help.Infrastructure.Data.Models.Topic", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("Get_Help.Infrastructure.Data.Models.Agent", b =>
                {
                    b.Navigation("Messages");

                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("Get_Help.Infrastructure.Data.Models.Client", b =>
                {
                    b.Navigation("Messages");

                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
