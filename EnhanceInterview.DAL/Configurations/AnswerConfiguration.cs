using EnhanceInterview.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnhanceInterview.DAL.Configurations
{
	public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
	{
		public void Configure(EntityTypeBuilder<Answer> builder)
		{
			builder
				.HasKey(x => x.Id);

			builder
				.Property(x => x.Id)
				.ValueGeneratedOnAdd();

			builder
				.HasOne(x => x.Interview)
				.WithMany(x => x.Answers)
				.HasForeignKey(x => x.InterviewId);

			builder
				.HasOne(x => x.VacancyQuestion)
				.WithMany(x => x.Answers)
				.HasForeignKey(x => x.VacancyQuestionId);

			builder
				.ToTable("Answers");
		}
	}
}