using EnhanceInterview.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnhanceInterview.DAL.Configurations
{
	public class VacancyConfiguration : IEntityTypeConfiguration<Vacancy>
	{
		public void Configure(EntityTypeBuilder<Vacancy> builder)
		{
			builder
				.HasKey(x => x.Id);

			builder
				.Property(x => x.Id)
				.ValueGeneratedOnAdd();

			builder
				.HasOne(x => x.Recruiter)
				.WithMany(x => x.Vacancies)
				.HasForeignKey(x => x.RecruiterId);

			builder
				.ToTable("Vacancies");
		}
	}
}