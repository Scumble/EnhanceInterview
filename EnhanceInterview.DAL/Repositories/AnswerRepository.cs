using System.Collections.Generic;
using System.Linq;
using EnhanceInterview.DAL.Interfaces;
using EnhanceInterview.DAL.Models;
using EnhanceInterview.DAL.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace EnhanceInterview.DAL.Repositories
{
	public class AnswerRepository : IAnswerRepository
	{
		private readonly DatabaseContext _context;

		public AnswerRepository(DatabaseContext context)
		{
			_context = context;
		}

		public IEnumerable<AnswerViewModel> GetInterviewResultsByInterviewId(int interviewId, string searchString, string category)
		{
			return from answer in _context.Answers
				join vacancyQuestion in _context.VacancyQuestions on answer.VacancyQuestionId equals vacancyQuestion.Id
				join question in _context.Questions on vacancyQuestion.QuestionId equals question.Id
				where answer.InterviewId == interviewId &&
					question.Content.Contains(searchString) &&
					question.Category.Contains(category)
				select new AnswerViewModel
				{
					Category = question.Category,
					Complexity = question.Complexity,
					Content = question.Content,
					Estimation = answer.Estimation,
					Id = answer.Id,
					InterviewId = answer.InterviewId,
					QuestionId = question.Id,
					Type = question.Type
				};
		}

		public Answer AddAnswer(Answer answer)
		{
			if (answer.Id == 0)
			{
				_context.Answers.Add(answer);
			}
			else
			{
				var dbEntry = _context.Answers.Find(answer.Id);
				if (dbEntry != null)
				{
					dbEntry.InterviewId = answer.InterviewId;
					dbEntry.VacancyQuestionId = answer.VacancyQuestionId;
					dbEntry.Estimation = answer.Estimation;
				}
			}

			_context.SaveChanges();
			return answer;
		}

		public void UpdateAnswer(Answer answer)
		{
			_context.Entry(answer).State = EntityState.Modified;
			_context.SaveChanges();
		}

		public void DeleteAnswer(int answerId)
		{
			var answer = _context.Answers.Find(answerId);

			if (answer == null)
			{
				return;
			}

			_context.Answers.Remove(answer);
			_context.SaveChanges();
		}
	}
}