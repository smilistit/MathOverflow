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
using System.Data;


namespace PL
{
    /// <summary>
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class QuestionWindow : Window
    {
        public struct AnswerData
        {
            public int ID { set; get; }
            public int Rate { set; get; }
            public string Answer { set; get; }
            public string AnsweredBy { set; get; }
            public Button RateAnswer { set; get; }  
        }

      

        public QuestionWindow()
        {
            InitializeComponent();



            string answer1 = @"Let H be extraspecial of order p3 and exponent p (for odd p), and T=Cp. Then G=H×T is capable but T is not.We have G=K/Z(K), 
where K=⟨a,b,c,d,e,f∣[a,b]=c,[a,c]=e,[b,c]=f,[a,d]=e,[b,d]=[c,d]=1, ap=bp=dp=1,e,f central⟩.";

            string answer2 = @"The converse is not true in general. ￼Beyl, Felgner and Schmid presented a condition in which the capability of a direct product 
of finitely many of groupsimplies the capability of each of the factors On groups occurring as center factor groups, 
Proposition 6.2. Examples and counterexamples are also given in Remark 2.4 and Example 2.1 here.";

            this.questionsDataGrid.Items.Add(new AnswerData
            {
                Rate = 2,
                Answer = answer1,
                AnsweredBy = "JhonD"
                //RateAnswer = new Button()
            });

            this.questionsDataGrid.Items.Add(new AnswerData 
            {
                Rate = 0,
                Answer = answer2,
                AnsweredBy = "NeilSt" 
            });
            
        }

        private void questionsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ButtonRateAnswer_Click(object sender, RoutedEventArgs e)
        {
            // Do something here
        }
        
    }
}
