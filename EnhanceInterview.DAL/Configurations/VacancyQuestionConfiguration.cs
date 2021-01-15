using EnhanceInterview.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnhanceInterview.DAL.Configurations
{
	public class VacancyQuestionConfiguration : IEntityTypeConfiguration<VacancyQuestion>
	{
		public void Configure(EntityTypeBuilder<VacancyQuestion> builder)
		{
			builder
				.HasKey(x => x.Id);

			builder
				.Property(x => x.Id)
				.ValueGeneratedOnAdd();

			builder
				.HasOne(x => x.Vacancy)
				.WithMany(x => x.VacancyQuestions)
				.HasForeignKey(x => x.VacancyId);

			builder
				.HasOne(x => x.Question)
				.WithMany(x => x.VacancyQuestions)
				.HasForeignKey(x => x.QuestionId);

			builder
				.ToTable("VacancyQuestions");
		}
	}
}