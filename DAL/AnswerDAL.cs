using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public static class AnswerDAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="body"></param>
        /// <param name="questionId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static int CreateAnswer(string body, int questionId, int userId)
        {
            using (var db = new MathOverFlowContext())
            {
                User user = db.Users.Find(userId);
                Question question = db.Questions.Find(questionId);

                if (user == null || question == null)
                    return -1;

                Answer answer = new Answer
                {
                    Body = body,
                    QuestionId = questionId,
                    UserId = userId,
                    Rate = 0,
                    Date = DateTime.Now
                };

                db.Answers.Add(answer);
                db.SaveChanges();

                return answer.Id;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="answerId"></param>
        /// <returns></returns>
        public static Answer GetAnswerById(int answerId)
        {
            using (var db = new MathOverFlowContext())
            {
                return db.Answers.Find(answerId);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="questionID"></param>
        /// <returns></returns>
        public static List<Answer> GetAnswerByQuestionId(int questionID)
        {
            List<Answer> answerList = new List<Answer>();

            using (var db = new MathOverFlowContext())
            {
                answerList = (from a in db.Answers
                              where a.QuestionId == questionID
                              select a).ToList<Answer>();
            }

            return answerList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static List<Answer> GetAnswerByUserName(string username)
        {
            List<Answer> answerList = new List<Answer>();

            using (var db = new MathOverFlowContext())
            {              
                User user = db.Users.Where(x => x.UserName == username).FirstOrDefault();
                
                if (user == null)
                    return answerList;


                answerList = (from a in db.Answers
                              where a.UserId == user.Id
                              select a).ToList<Answer>();
            }

            return answerList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="answerId"></param>
        /// <param name="rate"></param>
        /// <returns></returns>
        public static bool UpdateAnswerRate(int answerId, int rate)
        {
            using (var db = new MathOverFlowContext())
            {
                Answer answer = db.Answers.Find(answerId);

                if (answer == null)
                    return false;

                answer.Rate = (short)rate;
                db.Entry(answer).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return true;
            }
        }

        
    }
}
