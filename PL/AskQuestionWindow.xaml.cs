using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BL;

namespace PL
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AskQuestionWindow : Window
    {
        public AskQuestionWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSubmit_Click(object sender, RoutedEventArgs e)
        {
            string qHeader = questionHeader.Text;
            string qBody = questionBody.Text;
            string qCatagory = comboBoxCatagory.Text;
            CurrentUser currUser = CurrentUser.GetCurrentUserInstance();
            if (currUser == null)
            {
                // open err msg - the user does not exist
                MessageBox.Show("System error. Please try again later.", "Ask a Question - System Error #1#", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            // no header
            else if (String.IsNullOrWhiteSpace(qHeader))
            {
                // open err msg - the header is empty
                MessageBox.Show("The question's header cannot be empty!", "Ask a Question - Empty Header", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            // no body
            else if (String.IsNullOrWhiteSpace(qBody))
            {
                // open err msg - the body is empty
                MessageBox.Show("The question's body cannot be empty!", "Ask a Question - Empty Body", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            // the fields are valid
            else
            {
                // Yaara: I've commented out lines 59 and 66 (and replaced it witht he line 67) since I've changed the method to static and it didn't compile
                //QuestionBL question = new QuestionBL(qCatagory, qHeader, qBody, currUser.CurrUserName);

                int currUserId = CurrentUser.GetUserID(currUser.CurrUserName);

                if (currUserId >= 0)
                {
                    // try to upload the question to DB, and make sure it uploaded
                    //if (!question.UploadQuestionToDB(qCatagory, qHeader, qBody, currUserId))
                    if (!QuestionBL.UploadQuestionToDB(qCatagory, qHeader, qBody, currUserId))
                    {
                        // open err msg - the question didn't upload
                        MessageBox.Show("There was an internal error and the question couldn't upload.\nPlease try again", "Ask a Question - Couldn't Upload Question", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                // if there was an error creating the question
                else
                {
                    // open SYSTEM err msg that the question didn't upload
                    MessageBox.Show("System error. Please try again later.", "Ask a Question - System Error #2#", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            // close the application?!
            System.Windows.Application.Current.Shutdown();
        }

        /// <summary>
        /// Happens when clicking the window's red x
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // do the same as the cancel button
            buttonCancel_Click(null, new RoutedEventArgs());
        }


    }
}
