   M S B A M L   `   `   `  ����  WpfApplication1    PL.AdminManagementWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Admin Management��5   	   $	��545��6"   $	��810��6/    � 
ResizeMode$ NoResize=�6;   .��5      � $	��509��6   $	��791��6   .+�5   
   �� -   5        $��tabAdminManagmentControl��5   =   $	��511��6   $
��Left=�6"   $	��Top=�6]   $	��800��6u   .@�5      �� -   5        $��tabUserManage��5   /   $��User Management��6   .��5      � .+�5	      &   System.Windows.Controls.DataGrid  -   5        $��dataGridUserManage��5	   v      AutoGenerateColumns .  $	��366��6;   $
��Left=�6H   $��	11,53,0,0q�6c   $	��Top=�6�   $	��767��6�    �� AlternationCount$ 0��6�      CanUserResizeColumns .  � DataContext 6�   ��    Columns 5
      4  .System.Windows.Controls.DataGridCheckBoxColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ V��65      MinWidth$ 30Q�6@   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6O   �� *	IsChecked+6o   0  *System.Windows.Controls.DataGridTextColumn  5      $ UserName��61   $	 218Q�6C   	 6R   �� *
UserName+6q     5      $ 
First Name��61   $	 225Q�6E   	 6T   �� *	FirstName+6t     5      $ 	Last Name��61   $	 225Q�6D   	 6S   �� *
LastName+6r     5      $ 	Is Admin?��65   $ 30Q�6H   	 6V   �� *	IsAdmin+6t   5      �� 5      -   5        $��buttonSaveUser��5   h   $
��Save��6   $��23��6,   $
��Left=�68   $��191,438,0,0q�6S   $	��Top=�6~   $��75��6�   �� 5      -   5        $��buttonRemoveUser��5   o   $��Remove User��6   $��23��63   $
��Left=�6?   $��475,438,0,0q�6Z   $	��Top=�6�   $��85��6�   �� 5      -   5        $��labelSearchUsername��5   t   $��Search by username:��6   $��28��6:   $
��Left=�6F   $��	33,19,0,0q�6a   $	��Top=�6�   �� 5      -   5        $��textBoxSearchUsername��5   Y   $��23��6   $
��Left=�6*   $��
187,21,0,0q�6E   $	��Top=�6v   $	��120��6�   5      5      �� 5      -   5        $��tabDiscussionManage��5   5   $��Discussion Management��6   .��5      � .+�5        -	   5        $��dataGridDiscussion��5   �   $ 0��6    .  $	��366��6h   $
��Left=�6u   $��	11,53,0,0q�6�   $	��Top=�6�   $	��764��6�    6P   ��  5        5      $ V��65   $ 30Q�6@   	 6N   �� *	IsChecked+6n     5      $ Discussion ID��61   $ 40Q�6H   	 6V   �� *ID+6o     5      $ Discussion Header��61   $	 610Q�6L   	 6[   �� *DissucsionHeader+6�   4  .System.Windows.Controls.DataGridTemplateColumn  5   "   
   HeaderTemplate
 5    &   �� 5!   *   .R�5"   .   �� $0��*/WpfApplication1;component/Images/lock.png��64   $��20��6h   $��20��6t   5#   +      CellTemplate 5%   &   �� 5&   *   .R�5'   *   ��  d� 	IsChecked 63   �� *
IsLocked+5(   +   5*   #   5-      �� 5.      -
   5        $��buttonSaveDiscussion��5.   h   $
��Save��6   $��23��6,   $
��Left=�68   $��191,438,0,0q�6S   $	��Top=�6�   $��75��6�   �� 5/      -   5        $��buttonRemoveDiscussion��5/   u   $��Remove Discussion��6   $��23��69   $
��Left=�6E   $��475,438,0,0q�6`   $	��Top=�6�   $	��122��6�   �� 50      -   5        $��labelSearchDiscussion��50   }   $"��Search by discussion header:��6   $��28��6C   $
��Left=�6O   $��	33,19,0,0q�6j   $	��Top=�6�   �� 51      -   5        $��textBoxSearchDiscussion��51   Y   $��23��6   $
��Left=�6*   $��
227,21,0,0q�6E   $	��Top=�6x   $	��120��6�   52      53      54      55      56      