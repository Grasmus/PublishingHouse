﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PublishingHouse.DataAccessLayer;

#nullable disable

namespace PublishingHouse.Migrations
{
    [DbContext(typeof(PublishingHouseContext))]
    [Migration("20230611123914_AddSeed")]
    partial class AddSeed
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OrderPrintedEdition", b =>
                {
                    b.Property<int>("OrdersId")
                        .HasColumnType("int");

                    b.Property<int>("PrintedEditionsId")
                        .HasColumnType("int");

                    b.HasKey("OrdersId", "PrintedEditionsId");

                    b.HasIndex("PrintedEditionsId");

                    b.ToTable("OrderPrintedEdition");
                });

            modelBuilder.Entity("PublishingHouse.Models.CategoryEntity.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Books"
                        });
                });

            modelBuilder.Entity("PublishingHouse.Models.OrderEntity.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("money");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("PublishingHouse.Models.PrintedEditionEntity.PrintedEdition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Cover")
                        .HasColumnType("image");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool?>("IsAvailable")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("PrintedEdition");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Isaac Asimov",
                            CategoryId = 1,
                            Cover = new byte[] { 1 },
                            Description = "Isaac Asimov's I, Robot launches readers on an adventure into a not-so-distant future where man and machine , struggle to redefinelife, love, and consciousness—and where the stakes are nothing less than survival. Filled with unforgettable characters, mind-bending speculation, and nonstop action, I, Robot is a powerful reading experience from one of the master storytellers of our time.\nI, ROBOT\nThey mustn't harm a human being, they must obey human orders, and they must protect their own existence...but only so long as that doesn't violate rules one and two. With these Three Laws of Robotics, humanity embarked on perhaps its greatest adventure: the invention of the first positronic man. It was a bold new era of evolution that would open up enormous possibilities—and unforeseen risks. For the scientists who invented the earliest robots weren't content that their creations should ' remain programmed helpers, companions, and semisentient worker-machines. And soon the robots themselves; aware of their own intelligence, power, and humanity, aren't either.\nAs humans and robots struggle to survive together—and sometimes against each other—on earth and in space, the future of both hangs in the balance. Human men and women confront robots gone mad, telepathic robots, robot politicians, and vast robotic intelligences that may already secretly control the world. And both are asking the same questions: What is human? And is humanity obsolete?\nIn l, Robot Isaac Asimov changes forever our perception of robots, and human beings and updates the timeless myth of man's dream to play god. with all its rewards—and terrors.\n",
                            Genre = "Science Fiction & Fantasy",
                            IsAvailable = true,
                            Language = "English",
                            Price = 10m,
                            ReleaseDate = new DateTime(2023, 6, 11, 15, 39, 13, 658, DateTimeKind.Local).AddTicks(7071),
                            Title = "I, Robot",
                            Updated = new DateTime(2023, 6, 11, 15, 39, 13, 658, DateTimeKind.Local).AddTicks(7112)
                        },
                        new
                        {
                            Id = 2,
                            Author = "Stephen King",
                            CategoryId = 1,
                            Cover = new byte[] { 1 },
                            Description = "It's a hot, lazy day, perfect for a cookout, until you see those strange dark clouds. Suddenly a violent storm sweeps across the lake and ends as abruptly and unexpectedly as it had begun. Then comes the mist...creeping slowly, inexorably into town, where it settles and waits, trapping you in the supermarket with dozens of others, cut off from your families and the world. The mist is alive, seething with unearthly sounds and movements. What unleashed this terror? Was it the Arrowhead Project---the top secret government operation that everyone has noticed but no one quite understands? And what happens when the provisions have run out and you're forced to make your escape, edging blindly through the dim light?",
                            Genre = "Horror",
                            IsAvailable = true,
                            Language = "English",
                            Price = 10m,
                            ReleaseDate = new DateTime(2023, 6, 11, 15, 39, 13, 658, DateTimeKind.Local).AddTicks(7120),
                            Title = "The Mist",
                            Updated = new DateTime(2023, 6, 11, 15, 39, 13, 658, DateTimeKind.Local).AddTicks(7122)
                        },
                        new
                        {
                            Id = 3,
                            Author = "Semuel Delany",
                            CategoryId = 1,
                            Cover = new byte[] { 1 },
                            Description = "Babel-17 is all about the power of language. Humanity, which has spread throughout the universe, is involved in a war with the Invaders, who have been covertly assassinating officials and sabotaging spaceships. The only clues humanity has to go on are strange alien messages that have been intercepted in space. Poet and linguist Rydra Wong is determined to understand the language and stop the alien threat.",
                            Genre = "Science Fiction & Fantasy",
                            IsAvailable = true,
                            Language = "English",
                            Price = 9m,
                            ReleaseDate = new DateTime(2023, 6, 11, 15, 39, 13, 658, DateTimeKind.Local).AddTicks(7125),
                            Title = "Babel-17",
                            Updated = new DateTime(2023, 6, 11, 15, 39, 13, 658, DateTimeKind.Local).AddTicks(7127)
                        });
                });

            modelBuilder.Entity("PublishingHouse.Models.UserEntity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(800)
                        .HasColumnType("nvarchar(800)");

                    b.Property<bool>("IsBlacklisted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(800)
                        .HasColumnType("nvarchar(800)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2023, 6, 11, 15, 39, 13, 822, DateTimeKind.Local).AddTicks(1017),
                            FirstName = "Admin",
                            IsBlacklisted = false,
                            LastName = "Admin",
                            Login = "admin",
                            PasswordHash = "$2a$11$sCaP0BlY/WkRH/bkIprxa.L9I7wl52fUy81UwB//AjDQFoYA/0H8O",
                            Role = "Administrator"
                        });
                });

            modelBuilder.Entity("OrderPrintedEdition", b =>
                {
                    b.HasOne("PublishingHouse.Models.OrderEntity.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PublishingHouse.Models.PrintedEditionEntity.PrintedEdition", null)
                        .WithMany()
                        .HasForeignKey("PrintedEditionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PublishingHouse.Models.OrderEntity.Order", b =>
                {
                    b.HasOne("PublishingHouse.Models.UserEntity.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PublishingHouse.Models.PrintedEditionEntity.PrintedEdition", b =>
                {
                    b.HasOne("PublishingHouse.Models.CategoryEntity.Category", "Category")
                        .WithMany("PrintedEditions")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("PublishingHouse.Models.CategoryEntity.Category", b =>
                {
                    b.Navigation("PrintedEditions");
                });

            modelBuilder.Entity("PublishingHouse.Models.UserEntity.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
