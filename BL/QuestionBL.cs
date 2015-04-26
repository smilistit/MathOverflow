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
        /// <param name="username"></param>
        public QuestionBL(string questionCatagory, string questionHeader, string questionBody, string username)
        {
            // only if the user exist - we'll update the username field, else the question id is invalid
            if (UserBL.GetUserIdByUsername(username) > 0)
                _username = username;
            else
                _id = -1;

            Category = questionCatagory;
            Header = questionHeader;
            Body = questionBody;
            _uploadDate = DateTime.Now;
            Rate = 0;
            _isLocked = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="question"></param>
        private QuestionBL(Question question)
        {
            if (question != null)
            {
                _id = question.Id;
                // the username must be valid - otherwise it wouldn't have been uploaded to the DB
                _username = UserBL.GetUserBlById(question.UserId).Username;
                _uploadDate = question.Date;
                Category = question.Category;
                Header = question.Header;
                Body = question.Body;
                Rate = question.Rate;
                _isLocked = question.IsLocked;
            }
            else
                _id = -1;
        }

        #region public methods
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns>A list of questionsBL from the last month</returns>
        public static List<QuestionBL> GetLastQuestions()
        {
            List<Question> questions = DAL.QuestionDAL.GetLastMonthQuestions();
            return ConvertQuestionListToQuestionBlList(questions);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="category"></param>
        /// <param name="header"></param>
        /// <param name="body"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static bool UploadQuestionToDB(string category, string header, string body, int userId)
        {
            if (String.IsNullOrWhiteSpace(category) || String.IsNullOrWhiteSpace(header) || String.IsNullOrWhiteSpace(body) || userId < 1)
                return false;
            int id = DAL.QuestionDAL.CreateQuestion(category, header, body, userId);
            return id > 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool UploadQuestionToDB()
        {
            if (String.IsNullOrWhiteSpace(Category) || String.IsNullOrWhiteSpace(Header) || String.IsNullOrWhiteSpace(Body) || Username == null)
                return false;
            int uId = UserBL.GetUserIdByUsername(Username);
            if (uId < 1)
                return false;
            _id = DAL.QuestionDAL.CreateQuestion(Category, Header, Body, uId);
            return Id > 0;
        }

        /// <summary>
        /// Gets qusetions list contains a given header.
        /// </summary>
        /// <param name="header">The header to search by.</param>
        /// <returns>Question list which contains the given header.</returns>
        public static List<QuestionBL> GetQuestionsByHeader(string header)
        {
            List<Question> questions = DAL.QuestionDAL.GetQuestionsByHeader(header);
            return ConvertQuestionListToQuestionBlList(questions);
        }


        /// <summary>
        /// Convert a list of Question to a list of QuestionBL
        /// </summary>
        /// <param name="questions"></param>
        /// <returns></returns>
        private static List<QuestionBL> ConvertQuestionListToQuestionBlList(List<Question> questions)
        {
            List<QuestionBL> questionsBL = new List<QuestionBL>();
            foreach (Question q in questions)
            {
                QuestionBL qBL = new QuestionBL(q);
                questionsBL.Add(qBL);
            }
            return questionsBL;
        }

        /// <summary>
        /// Gets qusetions list written by a given user name.
        /// </summary>
        /// <param name="username">The user name to search by</param>
        /// <returns>QuestionBL list whos written by the given user name</returns>
        public static List<QuestionBL> GetQuestionsByUsername(string username)
        {
            List<Question> questions = DAL.QuestionDAL.GetQuestionsByUserName(username);
            return ConvertQuestionListToQuestionBlList(questions);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        public static List<QuestionBL> GetQuestionsByDates(DateTime fromDate, DateTime toDate)
        {
            List<Question> questions = DAL.QuestionDAL.GetQuestionsByDates(fromDate, toDate);
            return ConvertQuestionListToQuestionBlList(questions);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public static List<QuestionBL> GetQuestionsByCategory(string category)
        {
            List<Question> questions = DAL.QuestionDAL.GetQuestionsByCategory(category);
            return ConvertQuestionListToQuestionBlList(questions); 
        }

       /// <summary>
       /// Update the question rate after it was uploaded to the DB
       /// </summary>
       /// <param name="rate"></param>
       /// <returns></returns>
        public bool UpdateQuestionRate(int rate)
        {         
            if (DAL.QuestionDAL.UpdateQuestionRate(Id, rate))
            {
                Rate = rate;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Lock the question if the user is an admin and updates in DB
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public bool LockQuestion(UserAdmin admin)
        {
            if (admin is UserAdmin && DAL.QuestionDAL.UpdateQuestionLockStateInDB(true, Id))
            {
                _isLocked = true;                
                return true;
            }
            return false;
        }

        /// <summary>
        /// Unlock the question if the user is an admin and updates in DB
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public bool UnlockQuestion(UserAdmin admin)
        {
            if (admin is UserAdmin && DAL.QuestionDAL.UpdateQuestionLockStateInDB(false, Id))
            {
                _isLocked = false;
                return true;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="questionBL"></param>
        /// <returns>True if the username was valid when creating the questionBL, false otherwise</returns>
        public static bool QuestionBlValid(QuestionBL questionBL)
        {
            return (questionBL._id == -1 ? false : true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool SetUsername(string username)
        {
            UserBL userBL = UserBL.GetUserBlByUsername(username);
            // the question's username will only be updated once, so we only set it if it's currently empty and that the username exist in the DB
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
        public static QuestionBL GetQuestionBlById(int questionId)
        {
            Question question = DAL.QuestionDAL.GetQuestionById(questionId);
            if (question == null)
                return null;
            return new QuestionBL(question);
        }

        #endregion
    
        // getters and setters

        private int _id = 0;
        public int Id { get { return _id; } }

        public string Category { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }

        private string _username = String.Empty;
        public string Username
        {
            get
            {
                Question question = DAL.QuestionDAL.GetQuestionById(Id);
                if (question == null)
                    return _username;
                UserBL userBL = UserBL.GetUserBlById(question.UserId);
                return userBL.Username;
            }
        }

        private DateTime? _uploadDate;
        public DateTime? UploadDate { get { return _uploadDate; } }

        public int Rate { get; set; }

        private bool _isLocked;
        public bool IsLocked { get { return _isLocked; } }
        
    }
}
