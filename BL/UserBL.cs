using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BL
{
    public class UserBL
    {
        /// <summary>
        /// Creates a new UserBL. If the username is unique and valid - the Id property is set to 0, otherwise it is set to -1.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        public UserBL(string username, string password, string firstName = "", string lastName = "")
        {
            if (SetUsername(username))
                _id = 0;
            else
                _id = -1;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Password = password;
            this.IsAdmin = false;
        }

        /// <summary>
        /// Copy constructor. Doesn't copy the username. The admin property set to false and the Id property is set to -1, since the username is invalid.
        /// </summary>
        /// <param name="user"></param>
        public UserBL(UserBL user)
        {
            _id = -1; // since the username is invalid
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.Password = user.Password;
            this.IsAdmin = false;
        }

        /// <summary>
        /// Set the username hasn't been set yet and it's valid and unique
        /// </summary>
        /// <param name="username"></param>
        /// <returns>True if the username has been set and false otherwise</returns>
        public bool SetUsername(string username)
        {
            // the username will be changed only if it's currently empty, and the username is valid and not empty
            if (!String.IsNullOrEmpty(username) && String.IsNullOrEmpty(_username) && ValidateUniqueUserName(Username))
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
        /// <returns>True if the user has been uploaded successfully to the DB, false otherwise</returns>
        public bool UploadUserToDB()
        {
            _id = DAL.UserDAL.CreateUser(Username, FirstName, LastName, Password, MyQuestionsRate, MyAnswersRate);
            if (_id < 1) // the id starts from 1
                return false;
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static int GetUserId(string username)
        {
            User user = DAL.UserDAL.GetUserByUserName(username);
            if (user != null)
                return user.Id;
            else
                return -1;
        }

        public static UserBL GetUserByUsername(string username)
        {
            User user = DAL.UserDAL.GetUserByUserName(username);
            UserBL userBL = new UserBL(user.UserName, user.Password, user.FirstName, user.LastName);
            userBL._id = user.Id;
            return userBL;
        }

        public static List<User> GetAllUsersByUsername(string username) // TODO: like in the UserDAL - I'm not really sure what it's for since the username is unique
        {
            return DAL.UserDAL.GetAllUsersByUsername(username);
        }

        public static bool AuthenticateUser(string username, string password)
        {
            return DAL.UserDAL.AuthenticateUser(username, password);
        }

        public static int GetQuestionRate(int questionId) // TODO: why is it on the UserBL class? shouldn't it move to AnswerBL?
        {
            return DAL.UserDAL.GetQuestionRatePerUser(questionId);
        }

        public static int GetAnswerRate(int answerId) // TODO: why is it on the UserBL class? shouldn't it move to QuestionBL?
        {
            return DAL.UserDAL.GetAnswerRatePerUser(answerId);
        }

        public int GetSpecificQuestionAndAnswerRate(int questionId, int answerId) // TODO: not really sure what's it's for. I think is should be deleted
        {
            return DAL.UserDAL.GetSpecificQuestionAndAnswerRate(questionId, answerId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The rate of the total number of the user's questions and answers</returns>
        public int GetTotalQuestionsAndAnswersRatePerUser()
        {
            return MyQuestionsRate + MyAnswersRate;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns>True if the username is unique, false otherwise</returns>
        private static bool ValidateUniqueUserName(string username)
        {
            return DAL.UserDAL.ValidateUniqueUserName(username);
        }

        private int _id;
        public int Id { get { return _id; } }

        private string _username = String.Empty;
        public string Username { get { return _username; } }

        public string FirstName
        {
            get
            {
                User user = DAL.UserDAL.GetUserById(Id);
                return user.FirstName;
            }
            set
            {
                DAL.UserDAL.UpdateUserFirstName(Id, value);
            }
        }
        public string LastName
        {
            get
            {
                User user = DAL.UserDAL.GetUserById(Id);
                return user.LastName;
            }
            set
            {
                DAL.UserDAL.UpdateUserLastName(Id, value);
            }
        }

        public string Password
        {
            get
            {
                User user = DAL.UserDAL.GetUserById(Id);
                return user.Password;
            }
            set
            {
                DAL.UserDAL.UpdateUserPassword(Id, value);
            }
        }

        public bool IsAdmin { get; set; }

        public int MyQuestionsRate
        { 
            get
            {
                return DAL.UserDAL.GetTotalQuestionsRate(Id);
            }
        }

        public int MyAnswersRate
        {
            get
            {
                return DAL.UserDAL.GetTotalAnswersRate(Id);
            }
        }

    }
}
