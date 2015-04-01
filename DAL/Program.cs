using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    class Program
    {
        static void Main(string[] args)
        {
            #region adding some rows to DB
            //using (var db = new MathOverFlowContext())
            //{
            //    try
            //    {
            //        #region add user
            //        User user = new User { UserName = "Yaaronet", FirstName = "Yaara", LastName = "Avivi", Password = "123456", IsAdmin = true };
            //        db.Users.Add(user);
            //        db.SaveChanges();
            //        #endregion

            //        #region add Question
            //        Question question = new Question { Category = "Set Theory", Header = "What is a set?", Body = "Please tell me what is a set.", Rate = 0, IsLocked = false, Date = DateTime.Now, UserId = user.Id };
            //        db.Questions.Add(question);
            //        db.SaveChanges();
            //        #endregion

            //        #region add Answer
            //        Answer answer = new Answer { Body = "A set is a list of unique objects.", Rate = 0, QuestionId = question.Id, UserId = user.Id };
            //        db.Answers.Add(answer);
            //        db.SaveChanges();
            //        #endregion
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //    }
            //}
            #endregion

            #region update some rows in the DB
            //using (var db = new MathOverFlowContext())
            //{
            //    var user2update = db.Users.Find(2);
            //    if (user2update != null)
            //    {
            //        user2update.UserName = "siv";
            //        user2update.FirstName = "Sivan";
            //        user2update.LastName = "Koren";
            //        db.Users.Attach(user2update);
            //        db.Entry(user2update).State = System.Data.Entity.EntityState.Modified;
            //        db.SaveChanges();
            //    }
            //}
            #endregion

            #region update some rows in the DB using query
            ///////UPDAE///// - Too long:(
            //using (var db = new MathOverFlowContext())
            //{
            //    var query = (from u in db.Users
            //                where u.UserName == "siv"
            //                select u);
                
            //    //Execute the query, and change the column values 
            //    foreach (User user in query)
            //    {
            //        user.LastName = "Bond";
            //    }

            //    // Submit the changes to the database. 
            //    try
            //    {
            //        db.SaveChanges();
            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine(e);
            //    }
            //}

            //// This black gets a runtime exception
            ////using (var db = new MathOverFlowContext())
            ////{
            ////    List<Question> qLastMonth = (from q in db.Questions
            ////                                where q.Date > DateTime.Now.AddMonths(-1)
            ////                                select q).ToList<Question>();
            ////}
            #endregion
        }
    }
}
