   M S B A M L   `   `   `  ����   WpfApplication1    PL.UserProfileWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     � Title$  User Profile��$	��376��$	��839�� � 
ResizeMode$ NoResize=�.��� $	��340��$	��824��.+��� -   $��tabUserProfileControl��$	��340��$
��Left=�$	��Top=�$	��824��.@��� -   $��tabUserProfile��$��Profile Information��.��� .+��� -   $��groupBoxUsernameAndPass��$��Username and Password��$	��168��$
��Left=�$��	34,44,0,0q�$	��Top=�$	��357��.���  � ColumnDefinitions �� $
��112* ��� $	��43* ��� $
��190* �.+��� -   $��labelUsernameProfile��$��	Username:��$��28��$
��Left=�$��	32,20,0,0q�$	��Top=��� -   $��labelPasswordProfile��$��	Password:��$��28��$
��Left=�$��	32,59,0,0q�$	��Top=��� -   $��textBoxUsername��$��23��$
��Left=�$��6,25,0,0q�$	��Top=�$	��120��{�.  $��2��G� -   $��passwordBoxProfile��$��23��$
��Left=�$��6,62,0,0q�$	��Top=�$	��120��$��2���� -	   $��labelConfirmPass��$��Confirm Password:��$��28��$
��Left=�$��	32,98,0,0q�$	��Top=�$��2��G� -
   $��passwordBoxConfirmPass��$��23��$
��Left=�$��	6,101,0,0q�$	��Top=�$	��120��$��2���� -   $��usernameTooltipImage��$��24��$
��Left=�$��
132,24,0,0q�$8��2/WpfApplication1;component/Images/questionMark.jpg��$
��Fill=� � ToolTip$ Only A-Z, a-z and numbers��$	��Top=�$��25��{�.  $��2���� -   $��passwordTooltipImage��$��24��$
��Left=�$��
132,63,0,0q�$8��2/WpfApplication1;component/Images/questionMark.jpg��$
��Fill=�$: 4Only A-Z, a-z, symbols and numbers. 5-10 characters ��$	��Top=�$��25��{�.  $��2���� -   $��	groupBox1��$
��Name��$	��124��$
��Left=�$��
412,68,0,0q�$	��Top=�$	��357��.��� .+��� -   $��labelFirstName��$��First Name:��$��28��$
��Left=�$��	32,20,0,0q�$	��Top=��� -   $��labelLastName��$��
Last Name:��$��28��$
��Left=�$��	32,59,0,0q�$	��Top=��� -   $��textBoxFirstName��$��23��$
��Left=�$��
161,25,0,0q�$	��Top=�$	��120���� -   $��textBoxLastName��$��23��$
��Left=�$��
161,64,0,0q�$	��Top=�$	��120���� -   $��
buttonSave��$
��Save��$��23��$
��Left=�$��296,250,0,0q�$	��Top=�$��75���� -   $��buttonCancel��$��Cancel��$��23��$
��Left=�$��443,250,0,0q�$	��Top=�$��75���� -   $��tabUserQuestions��$��My Questions��.���  �� $
��Auto ��� $
��557* �.+�&   System.Windows.Controls.DataGrid  -   $��dataGridUserManage��   AutoGenerateColumns .  $	��231��$
��Left=�$��3,53,0,0q�$	��Top=�$	��805�� �� AlternationCount$ 0��$��2�� � DataContext ��    Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn   HeaderTemplate �� .R��� $?��9/WpfApplication1;component/Images/Actions-rating-icon.png��$��20��$��20��	   CellTemplate	 �� .R��� ���� *Rate+0  *System.Windows.Controls.DataGridTextColumn  
   Header$
 Question Header��   MinWidth$	 350Q�1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *QuestionHeader+  $
 Question Content��$	 410Q� �� *QuestionContent+�� -   $��searchMyQuestions��$��23��$
��Left=�$��
403,12,0,0q�$��Search in my questions��$	��Top=�$	��141��$��1���� -   $��label1��$��My Question Rating :��$��28��$��
3,15,134,0q�$	��Top=��� -   $��image1��$��33��$
��Left=�$��
122,10,0,0q�$?��9/WpfApplication1;component/Images/Actions-rating-icon.png��$
��Fill=�$	��Top=�$��30���� -   $��label2��$��5��$��22��$��Right=�$��
0,15,105,0q�$	��Top=�$��16���� -   $��tabUserAnswers��$��
My Answers��.��� .+��� -   $��textBox3��$��23��$
��Left=�$��
659,12,0,0q�$��Search in my answers��$	��Top=�$	��141��  -   $��	dataGrid3��$ 0�� .  $	��233��$
��Left=�$��3,53,0,0q�$	��Top=�$	��805�� ��    	 �� .R��� ���� *Rate+ �� .R��� $��20��$?��9/WpfApplication1;component/Images/Actions-rating-icon.png��$��20��  $
 Answer��$	 760Q� �� *QuestionHeader+�� -   $��label3��$��My Question Rating :��$��28��$��
3,15,698,0q�$	��Top=��� -   $��image3��$��33��$
��Left=�$��
120,10,0,0q�$?��9/WpfApplication1;component/Images/Actions-rating-icon.png��$
��Fill=�$	��Top=�$��30���� -   $��label4��$��0��$��22��$��Right=�$��
0,15,669,0q�$	��Top=�$��16��