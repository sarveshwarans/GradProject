   M S B A M L   `   `   `  ����I  ELabAssignment3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:LabAssignment3.ViewLabAssignment3.View  5   	   #    LabAssignment3.View.AddMember   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:LabAssignment3.View     5   	   -   5        $��	AddWindow��5   	     � Title$  Add Membership��5
   	   $	��300��6    $	��300��6-    � DataContext 5	   	   ��    Locator �� Source# [   �� Path$
 Main�.��5      � ���	#FFECEAEA � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��* �6#    � RowDefinitions 5   
   �� 5      $��10 �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��30 �6   .+�5   
   �� -   5         ��Name$ label��5      $��First Name:��6   $��Center=�65   $��Center=�6R   $��1��6m   $��0��6z   �� 5   
   -   5        $ label1��5      $��
Last Name:��6    $��Center=�65   $��Center=�6R   $��2��6m   $��0��6z   �� 5   
   -   5        $ label2��5      $��E-mail:��6    $��Center=�62   $��Center=�6O   $��3��6j   $��0��6w   �� 5   
   -   5         ��Name$ textbox��5      $��Center=�6#   $��23��6@    �� TextWrapping$
 Wrap=�6L   $��Center=�6`   $	��120��5   0   $��1��6<   $��1��6I   ��6   �� *EnteredFName+6[   �� 5   
   -   5        $ textbox1��5      $��Center=�6$   $��23��6A   $
 Wrap=�6M   $��Center=�6a   $	��120��5   0   $��2��6<   $��1��6I   ��6   �� *EnteredLName+6[   �� 5   
   -   5        $ textbox2��5      $��Center=�6$   $��23��6A   $
 Wrap=�6M   $��Center=�6a   $	��120��5   2   $��3��6>   $��1��6K   ��6   �� *EnteredEmailId+6]   �� 5    
   -   5        $��button��5       $
��Save��6   $��Center=�6.   $��23��6K   $	��Top=�6W   $��75��5!   d   $��4��6o   $��0��6|   ��6   �� *SaveCommand+��61   �� 	 �� ElementName$	 	AddWindow��5"      �� 5#   
   -	   5        $��button1��5#      $��Cancel��6    $��Center=�61   $��23��6N   $	��Top=�6Z   $��75��5$   f   $��4��6q   $��1��6~   ��6   �� *CancelCommand+��63   �� $	 	AddWindow��5%      5&      5'      