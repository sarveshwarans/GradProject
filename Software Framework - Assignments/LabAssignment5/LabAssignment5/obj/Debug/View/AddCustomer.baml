   M S B A M L   `   `   `  ����I  ELabAssignment5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:LabAssignment5.ViewLabAssignment5.View  5   	   %    LabAssignment5.View.AddCustomer   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:LabAssignment5.View     5   	   -   5          �Name$  	AddWindow��5   	    � Title$ AddCustomer��5
   	   $	��300��6   $	��600��6*    � DataContext 5	   	   ��    Locator �� Source# [   �� Path$
 Main�.��5      � ���	#FFECEAEA � ColumnDefinitions 5   
   �� 5      �� 5      $��0* �6   .+�5   
   �� -   5         ��Name$ label1��5      $
��Name��6    $
��Left=�6/   $��	30,70,0,0q�6J   $	��Top=�6]    J� RenderTransformOrigin$ 1.456,1.712&�6u   �� 5   
   -   5        $ label2��5      $��Address��6    $
��Left=�62   $��
30,100,0,0q�6M   $	��Top=�6a   �� 5   
   -   5        $ label3��5      $
��City��6    $
��Left=�6/   $��
30,130,0,0q�6J   $	��Top=�6^   �� 5   
   -   5        $ label4��5      $��State��6    $
��Left=�60   $��
30,165,0,0q�6K   $	��Top=�6_   �� 5   
   -   5         ��Name$ textBox1��5      $
��Left=�6:   $��23��6U   $��
181,70,0,0q�6a   	 �� TextWrapping$
	 Wrap=�6u   $	��Top=�6�   $	��200��6�   ��6$   �� *Name+6�   �� 5   
   -   5        $ textBox2��5      $
��Left=�6=   $��23��6X   $��181,100,0,0q�6d   $
	 Wrap=�6y   $	��Top=�6�   $	��200��6�   ��6$   �� *	Address+6�   �� 5   
   -   5        $ textBox3��5      $
��Left=�6:   $��23��6U   $��181,130,0,0q�6a   $
	 Wrap=�6v   $	��Top=�6�   $	��200��6�   ��6$   �� *City+6�   �� 5   
   -	   5        $ label5��5      $��Zipcode��6    $
��Left=�62   $��343,160,0,0q�6M   $	��Top=�6b   �� 5   
   -
   5        $ textBox5��5      $
��Left=�6=   $��23��6X   $��430,160,0,0q�6d   $
	 Wrap=�6y   $	��Top=�6�   $	��120��6�   ��6$   �� *	Zipcode+6�   �� 5   
   -   5        
 ��Name$
 button1��5      $��Accept��6"   $
��Left=�6�   $��
30,210,0,0q�6�   $	��Top=�6�   $��75��6�   ��63   �� *SaveCustomer+��6T   ��  �� ElementName$ 	AddWindow��6�   �� 5   
   -   5        $
 button4��5      $��Cancel��6"   $
��left=�6�   $��430,210,0,0q�6�   $	��Top=�6�   $��75��6�   ��63   �� *
ExitWindow+��6R   �� $ 	AddWindow��6�   �� 5   
   -   5         ��Name$ comboBox��5       �� DisplayMemberPath$ 	StateName��6H   $
��Left=�6�   $��181,160,0,0q�6�   $	��Top=�6�   $	��120��6�   ��6%   �� *	Statelist+ �� SelectedItem 6f   �� *Selectedstate+6�   5      5      