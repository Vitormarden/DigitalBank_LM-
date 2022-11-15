﻿// <auto-generated />
using DigitalBank_LM.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DigitalBank_LM.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.30")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DigitalBank_LM.Models.Cliente", b =>
                {
                    b.Property<int>("Id_Client")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClientNo")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(11)")
                        .HasMaxLength(11);

                    b.Property<int>("Idade")
                        .HasColumnType("int");

                    b.HasKey("Id_Client");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("DigitalBank_LM.Models.ContaBancaria", b =>
                {
                    b.Property<int>("Number_Account")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Id_Client")
                        .HasColumnType("int");

                    b.Property<int>("Saldo")
                        .HasColumnType("int");

                    b.HasKey("Number_Account");

                    b.HasIndex("Id_Client");

                    b.ToTable("ContaBancaria");
                });

            modelBuilder.Entity("DigitalBank_LM.Models.Transacao", b =>
                {
                    b.Property<int>("Id_Transaction")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Date_Transaction")
                        .HasColumnType("int");

                    b.Property<int>("Number_Account")
                        .HasColumnType("int");

                    b.Property<string>("Type_Transaction")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<int>("Value_Transaction")
                        .HasColumnType("int");

                    b.HasKey("Id_Transaction");

                    b.HasIndex("Number_Account");

                    b.ToTable("Transacao");
                });

            modelBuilder.Entity("DigitalBank_LM.Models.ContaBancaria", b =>
                {
                    b.HasOne("DigitalBank_LM.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("Id_Client")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DigitalBank_LM.Models.Transacao", b =>
                {
                    b.HasOne("DigitalBank_LM.Models.ContaBancaria", "ContaBancaria")
                        .WithMany()
                        .HasForeignKey("Number_Account")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}