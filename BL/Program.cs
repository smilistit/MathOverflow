using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    class Program
    {
        public static void Main()
        {
            try
            {
                TestUserBL();

                TestQuestionBL();

                TestAnswerBL();
            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an exception:\n" + ex.Message);
                if (ex.InnerException.InnerException != null)
                    Console.WriteLine("Inner exception:\n" + ex.InnerException.InnerException.Message);
            }
        }


        private static void TestUserBL()
        {

            #region create users
            UserBL u1 = new UserBL("username" + (new Random().Next()), "123456");
            // u1 should be created
            if (UserBL.UserBlValid(u1))
                Console.WriteLine("Valid: u1 was created.");
            else
                Console.WriteLine("ERROR: Couldn't create u1.");
            
            UserBL u2 = new UserBL(u1, u1.Username);
            // u2 should be created with an invalid username (same as u1)
            if (UserBL.UserBlValid(u2))
                Console.WriteLine("Valid: u2 was created.");
            else
                Console.WriteLine("ERROR: Couldn't create u2.");

            // change u2's username
            if (u2.SetUsername("username" + (new Random().Next())))
                Console.WriteLine("Valid: u2's username has been set to 'username' followed by a random number.");
            else
                Console.WriteLine("ERROR: There was an error when trying to change u2's username to 'username' followed by a random number.");
            #endregion


            #region upload users to DB
            // u1 should be uploaded
            if (u1.UploadUserToDB())
                Console.WriteLine("Valid: u1 was uploaded to the DB.");
            else
                Console.WriteLine("ERROR: Couldn't upload u1 to the DB.");
            // u2's should be uploaded
            if (u2.UploadUserToDB())
                Console.WriteLine("Valid: u2 was uploaded to the DB.");
            else
                Console.WriteLine("ERROR: Couldn't upload u2 to the DB.");
            #endregion

            
            #region GetUserId
            Console.WriteLine("Info: u1.Username = " + u1.Username);
            Console.WriteLine("Info: u2.Username = " + u2.Username);

            int u1Id = UserBL.GetUserIdByUsername(u1.Username);
            int u2Id = UserBL.GetUserIdByUsername(u2.Username);
            Console.WriteLine("Info: u1.Id = " + u1Id);
            Console.WriteLine("Info: u2.Id = " + u2Id);
            #endregion


            #region GetUserByUserName
            UserBL u1ByUsername = UserBL.GetUserBlByUsername(u1.Username);
            UserBL u2ByUsername = UserBL.GetUserBlByUsername(u2.Username);

            // if they are the same user
            if (u1.Equals(u1ByUsername))
                Console.WriteLine("Valid: The users u1 and u1ByUsername are equal (has the same Id).");
            else
                Console.WriteLine("ERROR: The users u1 and u1ByUsername aren't equal.");

            // if they are the same user
            if (u2.Equals(u2ByUsername))
                Console.WriteLine("Valid: The users u2 and u2ByUsername are equal (has the same Id).");
            else
                Console.WriteLine("ERROR: The users u2 and u2ByUsername aren't equal.");
            #endregion


            #region AuthenticateUser
            // the correct information
            if (UserBL.AuthenticateUser(u1.Username, u1.Password))
                Console.WriteLine("Valid: u1's username and password are correct.");
            else
                Console.WriteLine("ERROR: u1's username and password are incorrect.");

            // incorrect password
            if (UserBL.AuthenticateUser(u2.Username, "1"))
                Console.WriteLine("ERROR: u2's password is incorrect, and yet it logged in.");
            else
                Console.WriteLine("Valid: u2's password is incorrect, and it didn't log in.");

            // user does not exist
            if (UserBL.AuthenticateUser("kjshgmj", u2.Password))
                Console.WriteLine("ERROR: the user does not exist yet it logged in.");
            else
                Console.WriteLine("Valid: the user does not exist and it didn't log in.");
            #endregion


            #region ChangeFirstName
            Console.WriteLine("Info: Before changing the first name:\n\tu1.FirstName = " + (String.IsNullOrEmpty(u1.FirstName)?"Empty":u1.FirstName));
            // change the first name to 'firstName' followed by a random number
            u1.FirstName = "firstName" + (new Random().Next());
            if (String.IsNullOrEmpty(u1.FirstName))
                Console.WriteLine("ERROR: u1's first name didn't update. u1.FirstName = Empty");
            else
                Console.WriteLine("Valid: u1's first name was updated. u1.FirstName = " + u1.FirstName);
            #endregion


            #region ChangeLastName
            Console.WriteLine("Info: Before changing the last name:\n\tu1.LastName = " + (String.IsNullOrEmpty(u1.LastName)?"Empty":u1.LastName));
            // change the last name to 'lastName' followed by a random number
            u1.LastName = "lastName" + (new Random().Next());
            if (String.IsNullOrEmpty(u1.LastName))
                Console.WriteLine("ERROR: u1's last name didn't update. u1.LastName = Empty");
            else
                Console.WriteLine("Valid: u1's last name was updated. u1.LastName = " + u1.LastName);
            #endregion


            #region ChangePassword
            Console.WriteLine("Info: Before changing the password:\n\tu1.Password = " + (String.IsNullOrEmpty(u1.Password)?"Empty":u1.Password));
            // change the password to 'password' followed by a random number
            u1.Password = "password" + (new Random().Next());
            if (String.IsNullOrEmpty(u1.Password))
                Console.WriteLine("ERROR: u1's password didn't update. u1.Password = Empty");
            else
                Console.WriteLine("Valid: u1's password was updated. u1.Password = " + u1.Password);
            #endregion


            #region GetTotalRate
            Console.WriteLine("Info: Total questions rate for u1: " + u1.MyQuestionsRate);
            Console.WriteLine("Info: Total questions rate for u2: " + u2.MyQuestionsRate);
            Console.WriteLine("Info: Total answers rate for u1: " + u1.MyAnswersRate);
            Console.WriteLine("Info: Total answers rate for u2: " + u2.MyAnswersRate);
            Console.WriteLine("Info: Total questions and answers rate for u1: " + u1.GetTotalQuestionsAndAnswersRatePerUser());
            Console.WriteLine("Info: Total questions and answers rate for u2: " + u2.GetTotalQuestionsAndAnswersRatePerUser());
            #endregion
        }


        private static void TestQuestionBL()
        {
            try
            {
                #region create questions
                UserBL u1 = new UserBL("username" + (new Random().Next()), "654321");
                u1.UploadUserToDB();
                string q1Header = "Some Combinatorics Header";
                QuestionBL q1 = new QuestionBL("Combinatorics", q1Header, "Some combinatorics question body", u1.Username);
                // q1 should be created
                if (QuestionBL.QuestionBlValid(q1))
                    Console.WriteLine("Valid: q1 was created.");
                else
                    Console.WriteLine("ERROR: Couldn't create q1.");

                string q2Header = "Some Geometry Header";
                QuestionBL q2 = new QuestionBL("Geometry", q2Header, "Some geometry question body", "khjdhgnlvoe");
                // q2's username is invalid
                if (QuestionBL.QuestionBlValid(q2))
                    Console.WriteLine("ERROR: q2 is valid though the username does not exist.");
                else
                    Console.WriteLine("Valid: q2 is invalid, since the username does not exist.");
                #endregion


                #region setUsername
                // set the q2's username
                if (q2.SetUsername(u1.Username))
                    Console.WriteLine("Valid: q2's username was updated to u1's username.");
                else
                    Console.WriteLine("ERROR: Couldn't update q2's username to u1's username.");
                #endregion


                #region UploadQuestionToDB
                // q1 should be uploaded
                if (q1.UploadQuestionToDB())
                    Console.WriteLine("Valid: q1 was uploaded to the DB.");
                else
                    Console.WriteLine("ERROR: Couldn't upload q1 to the DB.");

                int uId = UserBL.GetUserIdByUsername(q2.Username);
                // upload a question with only values (in this case - q2)
                if (QuestionBL.UploadQuestionToDB(q2.Category, q2.Header, q2.Body, uId))
                    Console.WriteLine("Valid: q2 was uploaded to the DB.");
                else
                    Console.WriteLine("ERROR: Couldn't upload q2 to the DB.");
                #endregion


                #region lastMonthQuestions
                List<QuestionBL> lastMonthQuestions = QuestionBL.GetLastQuestions();
                Console.WriteLine("The last month's questions are:");
                foreach(QuestionBL q in lastMonthQuestions)
                {
                    Console.WriteLine("Header: " + q.Header);
                    Console.WriteLine("Body: " + q.Body);
                    Console.WriteLine("Upload Date: " + q.UploadDate);
                }
                #endregion


                #region GetQuestionsByHeader
                List<QuestionBL> questionsByHeader = QuestionBL.GetQuestionsByHeader(q1Header);
                Console.WriteLine("All of the questions with the header: \"" + q1Header + "\" are:");
                foreach (QuestionBL q in questionsByHeader)
                {
                    Console.WriteLine("Header: " + q.Header);
                    Console.WriteLine("Body: " + q.Body);
                    Console.WriteLine("Upload Date: " + q.UploadDate);
                }
                #endregion

                #region GetQuestionsByHeader - Substring
                List<QuestionBL> questionsByHeaderSubstring = QuestionBL.GetQuestionsByHeader(q1Header.Substring(3));
                Console.WriteLine("All of the questions with the header: \"" + q1Header.Substring(3) + "\" are:");
                foreach (QuestionBL q in questionsByHeaderSubstring)
                {
                    Console.WriteLine("Header: " + q.Header);
                    Console.WriteLine("Body: " + q.Body);
                    Console.WriteLine("Upload Date: " + q.UploadDate);
                }
                #endregion


                #region GetQuestionsByUserName
                List<QuestionBL> questionsByUsername = QuestionBL.GetQuestionsByUsername(q1.Username);
                Console.WriteLine("All of the questions of the username \"" + q1.Username + "\" are:");
                foreach (QuestionBL q in questionsByUsername)
                {
                    Console.WriteLine("Username: " + q.Username);
                    Console.WriteLine("Header: " + q.Header);
                    Console.WriteLine("Body: " + q.Body);
                    Console.WriteLine("Upload Date: " + q.UploadDate);
                }
                #endregion


                #region GetQuestionsByDates
                List<QuestionBL> questionsByDates = QuestionBL.GetQuestionsByDates(DateTime.Now.AddDays(-7), DateTime.Now);
                Console.WriteLine("All of the questions from the past week are:");
                foreach (QuestionBL q in questionsByDates)
                {
                    Console.WriteLine("Header: " + q.Header);
                    Console.WriteLine("Body: " + q.Body);
                    Console.WriteLine("Upload Date: " + q.UploadDate);
                }
                #endregion


                #region GetQuestionsCategory
                List<QuestionBL> questionsByCategory = QuestionBL.GetQuestionsByCategory("Combinatorics");
                Console.WriteLine("All of the questions with the 'Combinatorics' category are:");
                foreach (QuestionBL q in questionsByCategory)
                {
                    Console.WriteLine("Cagetory: " + q.Category);
                    Console.WriteLine("Header: " + q.Header);
                    Console.WriteLine("Body: " + q.Body);
                    Console.WriteLine("Upload Date: " + q.UploadDate);
                }
                #endregion


                #region UpdateQuestionRate
                Console.WriteLine("Info: q1's current rate is: " + q1.Rate);
                // q1 should be updated
                if (q1.UpdateQuestionRate(23))
                    Console.WriteLine("Valid: q1's rate was updated to:" + q1.Rate);
                else
                    Console.WriteLine("ERROR: q1's rate wasn't updated to 23.");
                #endregion


                #region LockQuestion
                Console.WriteLine("Info: q1 is currently unlocked.");
                UserAdmin admin = new UserAdmin("username" + (new Random().Next()), "111111");
                // q1 lock state should be updated
                if (q1.LockQuestion(admin))
                    Console.WriteLine("Valid: q1 is now locked");
                else
                    Console.WriteLine("ERROR: q1 couldn't be locked.");
                #endregion


                #region UnlockQuestion
                Console.WriteLine("Info: q1 is currently locked.");
                // q1 lock state should be updated
                if (q1.UnlockQuestion(admin))
                    Console.WriteLine("Valid: q1 is now unlocked");
                else
                    Console.WriteLine("ERROR: q1 couldn't unlocked.");
                #endregion
            }
            catch(Exception ex)
            {
                Console.WriteLine("There was an exception:\n" + ex.Message);
                if (ex.InnerException.InnerException != null)
                    Console.WriteLine("Inner exception:\n" + ex.InnerException.InnerException.Message);
            }
        }


        private static void TestAnswerBL()
        {
            try
            {
                #region create answers
                UserBL u1 = new UserBL("username" + (new Random().Next()), "654321");
                u1.UploadUserToDB();
                QuestionBL q1 = new QuestionBL("Combinatorics", "Some Combinatorics Header", "Some combinatorics question body", u1.Username);
                q1.UploadQuestionToDB();
                AnswerBL a1 = new AnswerBL(q1.Id, "Some answer's body", u1.Username);
                // a1 should be created
                if (AnswerBL.AnswerBlValid(a1))
                    Console.WriteLine("Valid: a1 was created.");
                else
                    Console.WriteLine("ERROR: Couldn't create a1.");

                AnswerBL a2 = new AnswerBL(-1, "Some answer's body", u1.Username);
                // a2's questionId is invalid
                if (AnswerBL.AnswerBlValid(a2))
                    Console.WriteLine("ERROR: a2 is valid though the question ID isn't valid.");
                else
                    Console.WriteLine("Valid: a2 is invalid, since the question ID is valid.");

                // a3's username is invalid
                AnswerBL a3 = new AnswerBL(q1.Id, "Some answer's body", "jkhefrnlv");
                if (AnswerBL.AnswerBlValid(a3))
                    Console.WriteLine("ERROR: a3 is valid though the username does not exist.");
                else
                    Console.WriteLine("Valid: a3 is invalid, since the username does not exist.");
                #endregion


                #region SetQuestionId
                // set a2's question Id
                if (a2.SetQuestionId(q1.Id))
                    Console.WriteLine("Valid: a2's question Id was updated to q1's Id.");
                else
                    Console.WriteLine("ERROR: Couldn't update a2's questionId to q1's Id.");
                #endregion


                #region setUsername
                // set a3's username
                if (a3.SetUsername(u1.Username))
                    Console.WriteLine("Valid: a3's username was updated to u1's username.");
                else
                    Console.WriteLine("ERROR: Couldn't update a3's username to u1's username.");
                #endregion


                #region UploadQuestionToDB
                // a1 should be uploaded
                if (a1.UploadAnswerToDB())
                    Console.WriteLine("Valid: a1 was uploaded to the DB.");
                else
                    Console.WriteLine("ERROR: Couldn't upload a1 to the DB.");

                // a2 should be uploaded
                if (a2.UploadAnswerToDB())
                    Console.WriteLine("Valid: a2 was uploaded to the DB.");
                else
                    Console.WriteLine("ERROR: Couldn't upload a2 to the DB.");

                int uId = UserBL.GetUserIdByUsername(a3.Username);
                // upload an answer with only values (in this case - a3)
                if (AnswerBL.UploadAnswerToDB(a3.Body, q1.Id, uId))
                    Console.WriteLine("Valid: a3 was uploaded to the DB.");
                else
                    Console.WriteLine("ERROR: Couldn't upload a3 to the DB.");
                #endregion


                #region GetAnswersByQuestionId
                List<AnswerBL> answersByQuestionId = AnswerBL.GetAnswersByQuestionId(q1.Id);
                Console.WriteLine("All of the answers with the questionId: " + q1.Id + " (which is q1's Id) are:");
                foreach (AnswerBL a in answersByQuestionId)
                {
                    Console.WriteLine("Username: " + a.Username);
                    Console.WriteLine("Body: " + a.Body);
                    Console.WriteLine("Upload Date: " + a.UploadDate);
                }
                #endregion


                #region GetAnswersByUserName
                List<AnswerBL> answersByUsername = AnswerBL.GetAnswersByUserName(u1.Username);
                Console.WriteLine("Info: u1.Username = " + u1.Username);
                Console.WriteLine("All of the answers of the username \"" + u1.Username + "\" are:");
                foreach (AnswerBL a in answersByUsername)
                {
                    Console.WriteLine("AnswerId: " + a.Id);
                    Console.WriteLine("Body: " + a.Body);
                    Console.WriteLine("Upload Date: " + a.UploadDate);
                }
                #endregion


                #region UpdateAnswerRate
                Console.WriteLine("Info: a1's current rate is: " + a1.Rate);
                // a1 should be updated
                if (a1.UpdateAnswerRate(23))
                    Console.WriteLine("Valid: a1's rate was updated to:" + a1.Rate);
                else
                    Console.WriteLine("ERROR: a1's rate wasn't updated to 23.");
                #endregion
            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an exception:\n" + ex.Message);
                if (ex.InnerException.InnerException != null)
                    Console.WriteLine("Inner exception:\n" + ex.InnerException.InnerException.Message);
            }
        }

    }
}
