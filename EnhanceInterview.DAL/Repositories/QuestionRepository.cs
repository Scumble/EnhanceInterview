using System.Collections.Generic;
using System.Linq;
using EnhanceInterview.DAL.Interfaces;
using EnhanceInterview.DAL.Models;
using EnhanceInterview.DAL.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace EnhanceInterview.DAL.Repositories
{
	public class QuestionRepository : IQuestionRepository
	{
		private readonly DatabaseContext _context;

		public QuestionRepository(DatabaseContext context)
		{
			_context = context;
		}

		public IEnumerable<QuestionViewModel> GetQuestionsByVacancyId(int vacancyId, string category, string searchString)
		{
			var questions =  from vacancyQuestion in _context.VacancyQuestions
				join question in _context.Questions on vacancyQuestion.QuestionId equals question.Id
				where vacancyQuestion.VacancyId == vacancyId && 
					question.Content.Contains(searchString) &&
					question.Category.Contains(category)
				select new QuestionViewModel
				{
					Id = question.Id,
					Category = question.Category,
					Complexity = question.Complexity,
					Content = question.Content,
					Type = question.Type,
					VacancyId = vacancyQuestion.VacancyId,
					VacancyQuestionId = vacancyQuestion.Id
				};

			return questions.OrderByDescending(x => x.Id);
		}

		public QuestionViewModel GetQuestionById(int questionId)
		{
			return (from vacancyQuestion in _context.VacancyQuestions
				join question in _context.Questions on vacancyQuestion.QuestionId equals question.Id
				where question.Id == questionId
				select new QuestionViewModel
				{
					Id = question.Id,
					Category = question.Category,
					Complexity = question.Complexity,
					Content = question.Content,
					Type = question.Type,
					VacancyId = vacancyQuestion.VacancyId,
					VacancyQuestionId = vacancyQuestion.Id
				}).FirstOrDefault();
		}

		public Question AddQuestion(Question question)
		{
			if (question.Id == 0)
			{
				_context.Questions.Add(question);
			}
			else
			{
				var dbEntry = _context.Questions.Find(question.Id);
				if (dbEntry != null)
				{
					dbEntry.Category = question.Category;
					dbEntry.Type = question.Type;
					dbEntry.Complexity = question.Complexity;
					dbEntry.Content = question.Content;
				}
			}

			_context.SaveChanges();
			return question;
		}

		public void UpdateQuestion(Question question)
		{
			_context.Entry(question).State = EntityState.Modified;
			_context.SaveChanges();
		}

		public void DeleteQuestion(int questionId)
		{
			var question = _context.Questions.Find(questionId);

			if (question == null)
			{
				return;
			}

			_context.Questions.Remove(question);
			_context.SaveChanges();
		}
	}
}