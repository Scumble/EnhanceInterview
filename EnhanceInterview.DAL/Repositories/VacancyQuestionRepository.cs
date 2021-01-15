using System.Linq;
using EnhanceInterview.DAL.Interfaces;
using EnhanceInterview.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace EnhanceInterview.DAL.Repositories
{
	public class VacancyQuestionRepository : IVacancyQuestionRepository
	{
		private readonly DatabaseContext _context;

		public VacancyQuestionRepository(DatabaseContext context)
		{
			_context = context;
		}

		public VacancyQuestion GetVacancyQuestionById(int? vacancyQuestionId)
		{
			return _context.VacancyQuestions.FirstOrDefault(x => x.Id == vacancyQuestionId);
		}

		public void AddVacancyQuestion(VacancyQuestion vacancyQuestion)
		{
			if (vacancyQuestion.Id == 0)
			{
				_context.VacancyQuestions.Add(vacancyQuestion);
			}
			else
			{
				var dbEntry = _context.VacancyQuestions.Find(vacancyQuestion.Id);
				if (dbEntry != null)
				{
					dbEntry.VacancyId = vacancyQuestion.VacancyId;
					dbEntry.QuestionId = vacancyQuestion.QuestionId;
				}
			}

			_context.SaveChanges();
		}

		public void UpdateVacancyQuestion(VacancyQuestion vacancyQuestion)
		{
			_context.Entry(vacancyQuestion).State = EntityState.Modified;
			_context.SaveChanges();
		}

		public void DeleteVacancyQuestion(int questionId, int vacancyId)
		{
			var vacancyQuestion = _context.VacancyQuestions.FirstOrDefault(x=>x.QuestionId == questionId && x.VacancyId == vacancyId);

			if (vacancyQuestion == null)
			{
				return;
			}

			_context.VacancyQuestions.Remove(vacancyQuestion);
			_context.SaveChanges();
		}
	}
}