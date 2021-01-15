﻿// <auto-generated />
using System;
using EnhanceInterview.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EnhanceInterview.DAL.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20200421100056_InterviewStatus")]
    partial class InterviewStatus
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EnhanceInterview.DAL.Models.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("InterviewId");

                    b.Property<int?>("VacancyQuestionId");

                    b.HasKey("Id");

                    b.HasIndex("InterviewId");

                    b.HasIndex("VacancyQuestionId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("EnhanceInterview.DAL.Models.Applicant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Applicants");
                });

            modelBuilder.Entity("EnhanceInterview.DAL.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("EnhanceInterview.DAL.Models.Feedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("InterviewId");

                    b.Property<int>("InterviewerId");

                    b.HasKey("Id");

                    b.HasIndex("InterviewId");

                    b.ToTable("Feedback");
                });

            modelBuilder.Entity("EnhanceInterview.DAL.Models.Interview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ApplicantId");

                    b.Property<string>("Status");

                    b.Property<int>("VacancyId");

                    b.HasKey("Id");

                    b.HasIndex("ApplicantId");

                    b.HasIndex("VacancyId");

                    b.ToTable("Interviews");
                });

            modelBuilder.Entity("EnhanceInterview.DAL.Models.Interviewer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("WorkerId");

                    b.HasKey("Id");

                    b.HasIndex("WorkerId");

                    b.ToTable("Interviewers");
                });

            modelBuilder.Entity("EnhanceInterview.DAL.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("EnhanceInterview.DAL.Models.Recruiter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("WorkerId");

                    b.HasKey("Id");

                    b.HasIndex("WorkerId");

                    b.ToTable("Recruiters");
                });

            modelBuilder.Entity("EnhanceInterview.DAL.Models.User", b =>
                {
                    b.Property<string>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Login");

                    b.Property<string>("Password");

                    b.Property<string>("Role");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EnhanceInterview.DAL.Models.Vacancy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("Info");

                    b.Property<string>("Location");

                    b.Property<int?>("RecruiterId");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("RecruiterId");

                    b.ToTable("Vacancies");
                });

            modelBuilder.Entity("EnhanceInterview.DAL.Models.VacancyQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("QuestionId");

                    b.Property<int>("VacancyId");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.HasIndex("VacancyId");

                    b.ToTable("VacancyQuestions");
                });

            modelBuilder.Entity("EnhanceInterview.DAL.Models.Worker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("UserId");

                    b.ToTable("Workers");
                });

            modelBuilder.Entity("EnhanceInterview.DAL.Models.Answer", b =>
                {
                    b.HasOne("EnhanceInterview.DAL.Models.Interview", "Interview")
                        .WithMany("Answers")
                        .HasForeignKey("InterviewId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EnhanceInterview.DAL.Models.VacancyQuestion", "VacancyQuestion")
                        .WithMany("Answers")
                        .HasForeignKey("VacancyQuestionId");
                });

            modelBuilder.Entity("EnhanceInterview.DAL.Models.Applicant", b =>
                {
                    b.HasOne("EnhanceInterview.DAL.Models.User", "User")
                        .WithMany("Applicants")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("EnhanceInterview.DAL.Models.Feedback", b =>
                {
                    b.HasOne("EnhanceInterview.DAL.Models.Interview", "Interview")
                        .WithMany("Feedbacks")
                        .HasForeignKey("InterviewId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EnhanceInterview.DAL.Models.Interviewer", "Interviewer")
                        .WithMany("Feedbacks")
                        .HasForeignKey("InterviewId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EnhanceInterview.DAL.Models.Interview", b =>
                {
                    b.HasOne("EnhanceInterview.DAL.Models.Applicant", "Applicant")
                        .WithMany("Interviews")
                        .HasForeignKey("ApplicantId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EnhanceInterview.DAL.Models.Vacancy", "Vacancy")
                        .WithMany("Interviews")
                        .HasForeignKey("VacancyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EnhanceInterview.DAL.Models.Interviewer", b =>
                {
                    b.HasOne("EnhanceInterview.DAL.Models.Worker", "Worker")
                        .WithMany("Interviewers")
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EnhanceInterview.DAL.Models.Recruiter", b =>
                {
                    b.HasOne("EnhanceInterview.DAL.Models.Worker", "Worker")
                        .WithMany("Recruiters")
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EnhanceInterview.DAL.Models.Vacancy", b =>
                {
                    b.HasOne("EnhanceInterview.DAL.Models.Recruiter", "Recruiter")
                        .WithMany("Vacancies")
                        .HasForeignKey("RecruiterId");
                });

            modelBuilder.Entity("EnhanceInterview.DAL.Models.VacancyQuestion", b =>
                {
                    b.HasOne("EnhanceInterview.DAL.Models.Question", "Question")
                        .WithMany("VacancyQuestions")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EnhanceInterview.DAL.Models.Vacancy", "Vacancy")
                        .WithMany("VacancyQuestions")
                        .HasForeignKey("VacancyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EnhanceInterview.DAL.Models.Worker", b =>
                {
                    b.HasOne("EnhanceInterview.DAL.Models.Company", "Company")
                        .WithMany("Workers")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EnhanceInterview.DAL.Models.User", "User")
                        .WithMany("Workers")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}