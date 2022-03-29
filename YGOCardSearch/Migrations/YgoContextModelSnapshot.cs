﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YGOCardSearch.DataLayer;

#nullable disable

namespace YGOCardSearch.Migrations
{
    [DbContext(typeof(YgoContext))]
    partial class YgoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("YGOCardSearch.Models.CardModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<long>("Atk")
                        .HasColumnType("bigint");

                    b.Property<string>("Attribute")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CardModelId")
                        .HasColumnType("int");

                    b.Property<int?>("DeckModelId")
                        .HasColumnType("int");

                    b.Property<int?>("DeckModelId1")
                        .HasColumnType("int");

                    b.Property<int?>("DeckModelId2")
                        .HasColumnType("int");

                    b.Property<long>("Def")
                        .HasColumnType("bigint");

                    b.Property<string>("Desc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Level")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Race")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CardModelId");

                    b.HasIndex("DeckModelId");

                    b.HasIndex("DeckModelId1");

                    b.HasIndex("DeckModelId2");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("YGOCardSearch.Models.DeckModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DeckName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Decks");
                });

            modelBuilder.Entity("YGOCardSearch.Models.ImageModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CardModelId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrlSmall")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CardModelId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("YGOCardSearch.Models.PriceModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AmazonPrice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CardModelId")
                        .HasColumnType("int");

                    b.Property<string>("CardmarketPrice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoolstuffincPrice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EbayPrice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TcgplayerPrice")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CardModelId");

                    b.ToTable("Prices");
                });

            modelBuilder.Entity("YGOCardSearch.Models.SetModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CardModelId")
                        .HasColumnType("int");

                    b.Property<string>("SetCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SetName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SetPrice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SetRarity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SetRarityCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CardModelId");

                    b.ToTable("Sets");
                });

            modelBuilder.Entity("YGOCardSearch.Models.CardModel", b =>
                {
                    b.HasOne("YGOCardSearch.Models.CardModel", null)
                        .WithMany("Data")
                        .HasForeignKey("CardModelId");

                    b.HasOne("YGOCardSearch.Models.DeckModel", null)
                        .WithMany("ExtraDeck")
                        .HasForeignKey("DeckModelId");

                    b.HasOne("YGOCardSearch.Models.DeckModel", null)
                        .WithMany("MainDeck")
                        .HasForeignKey("DeckModelId1");

                    b.HasOne("YGOCardSearch.Models.DeckModel", null)
                        .WithMany("SideDeck")
                        .HasForeignKey("DeckModelId2");
                });

            modelBuilder.Entity("YGOCardSearch.Models.ImageModel", b =>
                {
                    b.HasOne("YGOCardSearch.Models.CardModel", null)
                        .WithMany("CardImages")
                        .HasForeignKey("CardModelId");
                });

            modelBuilder.Entity("YGOCardSearch.Models.PriceModel", b =>
                {
                    b.HasOne("YGOCardSearch.Models.CardModel", null)
                        .WithMany("CardPrices")
                        .HasForeignKey("CardModelId");
                });

            modelBuilder.Entity("YGOCardSearch.Models.SetModel", b =>
                {
                    b.HasOne("YGOCardSearch.Models.CardModel", null)
                        .WithMany("CardSets")
                        .HasForeignKey("CardModelId");
                });

            modelBuilder.Entity("YGOCardSearch.Models.CardModel", b =>
                {
                    b.Navigation("CardImages");

                    b.Navigation("CardPrices");

                    b.Navigation("CardSets");

                    b.Navigation("Data");
                });

            modelBuilder.Entity("YGOCardSearch.Models.DeckModel", b =>
                {
                    b.Navigation("ExtraDeck");

                    b.Navigation("MainDeck");

                    b.Navigation("SideDeck");
                });
#pragma warning restore 612, 618
        }
    }
}
