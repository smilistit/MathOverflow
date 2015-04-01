﻿using System;
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
                testUserBL();

                //QuestionBL question = new QuestionBL("Linear Algebra", "Some Question Header", "Some question body", u1.UserName);
                //question.UploadQuestionToDB();
                //AnswerBL answer = new AnswerBL(question.Id, "some answer body", u2.UserName);
                //answer.UploadAnswerToDB();
            }
            catch(Exception ex)
            {
                Console.WriteLine("There was an exception:\n" + ex.Message);
                if (ex.InnerException.InnerException != null)
                    Console.WriteLine("Inner exception:\n" + ex.InnerException.InnerException.Message);
            }
        }


        private static void testUserBL()
        {

            #region create users
            UserBL u1 = new UserBL("username" + (new Random().Next()), "123456");
            // u1 should be created
            if (u1 == null)
                Console.WriteLine("ERROR: Couldn't create u1.");
            else
                Console.WriteLine("Valid: u1 was created.");
            
            UserBL u2 = new UserBL(u1);
            // u2 should be created
            if (u2 == null)
                Console.WriteLine("ERROR: Couldn't create u2.");
            else
                Console.WriteLine("Valid: u2 was created.");

            // u2's username is invalid, so Id = -1
            if (u2.Id == -1)
                Console.WriteLine("Valid: u2 was created without a username so the username is invalid.");
            else
                Console.WriteLine("ERROR: u2 was created with a valid username, though it shouldn't have a username at all.");

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

            int u1Id = UserBL.GetUserId(u1.Username);
            int u2Id = UserBL.GetUserId(u2.Username);
            Console.WriteLine("Info: u1.Id = " + u1Id);
            Console.WriteLine("Info: u2.Id = " + u2Id);
            #endregion


            #region GetUserByUserName
            UserBL u1ByUsername = UserBL.GetUserByUsername(u1.Username);
            UserBL u2ByUsername = UserBL.GetUserByUsername(u2.Username);

            // if u1.Id == u1ByUsername.Id than it's the same user
            if (u1.Id == u1ByUsername.Id)
                Console.WriteLine("Valid: The users u1 and u1ByUsername are equal (has the same Id).");
            else
                Console.WriteLine("ERROR: The users u1 and u1ByUsername aren't equal.");

            // if u2.Id == u2ByUsername.Id than it's the same user
            if (u2.Id == u2ByUsername.Id)
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
            u1.ChangeFirstName("firstName" + (new Random().Next()));
            if (String.IsNullOrEmpty(u1.FirstName))
                Console.WriteLine("ERROR: u1's first name didn't update. u1.FirstName = Empty");
            else
                Console.WriteLine("Valid: u1's first name was updated. u1.FirstName = " + u1.FirstName);
            #endregion


            #region ChangeLastName
            Console.WriteLine("Info: Before changing the last name:\n\tu1.LastName = " + (String.IsNullOrEmpty(u1.LastName)?"Empty":u1.LastName));
            // change the last name to 'lastName' followed by a random number
            u1.ChangeFirstName("lastName" + (new Random().Next()));
            if (String.IsNullOrEmpty(u1.LastName))
                Console.WriteLine("ERROR: u1's last name didn't update. u1.LastName = Empty");
            else
                Console.WriteLine("Valid: u1's last name was updated. u1.LastName = " + u1.LastName);
            #endregion


            #region ChangePassword
            Console.WriteLine("Info: Before changing the password:\n\tu1.Password = " + (String.IsNullOrEmpty(u1.Password)?"Empty":u1.Password));
            // change the password to 'password' followed by a random number
            u1.ChangeFirstName("password" + (new Random().Next()));
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
    }
}