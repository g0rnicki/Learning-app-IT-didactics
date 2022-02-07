﻿// <auto-generated />
using System;
using EzLearning.Server.Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EzLearning.Server.Dal.Migrations
{
    [DbContext(typeof(AppDataContext))]
    [Migration("20220207192729_SeedMoreChaptersData")]
    partial class SeedMoreChaptersData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.12");

            modelBuilder.Entity("EzLearning.Server.Dal.Models.Chapter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("chapters");
                });

            modelBuilder.Entity("EzLearning.Server.Dal.Models.ChapterTest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ChapterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ChapterId");

                    b.ToTable("tests");
                });

            modelBuilder.Entity("EzLearning.Server.Dal.Models.Lesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ChapterId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("longtext");

                    b.Property<int>("LessonNumber")
                        .HasColumnType("int");

                    b.Property<int>("Part")
                        .HasColumnType("int");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ChapterId");

                    b.HasIndex("QuestionId");

                    b.ToTable("lessons");
                });

            modelBuilder.Entity("EzLearning.Server.Dal.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("ChapterTestId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("longtext");

                    b.Property<int>("CorrectAnswerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ChapterTestId");

                    b.HasIndex("CorrectAnswerId")
                        .IsUnique();

                    b.ToTable("questions");
                });

            modelBuilder.Entity("EzLearning.Server.Dal.Models.QuestionAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Answer")
                        .HasColumnType("longtext");

                    b.Property<int?>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("answers");
                });

            modelBuilder.Entity("EzLearning.Server.Dal.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedTimestamp")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedTimestamp")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Username")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("EzLearning.Server.Dal.Models.ChapterTest", b =>
                {
                    b.HasOne("EzLearning.Server.Dal.Models.Chapter", "Chapter")
                        .WithMany()
                        .HasForeignKey("ChapterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chapter");
                });

            modelBuilder.Entity("EzLearning.Server.Dal.Models.Lesson", b =>
                {
                    b.HasOne("EzLearning.Server.Dal.Models.Chapter", "Chapter")
                        .WithMany("Lessons")
                        .HasForeignKey("ChapterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EzLearning.Server.Dal.Models.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chapter");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("EzLearning.Server.Dal.Models.Question", b =>
                {
                    b.HasOne("EzLearning.Server.Dal.Models.ChapterTest", null)
                        .WithMany("TestQuestions")
                        .HasForeignKey("ChapterTestId");

                    b.HasOne("EzLearning.Server.Dal.Models.QuestionAnswer", "CorrectAnswer")
                        .WithOne("Question")
                        .HasForeignKey("EzLearning.Server.Dal.Models.Question", "CorrectAnswerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CorrectAnswer");
                });

            modelBuilder.Entity("EzLearning.Server.Dal.Models.QuestionAnswer", b =>
                {
                    b.HasOne("EzLearning.Server.Dal.Models.Question", null)
                        .WithMany("WrongAnswers")
                        .HasForeignKey("QuestionId");
                });

            modelBuilder.Entity("EzLearning.Server.Dal.Models.Chapter", b =>
                {
                    b.Navigation("Lessons");
                });

            modelBuilder.Entity("EzLearning.Server.Dal.Models.ChapterTest", b =>
                {
                    b.Navigation("TestQuestions");
                });

            modelBuilder.Entity("EzLearning.Server.Dal.Models.Question", b =>
                {
                    b.Navigation("WrongAnswers");
                });

            modelBuilder.Entity("EzLearning.Server.Dal.Models.QuestionAnswer", b =>
                {
                    b.Navigation("Question");
                });
#pragma warning restore 612, 618
        }
    }
}
