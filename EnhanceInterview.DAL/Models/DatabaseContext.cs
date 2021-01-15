using EnhanceInterview.DAL.Configurations;
using Microsoft.EntityFrameworkCore;

namespace EnhanceInterview.DAL.Models
{
	public class DatabaseContext : DbContext
	{
		public DatabaseContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Company> Companies { get; set; }
		public DbSet<Vacancy> Vacancies { get; set; }
		public DbSet<Answer> Answers { get; set; }
		public DbSet<Interview> Interviews { get; set; }

		public DbSet<Feedback> Feedbacks { get; set; }
		public DbSet<Question> Questions { get; set; }
		public DbSet<VacancyQuestion> VacancyQuestions { get; set; }
		public DbSet<Worker> Workers { get; set; }
		public DbSet<Interviewer> Interviewers { get; set; }
		public DbSet<Applicant> Applicants { get; set; }
		public DbSet<Recruiter> Recruiters { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfiguration(new CompanyConfiguration());
			builder.ApplyConfiguration(new VacancyConfiguration());
			builder.ApplyConfiguration(new AnswerConfiguration());
			builder.ApplyConfiguration(new InterviewConfiguration());
			builder.ApplyConfiguration(new FeedbackConfiguration());
			builder.ApplyConfiguration(new QuestionConfiguration());
			builder.ApplyConfiguration(new VacancyQuestionConfiguration());
			builder.ApplyConfiguration(new ApplicantConfiguration());
		}
	}
}