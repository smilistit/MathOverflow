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
        /// <param name="username"></param>
        /// <param name="rate"></param>
        public AnswerBL(int questionId, string answerBody, string username, int rate = 0)
        {
            if (!SetUsername(username))
                _id = -1;
            if (!SetQuestionId(questionId))
                _id = -1;
            Body = answerBody;
            Rate = rate;
            _uploadDate = DateTime.Now;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="answer"></param>
        public AnswerBL(Answer answer)
        {
            if (answer != null)
            {
                _id = answer.Id;
                // the username and question Id must be valid - otherwise it wouldn't have been uploaded to the DB
                _username = UserBL.GetUserBlById(answer.UserId).Username;
                _questionId = answer.QuestionId;
                Body = answer.Body;
                Rate = answer.Rate;
                _uploadDate = answer.Date;
            }
            else
                _id = -1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool SetUsername(string username)
        {
            UserBL userBL = UserBL.GetUserBlByUsername(username);
            // the answer's username will only be updated once, so we only set it if it's currently empty and that the username exist in the DB
            if (String.IsNullOrEmpty(_username) && userBL != null)
            {
                _username = username;
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="questionId"></param>
        /// <returns></returns>
        public bool SetQuestionId(int questionId)
        {
            QuestionBL questionBL = QuestionBL.GetQuestionBlById(questionId);
            // the question Id will only be updated once, so we only set it if it's currently 0 (not set) and that the Id is valid
            if (QuestionId == 0 && questionBL != null)
            {
                _questionId = questionId;
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="answerBL"></param>
        /// <returns></returns>
        public static bool AnswerBlValid(AnswerBL answerBL)
        {
            return (answerBL._id == -1 ? false : true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="body"></param>
        /// <param name="questionID"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static bool UploadAnswerToDB(string body, int questionId, int userId)
        {
            if (String.IsNullOrWhiteSpace(body) || questionId < 1 || userId < 1)
                return false;
            int id = DAL.AnswerDAL.CreateAnswer(body, questionId, userId);
            return id > 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="answer"></param>
        /// <returns></returns>
        public bool UploadAnswerToDB()
        {
            if (String.IsNullOrWhiteSpace(Body) || QuestionId < 0 || Username == null)
                return false;
            int uId = UserBL.GetUserIdByUsername(Username);
            if (uId < 1)
                return false;
            _id = DAL.AnswerDAL.CreateAnswer(Body, QuestionId, uId);
            return Id > 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="answers"></param>
        /// <returns></returns>
        private static List<AnswerBL> ConvertAnswerListToAnswerBlList(List<Answer> answers)
        {
            List<AnswerBL> answersBL = new List<AnswerBL>();
            foreach (Answer a in answers)
            {
                AnswerBL aBL = new AnswerBL(a);
                answersBL.Add(aBL);
            }
            return answersBL;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="questionId"></param>
        /// <returns></returns>
        public static List<AnswerBL> GetAnswersByQuestionId(int questionId)
        {
            List<Answer> answers = DAL.AnswerDAL.GetAnswerByQuestionId(questionId);
            return ConvertAnswerListToAnswerBlList(answers);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static List<AnswerBL> GetAnswersByUserName(string username)
        {
            List<Answer> answers = DAL.AnswerDAL.GetAnswerByUserName(username);
            return ConvertAnswerListToAnswerBlList(answers);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rate"></param>
        /// <returns></returns>
        public bool UpdateAnswerRate(int rate)
        {
            if (DAL.AnswerDAL.UpdateAnswerRate(Id, rate))
            {
                Rate = rate;
                return true;
            }
            return false;
        }


        // getters and setters

        private int _id = 0;
        public int Id { get { return _id; } }

        private int _questionId = 0;
        public int QuestionId
        {
            get
            {
                Answer answer = DAL.AnswerDAL.GetAnswerById(Id);
                if (answer == null)
                    return _questionId;
                return answer.QuestionId;
            }
        }


        public string Body { get; set; }

        private string _username = String.Empty;
        public string Username
        {
            get
            {
                Answer answer = DAL.AnswerDAL.GetAnswerById(Id);
                if (answer == null)
                    return _username;
                UserBL userBL = UserBL.GetUserBlById(answer.UserId);
                return userBL.Username;
            }
        }

        public int Rate { get; set; }

        private DateTime? _uploadDate;
        public DateTime? UploadDate { get { return _uploadDate; } }
    }
}
