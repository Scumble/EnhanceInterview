using System.Collections.Generic;
using System.Linq;
using EnhanceInterview.DAL.Interfaces;
using EnhanceInterview.DAL.Models;
using EnhanceInterview.DAL.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace EnhanceInterview.DAL.Repositories
{
	public class FeedbackRepository : IFeedbackRepository
	{
		private readonly DatabaseContext _context;

		public FeedbackRepository(DatabaseContext context)
		{
			_context = context;
		}

		public IEnumerable<FeedbackViewModel> GetApplicantFeedbacks(int interviewId)
		{
			var model = from feedback in _context.Feedbacks
				join interviewer in _context.Interviewers on feedback.InterviewerId equals interviewer.Id
				join worker in _context.Workers on interviewer.WorkerId equals worker.Id
				join user in _context.Users on worker.UserId equals user.UserId
				select new
				{
					Id = feedback.Id,
					InterviewerId = interviewer.Id,
					InterviewId = feedback.InterviewId,
					WorkerId = worker.Id,
					FeedbackContent = feedback.Content,
					FirstName = worker.FirstName,
					LastName = worker.LastName,
					Role = user.Role
				};

			return from x in model
				join interview in _context.Interviews on x.InterviewId equals interview.Id
				join vacancy in _context.Vacancies on interview.VacancyId equals vacancy.Id
				where interview.Id == interviewId
				select new FeedbackViewModel
				{
					Id = x.Id,
					InterviewerId = x.InterviewerId,
					InterviewId = x.InterviewId,
					WorkerId = x.WorkerId,
					Content = x.FeedbackContent,
					FirstName = x.FirstName,
					LastName = x.LastName,
					Role = x.Role,
					VacancyTitle = vacancy.Title
				};
		}

		public void AddFeedback(Feedback feedback)
		{
			if (feedback.Id == 0)
			{
				_context.Feedbacks.Add(feedback);
			}
			else
			{
				var dbEntry = _context.Feedbacks.Find(feedback.Id);
				if (dbEntry != null)
				{
					dbEntry.InterviewerId = feedback.InterviewerId;
					dbEntry.InterviewId = feedback.InterviewId;
					dbEntry.Content = feedback.Content;
				}
			}

			_context.SaveChanges();
		}

		public void UpdateFeedback(Feedback feedback)
		{
			_context.Entry(feedback).State = EntityState.Modified;
			_context.SaveChanges();
		}

		public void DeleteFeedback(int feedbackId)
		{
			var feedback = _context.Feedbacks.Find(feedbackId);

			if (feedback == null)
			{
				return;
			}

			_context.Feedbacks.Remove(feedback);
			_context.SaveChanges();
		}
	}
}