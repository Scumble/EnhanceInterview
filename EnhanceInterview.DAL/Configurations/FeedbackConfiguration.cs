using EnhanceInterview.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnhanceInterview.DAL.Configurations
{
	public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
	{
		public void Configure(EntityTypeBuilder<Feedback> builder)
		{
			builder
				.HasKey(x => x.Id);

			builder
				.Property(x => x.Id)
				.ValueGeneratedOnAdd();

			builder
				.HasOne(x => x.Interview)
				.WithMany(x => x.Feedbacks)
				.HasForeignKey(x => x.InterviewId);

			builder
				.HasOne(x => x.Interviewer)
				.WithMany(x => x.Feedbacks)
				.HasForeignKey(x => x.InterviewerId);

			builder
				.ToTable("Feedback");
		}
	}
}