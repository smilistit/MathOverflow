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
        /// <returns>The question Id or -1, if the quaestion was not created</returns>
        public static int CreateQuestion(string category, string header, string body, int userId)
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

                if (question.Id > 0)
                    return question.Id;
                else
                    return -1;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>A list of questions from the last month</returns>
        public static List<Question> GetLastMonthQuestions()
        {
            List<Question> questionsList = new List<Question>();
            DateTime lastMonth = DateTime.Now.AddMonths(-1);

            using (var db = new MathOverFlowContext())
            {
                questionsList = db.Questions.Where<Question>(q => q.Date >= lastMonth).ToList<Question>();
            }

            return questionsList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="questionId"></param>
        /// <returns></returns>
        public static Question GetQuestionById(int questionId)
        {
            using (var db = new MathOverFlowContext())
            {
                return db.Questions.Find(questionId);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="header"></param>
        /// <returns></returns>
        public static List<Question> GetQuestionsByHeader(string header)
        {
            List<Question> questionsList = new List<Question>();

            using (var db = new MathOverFlowContext())
            {
                questionsList = db.Questions.Where<Question>(q => q.Header.Contains(header)).ToList<Question>();
            }

            return questionsList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static List<Question> GetQuestionsByUserName(string username)
        {
            List<Question> questionsList = new List<Question>();

            using (var db = new MathOverFlowContext())
            {
                User user = db.Users.Where(x => x.UserName == username).FirstOrDefault();
                if (user == null)
                    return questionsList;
                questionsList = db.Questions.Where<Question>(q => q.UserId == user.Id).ToList<Question>();
            }

            return questionsList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        public static List<Question> GetQuestionsByDates(DateTime fromDate, DateTime toDate)
        {
            List<Question> questionsList = new List<Question>();

            using (var db = new MathOverFlowContext())
            {
                questionsList = db.Questions.Where<Question>(q => q.Date >= fromDate && q.Date <= toDate).ToList<Question>();
            }

            return questionsList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public static List<Question> GetQuestionsByCategory(string category)
        {
            List<Question> questionsList = new List<Question>();

            using (var db = new MathOverFlowContext())
            {
                questionsList = db.Questions.Where<Question>(q => q.Category == category).ToList<Question>();
                //questionsList = (from q in db.Questions
                //                where q.Category == category
                //                select q).ToList<Question>();
            }

            return questionsList;
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
