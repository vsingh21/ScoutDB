   M S B A M L   `   `   `  ����  FBLA    FBLA.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  ScoutDB��5   	   $	��800��6   $
��1200��6&    � 	Resources 5      &   System.Windows.Controls.DataGrid �� 
TargetType��%E   '        �� 5   
   "  6   .�5      -   5        5      5	      .��5
      � ���#34495E.+�5   
   ��  �� Orientation$ Vertical=�6   $��10q�6,   .+�5      �  � ColumnDefinitions 5      �� 5      $��* �6'   �� 5      $
��Auto �6'   .+�5      �� $��ScoutDB��6   $
��Bold"�6+   $��24(�6=   ���#ECF0F1$��10q�6`   �� 5      -   5        $��1��5      $��30��6<   $��30��6G   $��15q�6S   $��Segoe UI Symbol)�6_   $	����6|   
������ 
�������$��0q�6�   5      �� 5      $ 
Horizontal=�6   $��Right=�62   $��0,0,10,0q�6N   .+�5      �� -   5         ��Name$ searchTextBox��5      $	��200��61   $��30��6=   $��0,0,10,0q�6I   $��Center=�6[   6}   �� 5      -   5        $��30��5   2   $��30��6=   $��5q�6I   $��Segoe UI Symbol)�6T   $	����6q   
������ 
�������$��0q�6�   �� 5      -   5        $��30��5   -   $��30��68   $��5q�6D   $��Segoe UI Symbol)�6O   $	����6l   
������ 
�������$��0q�6�   5        5      -   5        $��partnersDataGrid��5         AutoGenerateColumns$ False��6/      CanUserAddRows$ False��6K      
IsReadOnly$
 True��6b   ���#ECF0F1$��Stretch=�6�   	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Organization��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6`   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   �� *Organization+6`     5      $

 Type��6)   $
 Auto 6P    67   �� *Type+6P     5       $
 	Resources��6)   $
 Auto 6Z    6<   �� *	Resources+6Z     5!      $
 Contact Person��6)   $ * 6c    6A   �� *ContactPerson+6c     5"      $
 Contact Email��6)   $
 Auto 6a    6@   �� *ContactEmail+6a     5#      $
 Contact Phone��6)   $ * 6a    6@   �� *ContactPhone+6a   5%      5'      5(      5)      