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
using PL;

namespace PL
{
    /// <summary>
    /// 
    /// </summary>
    public partial class MainWindow : Window
    {
        public struct MainGrid
        {
            public int ID { set; get; }
            public int Rate { set; get; }
            public string QuestionHeader { set; get; }
            public string QuestionContent { set; get; }
        }

        private UserProfileWindow userProfileWindow;

        public MainWindow()
        {
            InitializeComponent();

            this.labelLogout.Visibility = Visibility.Hidden;
          

            userProfileWindow = new UserProfileWindow();


            string qTitle1 = @"Expression for the derivative of Eisenstein series G2";
            string qContent1 = @"we know G′2=a0+a1G2+a2G22where a0, a1 and a2 are modular forms of level Γ(1)=SL2(Z).Can you please
tell me the expressions of a0, a1 and a2?";

            string qTitle2 = @"Reference request: Deligne's conjecture (cycles)";
            string qContent2 = @"In which work (articles) Deligne shows this conjecture?
Is there some book (or expository article) about this conjecture and its connections with Tate and Hodge conjectures?";

            string qTitle3 = @"Infinite amenable group subfactors";
            string qContent3 = @"Let amenable groups Γ and Γ′. They act outerly of only one manner on the hyperfinite II1-factor R.
Question: (R⊂R⋊Γ)≃(R⊂R⋊Γ′)⇒Γ≃Γ′ ?
RΓ=C (see comments of this answer), so (RΓ⊂R) can't be the dual of (R⊂R⋊Γ).
Let the infinite amenable group Γ=⋃iGi with (Gi)i an increasing sequence of finite groups.
Now, (RGi⊂R) is the dual of (R⊂R⋊Gi) and (R⊂⋃iR⋊Gi)≃(R⊂R⋊Γ).
Question: How to characterize the subfactor (Q⊂R) for being the dual of (R⊂R⋊Γ)?
(If I'm not mistaken ⋂iRGi=RΓ, so we can't take Q=⋂iRGi). Thanks!";

            string qTitle4 = @"Name of a generalized version of semi-continuity";
            string qContent4 = @"I have recently made use of the following generalization of a continuous function, which seems
simple enough it ought to have been used before, but I cannot find any references.
We will say a function f has a semi-continuity property if f−1(U) contains a non-empty open set whenever U is a 
non-empty open set. Is this a studied property? If f:X→Y and Y is disconnected, then this disagrees with usual continuity
but does provide some nice properties. For instance, if D is a dense set, then f(D) is dense."; 


            string qTitle5 = @"Double Markovity";
            string qContent5 = @"Suppose we have a double Markov relation for three random variables X, Y and W as follows
X→W→Y, and X→Y→W.How to prove that there exist functions f and g such that X→f(Y)→Y,W and Pr(f(Y)=g(W))=1?";

            this.questionsDataGrid.Items.Add(new MainGrid { Rate = 11, QuestionHeader = qTitle1, QuestionContent = qContent1 });
            this.questionsDataGrid.Items.Add(new MainGrid { Rate = 5, QuestionHeader = qTitle2, QuestionContent = qContent2 });
            this.questionsDataGrid.Items.Add(new MainGrid { Rate = 0, QuestionHeader = qTitle3, QuestionContent = qContent3 });
            this.questionsDataGrid.Items.Add(new MainGrid { Rate = 23, QuestionHeader = qTitle4, QuestionContent = qContent4 });
            this.questionsDataGrid.Items.Add(new MainGrid { Rate = 2, QuestionHeader = qTitle5, QuestionContent = qContent5 });
        }

        //Login
        private void HyperlinkLogin_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWin = new LoginWindow();
            loginWin.Show();
        }

        //Sign Up
        private void HyperlinkSignUp_Click(object sender, RoutedEventArgs e)
        {         
            SetUserProfileWindowByState(true);
            this.userProfileWindow.Show();
        }

        //log Out
        private void HyperlinkLogOut_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void HyperlinkAdvancedSearch_Click(object sender, RoutedEventArgs e)
        {
            AdvancedSearchWindow advancedSearchWin = new AdvancedSearchWindow();
            advancedSearchWin.Show();
        }

        private void HyperlinkAdminManage_Click(object sender, RoutedEventArgs e)
        {
            AdminManagementWindow adminManagementWin = new AdminManagementWindow();
            adminManagementWin.Show();
        }

        private void HyperlinkProfile_Click(object sender, RoutedEventArgs e)
        {
            SetUserProfileWindowByState(false);
            this.userProfileWindow.Show();
        }

        private void questionsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
     
        private void SetUserProfileWindowByState(bool isNewUser)
        {
            if (isNewUser)
            {               
                this.userProfileWindow.tabUserQuestions.IsEnabled = false;
                this.userProfileWindow.tabUserAnswers.IsEnabled = false;
                this.userProfileWindow.textBoxUsername.IsEnabled = true;
                this.userProfileWindow.usernameTooltipImage.IsEnabled = true;
                this.userProfileWindow.passwordTooltipImage.IsEnabled = true;

                this.userProfileWindow.usernameTooltipImage.Visibility = Visibility.Visible;
            }
            else
            {
                this.userProfileWindow.tabUserQuestions.IsEnabled = true;
                this.userProfileWindow.tabUserAnswers.IsEnabled = true;
                this.userProfileWindow.textBoxUsername.IsEnabled = false;
                this.userProfileWindow.usernameTooltipImage.Visibility = Visibility.Hidden;
            }
        }
    }
}
