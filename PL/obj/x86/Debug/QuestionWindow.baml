   M S B A M L   `   `   `  ����  WpfApplication1    PL.QuestionWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Question��5   	   $	��594��6   $	��959��6'   .��5      � $	��572��6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��questionsDataGrid��5   k      AutoGenerateColumns .  $	��265��6/   $
��Left=�6<   $��
16,238,0,0q�6W   $	��Top=�6�   $	��879��6�      Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5      ,  &System.Windows.Controls.DataGridColumn   HeaderTemplate 5	      �� 5
      .R�5      �� $?��9/WpfApplication1;component/Images/Actions-rating-icon.png��6$   $��20��6g   $��20��6s   5         CellTemplate 5      �� 5      .R�5      �� ��6(   �� *Rate+5      5      0  *System.Windows.Controls.DataGridTextColumn  5         Header$ Answer��6%      MinWidth$	 665Q�65   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6D   �� *Answer+6a     5      $ Answered By��6%   $ 95Q�6:    6H   �� *
AnsweredBy+6i     5      $ Rate Answer��6)    5      �� 5      .R�5      �� $��mButtonFixThis��6%   -   5        $��20��5   ;   $��30��6G   .��6r   +16v   5      5      5      �� 5   
   -   5        $��groupBoxTitle��5   \   $��Title��6   $��53��6"   $
��Left=�6.   $��	10,10,0,0q�6I   $	��Top=�6q   $	��781��6�   .��5       ��  �� AcceptsReturn . $��24��6+   	 �� TextWrapping$
	 Wrap=�6s   "
 �� VerticalScrollBarVisibility$

 Auto=�6�   ��67   �� *Notes+ �� UpdateSourceTrigger$ PropertyChanged=�6�   5!      �� 5"   
   -   5        $��groupBoxQuestion��5"   `   $��Question��6   $	��147��6%   $
��Left=�62   $��	12,82,0,0q�6M   $	��Top=�6x   $	��779��6�   .��5#      ��  . $
	 Wrap=�6g   $

 Auto=�6{   $	��756��6�   $	��124��6�   ��6+   �� *Notes+$ PropertyChanged=�6�   5$      �� 5%   
   -   5        $��image1��5%   K   $��61��6   $
��Left=�6   $��
850,12,0,0q�67   $
��Fill=�6Y   $	��Top=�6h   $��62��6�   $?��9/WpfApplication1;component/Images/Actions-rating-icon.png��6�   �� 5&   
   -   5        $��
textBlock1��5&   O   $��17��6   $
��Left=�6    $��
876,35,0,0q�6;   $��13��6a   $	��Top=�6k   $��19��6�   �� 5'   
   -   5        $��buttonClose��5'   ]   $��Close��6   $��23��6!   $
��Left=�6-   $��850,522,0,0q�6H   $	��Top=�6p   $��75��6�   �� 5(   
   -   5        $��buttonAnswer��5(   ^   $��Answer��6   $��23��6"   $
��Left=�6.   $��758,522,0,0q�6I   $	��Top=�6r   $��75��6�   �� 5)   
   -	   5        $��buttonRateQuestion��5)   [   $��+1��6   $��23��6   $��Right=�6*   $��0,522,198,0q�6F   $	��Top=�6u   $��75��6�   5*      5+      