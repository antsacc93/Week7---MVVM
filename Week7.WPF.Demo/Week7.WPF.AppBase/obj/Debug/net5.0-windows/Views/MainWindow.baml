   M S B A M L   `   `   `  ����L  HWeek7.WPF.AppBase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Week7.WPF.AppBase.ViewsWeek7.WPF.AppBase.Views  5   	   K*clr-namespace:Week7.WPF.AppBase.ViewModelsWeek7.WPF.AppBase.ViewModels  5   	   K*clr-namespace:Week7.WPF.AppBase.ConvertersWeek7.WPF.AppBase.Converters  5   	   (    "Week7.WPF.AppBase.Views.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:Week7.WPF.AppBase.Views     5   	   9vm*clr-namespace:Week7.WPF.AppBase.ViewModels     5   	   @	converter*clr-namespace:Week7.WPF.AppBase.Converters     5   	     � Title$  
MainWindow��5
   	   $	��450��6   $	��800��6)    � 	Resources 5      7   1Week7.WPF.AppBase.Converters.IntToStringConverter   IntToString<   6Week7.WPF.AppBase.Converters.BoolToVisibilityConverter  BoolToVisibility��%:   &	        &	        5   
   6)     5   
   6.   5      .��5      �� .+�5   
   �� -   5         ��Name$ txtDemo��5      ��6#   ��  �� Path$ 
MyProperty� �� UpdateSourceTrigger$ PropertyChanged=��� 5   
   -   5        .��5   &   Click6-   �� 5   
   ��6   �� $ MyProperty2� �� Mode$ TwoWay=� �� 	Converter# [   �� ConverterParameter$ -1�� �� ConverterCulture$ it-IT���� 5   
   $��4q�6   	 d� 	IsChecked	 6   �� $ 	IsChecked�.��6C   Chiuso6K   �� 5   
   
 �� Orientation$
 
Horizontal=�6   y�6.   �� $ 	IsChecked�# [ .+�5      �� $��Center=�6   $	��8,0q�63   $
��Data��6@   (  "System.Windows.Controls.DatePicker  5      5      5      5      