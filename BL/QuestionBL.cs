using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DAL;


namespace BL
{
    public class QuestionBL
    {
        
        //public QuestionBL() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="questionCatagory"></param>
        /// <param name="questionHeader"></param>
        /// <param name="questionBody"></param>
        /// <param name="askedByUserName"></param>
        public QuestionBL(string questionCatagory, string questionHeader, string questionBody, string askedByUserName)
        {
            QuestionCategory = questionCatagory;
            QuestionHeader = questionHeader;
            QuestionBody = questionBody;
            _askedByUserName = askedByUserName;
            _questionUploadDate = DateTime.Now;
            Rate = 0;
            _isLocked = false;
        }

        #region public methods
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Question> GetLastQuestions()
        {
            return DAL.QuestionDAL.GetLastQuestion();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="category"></param>
        /// <param name="header"></param>
        /// <param name="body"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public bool UploadQuestionToDB(string category, string header, string body, int userId)
        {
            return DAL.QuestionDAL.CreateQuestion(category, header, body, userId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool UploadQuestionToDB()
        {
            if (String.IsNullOrWhiteSpace(QuestionCategory) || String.IsNullOrWhiteSpace(QuestionHeader) || String.IsNullOrWhiteSpace(QuestionBody) || AskedByUserName == null)
                return false;
            return DAL.QuestionDAL.CreateQuestion(QuestionCategory, QuestionHeader, QuestionBody, UserBL.GetUserIdByUsername(AskedByUserName));
        }

        /// <summary>
        /// Gets qusetions list contains a given header.
        /// </summary>
        /// <param name="header">The header to search by.</param>
        /// <returns>Question list which contains the given header.</returns>
        public List<Question> GetQuestionsByHeader(string header)
        {
            return DAL.QuestionDAL.GetQuestionsByHeader(header);
        }

        /// <summary>
        /// Gets qusetions list written by a given user name.
        /// </summary>
        /// <param name="userName">The user name to search by</param>
        /// <returns>Question list whos written by the given user name</returns>
        public List<Question> GetQuestionsByUserName(string userName)
        {
            return DAL.QuestionDAL.GetQuestionsByUserName(userName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        public List<Question> GetQuestionsByDates(DateTime fromDate, DateTime toDate)
        {                                                              
            return DAL.QuestionDAL.GetQuestionsByDates(fromDate, toDate);                    
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public List<Question> GetQuestionsByCategory(string category)
        {
            return DAL.QuestionDAL.GetQuestionsByCategory(category);
        }

       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rate"></param>
        /// <returns></returns>
        public bool UpdateQuestionRate(int questionId, int rate)
        {         
            return DAL.QuestionDAL.UpdateQuestionRate(questionId, rate);
        }

        /// <summary>
        /// Lock the question if the user is an admin and updates in DB
        /// </summary>
        /// <param name="admin"></param>
        public bool LockQuestion(UserAdmin admin, int questionId)
        {
            if (admin is UserAdmin)
            {
                _isLocked = true;                

                if (DAL.QuestionDAL.UpdateQuestionLockStateInDB(_isLocked, questionId))
                {
                    return true;
                }
                return false;
            }

            return false;
        }

        /// <summary>
        /// Unlock the question if the user is an admin and updates in DB
        /// </summary>
        /// <returns></returns>
        public bool UnlockQuestion(UserAdmin admin, int questionId)
        {
            if (admin is UserAdmin)
            {
                _isLocked = false;

                if (DAL.QuestionDAL.UpdateQuestionLockStateInDB(_isLocked, questionId))
                {
                    return true;
                }
            }

            return false;
        }
        #endregion
    
        private int _id;
        public int Id { get { return _id; } }

        public string QuestionCategory { get; set; }
        public string QuestionHeader { get; set; }
        public string QuestionBody { get; set; }

        private string _askedByUserName;
        public string AskedByUserName { get; set; }

        private DateTime _questionUploadDate;
        public DateTime QuestionUploadDate { get; set; }

        public int Rate { get; set; }

        private bool _isLocked;
        public bool IsLocked { get { return _isLocked; } }
        
    }
}
