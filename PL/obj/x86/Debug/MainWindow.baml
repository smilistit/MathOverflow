   M S B A M L   `   `   `  ����  WpfApplication1    PL.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  MathOverFlow��5   	   $	��640��6   $
��1071��6+   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��questionsDataGrid��5   k      AutoGenerateColumns .  $	��469��6/   $
��Left=�6<   $��
12,103,0,0q�6W   $	��Top=�6�   $
��1025��6�      Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5      ,  &System.Windows.Controls.DataGridColumn   HeaderTemplate 5	      �� 5
      .R�5      �� $?��9/WpfApplication1;component/Images/Actions-rating-icon.png��6$   $��20��6g   $��20��6s   5         CellTemplate 5      �� 5      .R�5      �� ��6(   �� *Rate+5      5      0  *System.Windows.Controls.DataGridTextColumn  5         Header$ Question Header��6%      MinWidth$	 396Q�6>   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6M   �� *QuestionHeader+6r     5      $ Question Content��6%   $	 515Q�6?    6N   �� *QuestionContent+6t   5      �� 5   
   -   5        $��textBoxSearch��5   M   $��23��6   $
��Left=�6   $��
870,12,0,0q�69   $	��Top=�6b   $	��141��6z   $��Search for a question��6�   �� 5   
   -   5        $��labelLogout��5   1   $��25��6   $��26,32,970,0q�6   $	��Top=�6D   .��5      �� -   5        .�5   6   	Log Out6?   5      �� 5   
   -   5        $��labelSignUp��5   /   $��25��6   $��	82,32,0,0q�6   $	��Top=�6B   $
��Left=�6Z   $��47��6u   {�. $��Normal$�6�   $��Normal"�6�   .��5      �� -   5        .�5   6   SignUp6>   5      �� 5   
   -   5        $��labelAdvancedSearch��5   /   $��25��6   $��	0,41,52,0q�6   $	��Top=�6J   $��Right=�6b   $	��109��6~   .��5       �� -   5        .�5    >   Advanced Search6O   5!      �� 5"   
   -	   5        $��labelAdminManageWin��5"   0   $��25��6   $��
0,27,293,0q�6   $	��Top=�6K   $��Right=�6c   $	��124��6   {�. .��5#      �� -
   5        .�5#   ;   Admin Management6M   5$      �� 5%   
   -   5        $��labelProfileWin��5%   0   $��25��6   $��
0,27,203,0q�6   $	��Top=�6G   $��Right=�6_   $��75��6{   {�. .��5&      �� -   5        .�5&   7   
My Profile6C   5'      �� 5(   
   -   5        $��button1��5(   d   $��Ask a question��6   $��23��6*   $
��Left=�66   $��	26,66,0,0q�6Q   $	��Top=�6s   $	��103��6�   �� 5)   
   -   5        $��label1��5)   `   $��Hello Guest!��6   $��28��6'   $
��Left=�63   $��26,7,0,0q�6N   $	��Top=�6n   $��Italic$�6�   �� 5*   
   -   5        $��image1��5*   K   $��77��6   $
��Left=�6   $��
287,12,0,0q�67   $
��Fill=�6Y   $	��Top=�6h   $	��350��6�   $0��*/WpfApplication1;component/Images/LOGO.JPG��6�   �� 5+   
   -   5        $��image2��5+   L   $��23��6   $
��Left=�6   $��1017,12,0,0q�67   $
��Fill=�6Z   $	��Top=�6i   $��20��6�   $2��,/WpfApplication1;component/Images/search.png��6�   �� 5,   
   -   5        $��
labelLogin��5,   �   $��Normal$�6   $��Normal"�6#   $��25��67   $��Right=�6C   {�. $��
0,32,860,0q�6p   $	��Top=�6�   $��41��6�   .��5-      �� -   5        .�5-   5   LogIn6<   5.      5/      50      