   M S B A M L   `   `   `  ����I  ELabAssignment3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:LabAssignment3LabAssignment3  5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5   	       LabAssignment3.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:LabAssignment3     5   	   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   	   -   5          �Name$  
mainWindow��5   	    � Title$ Membership Maintenance��5   	   $	��300��6(   $	��650��65    � Icon$ 
images.ico��6A    � DataContext 5
   	   ��    Locator �� Source# [   �� Path$ MainViewModel�.��5      � ���	#FFECEAEA.+�5   
   �� -   5         ��Name$ button��5      $	��Add��6!   $��1��6/   $��1��6<   $
��Left=�6k   $	��Top=�6�   $��75��5      $��0,50,0,0q�6   ��5   L   �� *
AddCommand+5   1   �� 5   
   -   5        $ button2��5      $��Delete��6"   $��1��63   $��1��6A   $
��Left=�5   	   $��Center=�6$   $��75��6?   $��0,0,0,50q�6J   ��5   R   �� *DeleteCommand+��6t   ��  �� ElementName$ 
mainWindow��5   J   �� 5   
   -   5        $ button3��5      $
��Exit��6"   $��1��61   $��1��6?   $
��Left=�5   	   $��Bottom=�6$   $��75��6?   $��0,0,0,50q�6J   ��5   P   �� *ExitCommand+ �� Mode$ OneWay=���6}   �� $ 
mainWindow��5   J   �� 5   
   -   5        	 ��Name$	 listbox��5      
 �� DisplayMemberPath$
 Display��6Q   $��1��6�   $��0��6�   $��Center=�6�   $��Center=�6�   $	��220��5      $	��322��6   ��5   #   �� *	Members+$ OneWay=� �� SelectedItem 6m   �� *CurrentMember+.  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5         	EventName$ MouseDoubleClick��6!   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6,   �� *SelectedItemCommand+   CommandParameter 6T   �� $ listbox��$ SelectedItem�5      5       � ColumnDefinitions 5   
   �� 5      $	��380 �6   �� 5       � RowDefinitions 5    
   �� 5!      $��* �6   �� 5"      $	��250 �6   �� 5#      $��* �6   5%      5&      