   M S B A M L   `   `   `  ����   WpfApplication1    PL.AdminManagementWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  Admin Management��$	��545��$	��810�� � 
ResizeMode$ NoResize=�.��� $	��509��$	��791��.+��� -   $��tabAdminManagmentControl��$	��511��$
��Left=�$	��Top=�$	��800��.@��� -   $��tabUserManage��$��User Management��.��� .+�&   System.Windows.Controls.DataGrid  -   $��dataGridUserManage��   AutoGenerateColumns .  $	��366��$
��Left=�$��	11,53,0,0q�$	��Top=�$	��767�� �� AlternationCount$ 0��   CanUserResizeColumns .  � DataContext ��    Columns 4  .System.Windows.Controls.DataGridCheckBoxColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ V��   MinWidth$ 30Q�1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 �� *	IsChecked+0  *System.Windows.Controls.DataGridTextColumn  $ UserName��$	 218Q�	 �� *
UserName+  $ 
First Name��$	 225Q�	 �� *	FirstName+  $ 	Last Name��$	 225Q�	 �� *
LastName+  $ 	Is Admin?��$ 30Q�	 �� *	IsAdmin+�� -   $��buttonSaveUser��$
��Save��$��23��$
��Left=�$��191,438,0,0q�$	��Top=�$��75���� -   $��buttonRemoveUser��$��Remove User��$��23��$
��Left=�$��475,438,0,0q�$	��Top=�$��85���� -   $��labelSearchUsername��$��Search by username:��$��28��$
��Left=�$��	33,19,0,0q�$	��Top=��� -   $��textBoxSearchUsername��$��23��$
��Left=�$��
187,21,0,0q�$	��Top=�$	��120���� -   $��tabDiscussionManage��$��Discussion Management��.��� .+�  -	   $��dataGridDiscussion��$ 0�� .  $	��366��$
��Left=�$��	11,53,0,0q�$	��Top=�$	��764�� ��    $ V��$ 30Q�	 �� *	IsChecked+  $ Discussion ID��$ 40Q�	 �� *ID+  $ Discussion Header��$	 610Q�	 �� *DissucsionHeader+4  .System.Windows.Controls.DataGridTemplateColumn  
   HeaderTemplate
 �� .R��� $0��*/WpfApplication1;component/Images/lock.png��$��20��$��20��   CellTemplate �� .R���  d� 	IsChecked �� *
IsLocked+�� -
   $��buttonSaveDiscussion��$
��Save��$��23��$
��Left=�$��191,438,0,0q�$	��Top=�$��75���� -   $��buttonRemoveDiscussion��$��Remove Discussion��$��23��$
��Left=�$��475,438,0,0q�$	��Top=�$	��122���� -   $��labelSearchDiscussion��$"��Search by discussion header:��$��28��$
��Left=�$��	33,19,0,0q�$	��Top=��� -   $��textBoxSearchDiscussion��$��23��$
��Left=�$��
227,21,0,0q�$	��Top=�$	��120��