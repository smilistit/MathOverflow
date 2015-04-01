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
    public partial class AdminManagementWindow : Window
    {
        //public struct UserManagement
        //{
        //    public int ID { set; get; }
        //    public bool IsChecked { set; get; }
        //    public string UserName { set; get; }
        //    public string FirstName { set; get; }
        //    public string LastName { set; get; }
        //    public bool IsAdmin { set; get; }
        //}


        public struct DissucsionManagement
        {
            public int ID { set; get; }
            public bool IsChecked { set; get; }
            public string DissucsionHeader { set; get; }
            public bool IsLocked { set; get; }
        }

        public AdminManagementWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

        }
        //on page load 

        private void textBoxSearchUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
            string serachByUserName = textBoxSearchUsername.Text;

            if (!string.IsNullOrWhiteSpace(serachByUserName))
            {
                this.dataGridUserManage.Items.Clear();// clear previoues serach results

                //List<User> users = BL.UserBL.GetUsersByUserName(serachByUserName);

                //set users in the grid
                //foreach(UserBL user in users)
                //{
                //    this.dataGridUserManage.Items.Add(user);
                //}
            }
        }

        private void buttonSaveDiscussion_Click(object sender, RoutedEventArgs e)
        {
            //DataGridCheckBoxColumn.
        }
    }
}
