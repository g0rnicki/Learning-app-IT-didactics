using EzLearning.Server.Dal;
using EzLearning.Server.Dal.Models;
using EzLearning.Server.Services.Contracts;
using EzLearning.Server.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EzLearning.Server.Services
{
    public class LearningService : ILearningService
    {
        private readonly AppDataContext _ctx;

        public LearningService(AppDataContext ctx)
        {
            _ctx = ctx;
        }

        public Task<List<ChapterDto>> GetAllChapters()
        {
            var chapters = from c in _ctx.chapters
                           orderby c.Id ascending
                           select c;
            var result = chapters.Select(c => new ChapterDto { Id = c.Id, Name = c.Name, Available = c.Lessons.Any() }).ToList();
            return Task.FromResult(result);
        }

        public Task<List<QuestionDto>> GetChapterQuizQuestionsByChapterId(int chapterId)
        {
            var quizQuestions = from ct in _ctx.tests
                                where ct.ChapterId == chapterId
                                select ct.TestQuestions;

            if (!quizQuestions.Any())
            {
                throw new IndexOutOfRangeException("There are no quiz questions for the provided chapter ID.");
            }

            var questionIds = quizQuestions.First().Select(qq => qq.Id).ToList();

            var questions = _ctx.questions.Where(q => questionIds.Contains(q.Id));
                            
            return Task.FromResult(questions.Select(q => new QuestionDto
            {
                Id = q.Id,
                QuestionContent = q.Content,
                CorrectAnswer = new AnswerDto { Id = q.CorrectAnswer.Id, AnswerContent = q.CorrectAnswer.Answer },
                WrongAnswers = q.WrongAnswers.Select(wa => new AnswerDto { Id = wa.Id, AnswerContent = wa.Answer }).ToArray()
            }).ToList());
        }

        public Task<LessonDto> GetLessonById(int lessonId)
        {
            var lessons = from l in _ctx.lessons
                          where l.Id == lessonId
                          select l;
            
            if (!lessons.Any())
            {
                throw new IndexOutOfRangeException("Lesson with provided ID does not exist.");
            }

            return Task.FromResult(new LessonDto
            {
                Id = lessons.First().Id,
                LessonNumber = lessons.First().LessonNumber,
                Part = lessons.First().Part,
                Title = lessons.First().Title,
                Content = lessons.First().Content,
                ChapterId = lessons.First().ChapterId,
                QuestionId = lessons.First().QuestionId
            });
        }

        public Task<int> GetLessonIdByLessonNumberAndPart(int lessonNumber, int part)
        {
            var queryResult = from l in _ctx.lessons
                              where l.LessonNumber == lessonNumber && l.Part == part
                              select l.Id;

            if (!queryResult.Any())
            {
                throw new IndexOutOfRangeException("Lesson with provided lessonNumber and part does not exist.");
            }

            return Task.FromResult(queryResult.First());
        }

        public Task<List<int>> GetLessonNumbersForFinishedChapterLesssons(Guid userId, int chapterId)
        {
            var query = from ufl in _ctx.userFinishedLessons
                        where ufl.UserId == userId
                        select ufl.LessonNumber;

            return Task.FromResult(query.Distinct().ToList());
        }

        public Task<List<LessonDto>> GetLessonsByChapterId(int chapterId)
        {
            var lessons = from l in _ctx.lessons
                          where l.ChapterId == chapterId
                          orderby l.Id ascending
                          select l;
            var result = lessons.Select(
                l => new LessonDto
                {
                    Id = l.Id,
                    LessonNumber = l.LessonNumber,
                    Part = l.Part,
                    Title = l.Title,
                    Content = l.Content,
                    ChapterId = l.ChapterId,
                    QuestionId = l.QuestionId
                }).ToList();
            return Task.FromResult(result);
        }

        public Task<QuestionDto> GetQuestionById(int questionId)
        {
            var questions = from question in _ctx.questions
                            where question.Id == questionId
                            select question;

            if (!questions.Any())
            {
                throw new IndexOutOfRangeException("Question with provided ID does not exist.");
            }

            return Task.FromResult(questions.Select(q => new QuestionDto
            {
                Id = q.Id,
                QuestionContent = q.Content,
                CorrectAnswer = new AnswerDto { Id = q.CorrectAnswer.Id, AnswerContent = q.CorrectAnswer.Answer },
                WrongAnswers = q.WrongAnswers.Select(wa => new AnswerDto { Id = wa.Id, AnswerContent = wa.Answer }).ToArray()
            }).First());
        }

        public Task<int> GetTotalLessonsFinished(Guid userId)
        {
            var query = from ufl in _ctx.userFinishedLessons
                        where ufl.UserId == userId
                        group ufl by new { ufl.UserId, ufl.LessonNumber } into g
                        select g;
            var count = query.Count();
            return Task.FromResult(count);
        }

        public async Task SaveUserFinishedLesson(UserFinishedLessonDto userProgress)
        {
            var newRecord = new UserFinishedLesson
            {
                UserId = userProgress.UserId,
                LessonNumber = userProgress.LessonNumber
            };

            await _ctx.userFinishedLessons.AddAsync(newRecord);
            await _ctx.SaveChangesAsync();
        }
    }
}
