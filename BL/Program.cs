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
                //TestUserBL();

                TestQuestionBL();
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
                List<QuestionBL> questionsByHeader = QuestionBL.GetQuestionsByHeader(q1Header); // TODO: we should make sure it finds a substring as well
                Console.WriteLine("All of the questions with the header: \"" + q1Header + "\" are:");
                foreach (QuestionBL q in questionsByHeader)
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

    }
}
