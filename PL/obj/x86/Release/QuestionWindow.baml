   M S B A M L   `   `   `  ����   PL    PL.QuestionWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  Question��$	��594��$	��959��.��� $	��572��.+�&   System.Windows.Controls.DataGrid  -   $��questionsDataGrid��   AutoGenerateColumns .  $	��265��$
��Left=�$��
16,238,0,0q�$	��Top=�$	��879��   Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn   HeaderTemplate �� .R��� $?��9/WpfApplication1;component/Images/Actions-rating-icon.png��$��20��$��20��   CellTemplate �� .R��� ���� *Rate+0  *System.Windows.Controls.DataGridTextColumn     Header$ Answer��   MinWidth$	 665Q�1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Answer+  $ Answered By��$ 95Q� �� *
AnsweredBy+  $ Rate Answer�� �� .R��� $��mButtonFixThis��-   $��20��$��30��.��+1�� -   $��groupBoxTitle��$��Title��$��53��$
��Left=�$��	10,10,0,0q�$	��Top=�$	��781��.����  �� AcceptsReturn . $��24��	 �� TextWrapping$
	 Wrap=�"
 �� VerticalScrollBarVisibility$

 Auto=����� *Notes+ �� UpdateSourceTrigger$ PropertyChanged=��� -   $��groupBoxQuestion��$��Question��$	��147��$
��Left=�$��	12,82,0,0q�$	��Top=�$	��779��.����  . $
	 Wrap=�$

 Auto=�$	��756��$	��124������ *Notes+$ PropertyChanged=��� -   $��image1��$��61��$
��Left=�$��
850,12,0,0q�$
��Fill=�$	��Top=�$��62��$?��9/WpfApplication1;component/Images/Actions-rating-icon.png���� -   $��
textBlock1��$��17��$
��Left=�$��
876,35,0,0q�$��13��$	��Top=�$��19���� -   $��buttonClose��$��Close��$��23��$
��Left=�$��850,522,0,0q�$	��Top=�$��75���� -   $��buttonAnswer��$��Answer��$��23��$
��Left=�$��758,522,0,0q�$	��Top=�$��75���� -	   $��buttonRateQuestion��$��+1��$��23��$��Right=�$��0,522,228,0q�$	��Top=�$��75��