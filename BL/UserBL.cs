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
            if (!SetUsername(username))
                _id = -1;
            _firstName = firstName;
            _lastName = lastName;
            _password = password;
        }


        /// <summary>
        /// Copy constructor with a new username. If the username is unique and valid - the Id property is set to 0, otherwise it is set to -1. The admin property set to false.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="username"></param>
        public UserBL(UserBL user, string username)
        {
            UserBL newUser = new UserBL(username, user._password, user._firstName, user._lastName);
        }

        /// <summary>
        /// Copy the information from the user in the DB to the current userBL
        /// </summary>
        /// <param name="user"></param>
        private UserBL(User user)
        {
            _id = user.Id;
            _username = user.UserName;
            _firstName = user.FirstName;
            _lastName = user.LastName;
            _password = user.Password;
        }

        /// <summary>
        /// Set the username hasn't been set yet and it's valid and unique
        /// </summary>
        /// <param name="username"></param>
        /// <returns>True if the username has been set and false otherwise</returns>
        public bool SetUsername(string username)
        {
            // the username will be changed only if the current is empty, and the new username is valid and not empty
            if (String.IsNullOrEmpty(_username) && !String.IsNullOrEmpty(username) && ValidateUniqueUserName(username))
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
            // the id numbers starts from 1
            if ((_id = DAL.UserDAL.CreateUser(_username, _firstName, _lastName, _password)) < 1)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static int GetUserIdByUsername(string username)
        {
            User user = DAL.UserDAL.GetUserByUsername(username);
            if (user != null)
                return user.Id;
            else
                return -1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static UserBL GetUserBlByUsername(string username)
        {
            User user = DAL.UserDAL.GetUserByUsername(username);
            if (user == null)
                return null;
           return new UserBL(user);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userBL"></param>
        /// <returns>True if the username was valid when creating the userBL, false otherwise</returns>
        public static bool UserBlValid(UserBL userBL)
        {
            return (userBL._id == -1 ? false : true);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="userBL"></param>
        /// <returns></returns>
        public override bool Equals(Object obj)
        {
            // Check for null values and compare run-time types.
            if (obj == null || GetType() != obj.GetType())
                return false;

            UserBL userBL = (UserBL)obj;
            if (userBL._id == _id && userBL._username.Equals(_username) && userBL._firstName.Equals(_firstName) &&
                userBL._lastName.Equals(_lastName) && userBL._password.Equals(_password) && userBL._isAdmin == _isAdmin)
            {
                return true;
            }
            else
                return false;
        }


        // gettes and settes

        private int _id = 0;
        public int Id
        {
            get
            {
                // all of the get's content must reffer to _username and not the Username in order to prevent infinite recursion
                if (String.IsNullOrEmpty(_username))
                    return -1;
                User user = DAL.UserDAL.GetUserByUsername(_username);
                if (user == null || _id == -1)
                    return -1;
                else
                    return user.Id;
            }
        }

        private string _username = String.Empty;
        public string Username
        {
            get
            {
                // all of the get's content must reffer to _id and not the Id in order to prevent infinite recursion
                User user = DAL.UserDAL.GetUserById(_id);
                if (user == null)
                    return _username;
                return user.UserName;
            }
        }

        private string _firstName = String.Empty;
        public string FirstName
        {
            get
            {
                User user = DAL.UserDAL.GetUserById(Id);
                if (user == null)
                    return _firstName;
                return user.FirstName;
            }
            set
            {
                if (DAL.UserDAL.UpdateUserFirstName(Id, value))
                    _firstName = value;
            }
        }

        private string _lastName = String.Empty;
        public string LastName
        {
            get
            {
                User user = DAL.UserDAL.GetUserById(Id);
                if (user == null)
                    return _lastName;
                return user.LastName;
            }
            set
            {
                if (DAL.UserDAL.UpdateUserLastName(Id, value))
                    _lastName = value;
            }
        }

        private string _password = String.Empty;
        public string Password
        {
            get
            {
                User user = DAL.UserDAL.GetUserById(Id);
                if (user == null)
                    return _password;
                return user.Password;
            }
            set
            {
                if (DAL.UserDAL.UpdateUserPassword(Id, value))
                    _password = value;
            }
        }

        private bool _isAdmin = false;
        public bool IsAdmin
        {
            get
            {
                User user = DAL.UserDAL.GetUserById(Id);
                if (user == null)
                    return _isAdmin;
                return user.IsAdmin;
            }
            set
            {
                if (DAL.UserDAL.UpdateAdminState(Id, value))
                    _isAdmin = value;
            }
        }

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
