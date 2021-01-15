using EnhanceInterview.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnhanceInterview.DAL.Configurations
{
	public class InterviewConfiguration : IEntityTypeConfiguration<Interview>
	{
		public void Configure(EntityTypeBuilder<Interview> builder)
		{
			builder
				.HasKey(x => x.Id);

			builder
				.Property(x => x.Id)
				.ValueGeneratedOnAdd();

			builder
				.HasOne(x => x.Vacancy)
				.WithMany(x => x.Interviews)
				.HasForeignKey(x => x.VacancyId);

			builder
				.HasOne(x => x.Applicant)
				.WithMany(x => x.Interviews)
				.HasForeignKey(x => x.ApplicantId);

			builder
				.ToTable("Interviews");
		}
	}
}