   M S B A M L   `   `   `  ����Q  MAvanade.Allocation.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Avanade.Allocation.WPF.ViewsAvanade.Allocation.WPF.Views  5   	   U/clr-namespace:Avanade.Allocation.WPF.ViewModels!Avanade.Allocation.WPF.ViewModels  5   	   K*clr-namespace:Avanade.Allocation.WPF.ViewsAvanade.Allocation.WPF.Views  5   	   5    /Avanade.Allocation.WPF.Views.EmployeeEditorView   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:Avanade.Allocation.WPF.Views     5   	   >vm/clr-namespace:Avanade.Allocation.WPF.ViewModels     5   	   <views*clr-namespace:Avanade.Allocation.WPF.Views     5   	     � Title$  EmployeeEditorView��5
   	   $	��450��6$   $	��800��61    � 	Resources 5         EmployeeRowTemplate2   ,Avanade.Allocation.WPF.Views.EmployeeRowView��%2   &	        �� 5   
   .R�5        5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��4q�6.   .+�5      �� $��Center=�6   $
��Bold"�63   $��36(�6E   $��4,0,0,0q�5      $��Gestione dei dipendenti��6)   6J   5      �� 5   
   $��4q�6   $��1��6   $��0��6,   ��69   ��  �� Path$ CreateEmployee�.��6a   Crea Impiegato5       �� 5!   
   $��4q�6   $��0��6   $��0��6,   $��50��69   $��Right=�6D   ��6`   �� $ LoadEmployeesCommand�.��6�   
Aggiorna5#      �� 5$   
   $��1��6   $��2��6   $��4q�63   $��Stretch=�6>   #��[  5%   9   ��6   �� $ 	Employees�69   5'      5(      