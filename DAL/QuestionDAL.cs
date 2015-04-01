using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public static class QuestionDAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="category"></param>
        /// <param name="header"></param>
        /// <param name="body"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static bool CreateQuestion(string category, string header, string body, int userId)
        {
            using (var db = new MathOverFlowContext())
            {
                Question question = new Question
                {
                    Category = category,
                    Header = header,
                    Body = body,
                    UserId = userId,
                    Rate = 0,
                    Date = DateTime.Now,
                    IsLocked = false
                };
                db.Questions.Add(question);
                db.SaveChanges();

                return true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<Question> GetLastQuestion()
        {
            List<Question> questionList = new List<Question>();

            using (var db = new MathOverFlowContext())
            {
                questionList = (from q in db.Questions
                               where q.Date >= DateTime.Now.AddMonths(-1)
                               select q).ToList<Question>();
            }

            return questionList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="header"></param>
        /// <returns></returns>
        public static List<Question> GetQuestionsByHeader(string header)
        {
            List<Question> questionList = new List<Question>();

            using (var db = new MathOverFlowContext())
            {
                questionList = (from q in db.Questions
                                where q.Header.Contains(header)
                                select q).ToList<Question>();
            }

            return questionList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static List<Question> GetQuestionsByUserName(string username)
        {
            List<Question> questionList = new List<Question>();

            using (var db = new MathOverFlowContext())
            {
                User user = db.Users.Where(x => x.UserName == username).FirstOrDefault();
                if (user == null)
                    return questionList;
                questionList = (from q in db.Questions
                                where q.UserId == user.Id
                                select q).ToList<Question>();
            }

            return questionList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        public static List<Question> GetQuestionsByDates(DateTime fromDate, DateTime toDate)
        {
            List<Question> questionList = new List<Question>();

            using (var db = new MathOverFlowContext())
            {
                questionList = (from q in db.Questions
                                where q.Date >= fromDate && q.Date <= toDate
                                select q).ToList<Question>();
            }

            return questionList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public static List<Question> GetQuestionsByCategory(string category)
        {
            List<Question> questionList = new List<Question>();

            using (var db = new MathOverFlowContext())
            {
                questionList = (from q in db.Questions
                                where q.Category == category
                                select q).ToList<Question>();
            }

            return questionList;
        }
      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="questionId"></param>
        /// <param name="rate"></param>
        /// <returns></returns>
        public static bool UpdateQuestionRate(int questionId, int rate)
        {
            using (var db = new MathOverFlowContext())
            {
                Question question = db.Questions.Find(questionId);

                if (question == null)
                    return false;

                question.Rate = (short)rate;
                db.Entry(question).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="questionLockState"></param>
        /// <param name="questionId"></param>
        /// <returns></returns>
        public static bool UpdateQuestionLockStateInDB(bool questionLockState, int questionId)
        {
            using (var db = new MathOverFlowContext())
            {
                Question question = db.Questions.Find(questionId);

                if (question == null)
                    return false;

                question.IsLocked = questionLockState;
                db.Entry(question).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return true;
            }          
        }


    }

}
