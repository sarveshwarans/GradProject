   M S B A M L   `   `   `  ����I  ELabAssignment3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:LabAssignment3.ViewLabAssignment3.View  5   	   &     LabAssignment3.View.ChangeMember   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:LabAssignment3.View     5   	   -   5          �Name$  UpdateWindow��5   	    � Title$ ChangeMember��5	   	   $	��300��6   $	��300��6+   .��5
      � ���	#FFECEAEA � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��10 �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��30 �6   .+�5   
   �� -   5         ��Name$ label��5      $��First Name:��6   $��Center=�65   $��Center=�6R   $��1��6m   $��0��6z   �� 5   
   -   5        $ label1��5      $��
Last Name:��6    $��Center=�65   $��Center=�6R   $��2��6m   $��0��6z   �� 5   
   -   5        $ label2��5      $��E-mail:��6    $��Center=�62   $��Center=�6O   $��3��6j   $��0��6w   �� 5   
   -   5         ��Name$ textbox��5      $��Center=�6#   $��23��6@    �� TextWrapping$
 Wrap=�6L   $��Center=�6`   $	��120��5   5   $��1��6A   $��1��6N   ��6   ��  �� Path$ EnteredFname�6`   �� 5   
   -   5        $ textbox1��5      $��Center=�6$   $��23��6A   $
 Wrap=�6M   $��Center=�6a   $	��120��5   5   $��2��6A   $��1��6N   ��6   �� $ EnteredLname�6`   �� 5   
   -   5        $ textbox2��5      $��Center=�6$   $��23��6A   $
 Wrap=�6M   $��Center=�6a   $	��120��5   7   $��3��6C   $��1��6P   ��6   �� $ EnteredemailId�6b   �� 5   
   -   5        $��button��5      $��Update��6   $��Center=�60   $��23��6M   $	��Top=�6Y   $��75��5    i   $��4��6t   $��0��6�   ��6   �� *UpdateCommand+��63   ��  �� ElementName$ UpdateWindow��5!      �� 5"   
   -	   5        $��button1��5"      $��Cancel��6    $��Center=�61   $��23��6N   $	��Top=�6Z   $��75��5#   i   $��4��6t   $��1��6�   ��6   �� *CancelCommand+��63   �� $ UpdateWindow��5$      5%      5&      