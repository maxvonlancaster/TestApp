﻿// <auto-generated />
using System;
using Forum.DAL.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Forum.DAL.Migrations
{
    [DbContext(typeof(ForumsDbContext))]
    [Migration("20191213070210_initThree")]
    partial class initThree
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Forum.DAL.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SubForumId")
                        .HasColumnType("int");

                    b.HasKey("CategoryId");

                    b.HasIndex("SubForumId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Forum.DAL.Entities.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Media")
                        .HasColumnType("varbinary(max)");

                    b.Property<int?>("PostId")
                        .HasColumnType("int");

                    b.Property<int?>("PosterId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CommentId");

                    b.HasIndex("PostId");

                    b.HasIndex("PosterId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Forum.DAL.Entities.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Media")
                        .HasColumnType("varbinary(max)");

                    b.Property<int?>("PosterId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int?>("SubForumId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PostId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("PosterId");

                    b.HasIndex("SubForumId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Forum.DAL.Entities.SubForum", b =>
                {
                    b.Property<int>("SubForumId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Picture")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("SubForumId");

                    b.ToTable("SubForums");
                });

            modelBuilder.Entity("Forum.DAL.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<byte[]>("Picture")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IdentityUserClaims");
                });

            modelBuilder.Entity("Forum.DAL.Entities.Category", b =>
                {
                    b.HasOne("Forum.DAL.Entities.SubForum", "SubForum")
                        .WithMany()
                        .HasForeignKey("SubForumId");
                });

            modelBuilder.Entity("Forum.DAL.Entities.Comment", b =>
                {
                    b.HasOne("Forum.DAL.Entities.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostId");

                    b.HasOne("Forum.DAL.Entities.User", "Poster")
                        .WithMany()
                        .HasForeignKey("PosterId");
                });

            modelBuilder.Entity("Forum.DAL.Entities.Post", b =>
                {
                    b.HasOne("Forum.DAL.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("Forum.DAL.Entities.User", "Poster")
                        .WithMany()
                        .HasForeignKey("PosterId");

                    b.HasOne("Forum.DAL.Entities.SubForum", "SubForum")
                        .WithMany()
                        .HasForeignKey("SubForumId");
                });
#pragma warning restore 612, 618
        }
    }
}
