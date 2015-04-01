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
using System.Text.RegularExpressions;

namespace PL
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class UserProfileWindow : Window
    {
        public struct MyQuestion
        {
            public int ID { set; get; }
            public int Rate { set; get; }
            public string QuestionHeader { set; get; }
            public string QuestionContent { set; get; }
        }


        private const char FirstHebChar = (char)1488; //א
        private const char LastHebChar = (char)1514; //ת
        
        StringBuilder errors = new StringBuilder();

        public UserProfileWindow()
        {
            InitializeComponent();
            
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;


            this.dataGridUserManage.Items.Add(new MyQuestion
            {
                Rate = 11,
                QuestionHeader = @"Expression for the derivative of Eisenstein series G2",
                QuestionContent = @"we know G′2=a0+a1G2+a2G22where a0, a1 and a2 are modular forms 
of level Γ(1)=SL2(Z).Can you please tell me the expressions of a0, a1 and a2?"              
            });

        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            ValidateWindowDetails();
           
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
     

        private void HyperlinkAdvancedSearch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void tabUserProfileControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void passwordBoxProfile_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void passwordBoxConfirmPass_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void textBoxFirstName_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void textBoxLastName_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            
        }

        
        private bool ValidateWindowDetails()
        {
            Regex fullNameValidator = new Regex(@"[A-Za-z]");

            Regex passwordValidator = new Regex(@"[!\#$%&'()*+,./:;<=>?@\^_`{|}~-A-Za-z0-9]{5,10}");


            //password name
            if (!passwordValidator.IsMatch(this.textBoxLastName.Text))
            {
                MessageBox.Show("No Hebres charachters is allowen in Password field. Please insert valid input.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                this.textBoxLastName.Clear();
            }

            //last name
            if (!fullNameValidator.IsMatch(this.textBoxLastName.Text))
            {
                MessageBox.Show("Last name should contain latin alphabetic values only. Please insert valid input.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                this.textBoxLastName.Clear();
            }

            return true;
        }
            
    }
}
