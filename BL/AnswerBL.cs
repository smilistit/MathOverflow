using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BL
{
    public class AnswerBL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="questionId"></param>
        /// <param name="answerBody"></param>
        /// <param name="answeredByUserName"></param>
        /// <param name="rate"></param>
        public AnswerBL(int questionId, string answerBody, string answeredByUserName, int rate = 0)
        {
            QuestionId = questionId;
            AnswerBody = answerBody;
            AnsweredByUserName = answeredByUserName;
            Rate = rate;
        }


        //public AnswerBL() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="body"></param>
        /// <param name="questionID"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public bool UploadAnswerToDB(string body, int questionId, int userId)
        {
            return DAL.AnswerDAL.CreateAnswer(body, questionId, userId); ;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="answer"></param>
        /// <returns></returns>
        public bool UploadAnswerToDB()
        {
            if (String.IsNullOrWhiteSpace(AnswerBody) || QuestionId < 0 || AnsweredByUserName == null)
                return false;
            return DAL.AnswerDAL.CreateAnswer(AnswerBody, QuestionId, UserBL.GetUserIdByUsername(AnsweredByUserName));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="questionID"></param>
        /// <returns></returns>
        public List<Answer> GetAnswerByQuestionID(int questionID)
        {
            return DAL.AnswerDAL.GetAnswerByQuestionID(questionID);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public List<Answer> GetAnswerByUserName(string userName)
        {
            return DAL.AnswerDAL.GetAnswerByUserName(userName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rate"></param>
        /// <returns></returns>
        public bool UpdateAnswerRate(int answerId, int rate)
        {
            return DAL.AnswerDAL.UpdateAnswerRate(answerId, rate);
        }


        private int _id;
        public int Id { get { return _id; } }

        public int QuestionId { get; set; }
        public string AnswerBody { get; set; }
        public string AnsweredByUserName { get; set; }
        public int Rate { get; set; }

    }
}
