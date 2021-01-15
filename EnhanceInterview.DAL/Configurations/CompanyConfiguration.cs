using EnhanceInterview.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnhanceInterview.DAL.Configurations
{
	public class CompanyConfiguration : IEntityTypeConfiguration<Company>
	{
		public void Configure(EntityTypeBuilder<Company> builder)
		{
			builder
				.HasKey(x => x.Id);

			builder
				.Property(x => x.Id)
				.ValueGeneratedOnAdd();

			builder
				.Property(x => x.Name)
				.IsRequired()
				.HasMaxLength(50);

			builder
				.Property(x => x.Description);

			builder
				.Property(x => x.Location)
				.IsRequired()
				.HasMaxLength(50);

			builder
				.ToTable("Companies");
		}
	}
}