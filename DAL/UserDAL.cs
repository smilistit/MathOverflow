using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public static class UserDAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="password"></param>
        /// <param name="isAdmin"></param>
        /// <returns></returns>
        public static int CreateUser(string username, string firstName, string lastName, string password, bool isAdmin = false)
        {
            using (var db = new DAL.MathOverFlowContext())
            {
                // if the username already exist
                if (!ValidateUniqueUserName(username))
                    return -1;
                User user = new User { UserName = username, FirstName = firstName, LastName = lastName, Password = password, IsAdmin = isAdmin };
                db.Users.Add(user);
                db.SaveChanges();
                return user.Id;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static User GetUserByUsername(string username)
        {
            using (var db = new MathOverFlowContext())
            {
                User user = db.Users.Where(x => x.UserName == username).FirstOrDefault();
                return user;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>True if the username and password are correct</returns>
        public static bool AuthenticateUser(string username, string password)
        {
            using (var db = new MathOverFlowContext())
            {
                User user = db.Users.Where(x => x.UserName == username && x.Password == password).FirstOrDefault();
                if (user == null)
                    return false;
                return true;
            }
        }

        public static List<User> GetAllUsersByUsername(string username) // TODO: What is it used for? The username is unique so there can't be many of them
        {
            List<User> userList = new List<User>();

            using (var db = new MathOverFlowContext())
            {
                userList = (from u in db.Users
                            where u.UserName == username
                            select u).ToList<User>();
            }

            return userList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="firstName"></param>
        /// <returns></returns>
        public static bool UpdateUserFirstName(int userId, string firstName)
        {

            using (var db = new MathOverFlowContext())
            {
                User user = db.Users.Find(userId);

                if (user == null)
                    return false;

                user.FirstName = firstName;
                db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public static bool UpdateUserLastName(int userId, string lastName)
        {

            using (var db = new MathOverFlowContext())
            {
                User user = db.Users.Find(userId);

                if (user == null)
                    return false;

                user.LastName = lastName;
                db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool UpdateUserPassword(int userId, string password)
        {
            using (var db = new MathOverFlowContext())
            {
                User user = db.Users.Find(userId);

                if (user == null)
                    return false;

                user.Password = password;
                db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public static bool UpdateAdminState(int userId, bool state)
        {
            using (var db = new MathOverFlowContext())
            {
                User user = db.Users.Find(userId);
                if (user == null)
                    return false;
                user.IsAdmin = state;
                db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
        }

        public static int GetQuestionRatePerUser(int questionId) // TODO: why is it on the UserDAL class? shouldn't it move to QuestionDAL?
        {
            using (var db = new MathOverFlowContext())
            {
                Question question = db.Questions.Find(questionId);

                if (question == null)
                    return -1;

                return question.Rate;
            }
        }

        public static int GetAnswerRatePerUser(int answerId) // TODO: why is it on the UserDAL class? shouldn't it move to AnswerDAL?
        {
            using (var db = new MathOverFlowContext())
            {
                Answer answer = db.Answers.Find(answerId);

                if (answer == null)
                    return -1;

                return answer.Rate;
            }
        }

        public static int GetSpecificQuestionAndAnswerRate(int questionId, int answerId) // TODO: not really sure what's it's for. I think is should be deleted
        {
            using (var db = new MathOverFlowContext())
            {
                Question question = db.Questions.Find(questionId);
                Answer answer = db.Answers.Find(answerId);

                if (question == null || answer == null)
                    return -1;

                return question.Rate + answer.Rate;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static int GetTotalQuestionsRate(int userId)
        {
            using (var db = new MathOverFlowContext())
            {
                // get a list of all of the user's questions
                var allRelevantQuestions = db.Questions.Where(q => q.UserId == userId);
                int rateCount = 0;
                // count all of the user's questions' rate
                foreach (var question in allRelevantQuestions)
                {
                    rateCount += question.Rate;
                }
                return rateCount;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static int GetTotalAnswersRate(int userId)
        {
            using (var db = new MathOverFlowContext())
            {
                // get a list of all of the user's answers
                var allRelevantAnswers = db.Answers.Where(q => q.UserId == userId);
                int rateCount = 0;
                // count all of the user's answer's rate
                foreach (var answer in allRelevantAnswers)
                {
                    rateCount += answer.Rate;
                }
                return rateCount;
            }
        }

        /// <summary>
        /// Return true if the username is unique, false otherwise
        /// </summary>
        /// <param name="username"></param>
        /// <returns>True if the username is unique, false otherwise</returns>
        public static bool ValidateUniqueUserName(string username)
        {
            using (var db = new MathOverFlowContext())
            {
                User user = db.Users.Where(x => x.UserName == username).FirstOrDefault();

                if (user == null)
                    return true;

                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static int GetUserIdByUserName(string username)
        {
            using (var db = new MathOverFlowContext())
            {
                User user = db.Users.Where(x => x.UserName == username).FirstOrDefault();

                if (user == null)
                    return -1;

                return user.Id;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static User GetUserById(int userId)
        {
            using (var db = new MathOverFlowContext())
            {
                return db.Users.Find(userId);
            }
        }


    }
}
