   M S B A M L   `   `   `  ����P  LMurderMysteryMessages, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:MurderMysteryMessagesMurderMysteryMessages  5   	   +    %MurderMysteryMessages.MMEmailEveryone   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:MurderMysteryMessages     5   	     � Title$  MMEmailEveryone��5   	   $	��450��6!   $	��800��6.   .��5	      � .+�5
   
   �� $��Subject:��6   $
��Left=�6#   $��10,0,0,0q�6>   $	��Top=�6P   $��Tw Cen MT Condensed)�6h   $��20(�6�   �� 5   
   -   5         ��Name$ subjectTextBox��5      $
��Left=�6*   $��	10,26,0,0q�6E    �� TextWrapping$
 Wrap=�6X   $	��Top=�6l   $	��461��6�   $��23��6�   �� 5   
   $��Body:��6   $
��Left=�6    $��	10,59,0,0q�6;   $	��Top=�6N   $��Tw Cen MT Condensed)�6f   $��20(�6�   �� 5   
   -   5        $ emailTextBox��5      $
��Left=�6(   $��	10,91,0,0q�6C   $
 Wrap=�6V   $	��Top=�6j   $	��571��6�   $	��285��6�   �� 5   
   -   5         ��Name$ clearButton��5      $��Clear��6&   $��Right=�66   $��	0,0,10,10q�6R   $��Bottom=�6e   $��30��6�   $��48��6�   $��Tw Cen MT Condensed)�6�   $��20(�6�   �� 5   
   -   5        $ sendMeButton��5      $��	Send Test��6'   $��Right=�6;   $��	0,0,91,10q�6W   $��Bottom=�6j    J� RenderTransformOrigin$ 0.476,0.489&�6�   $��30��6�   $��79��6�   $��Tw Cen MT Condensed)�6�   $��20(�6�   �� 5   
   -   5        $ sendEveryoneButton��5      $��Send to Everyone��6-   $��Right=�6H   $��
0,0,175,10q�6d   $��Bottom=�6x   $ 0.562,0.639&�6�   $��30��6�   $	��117��6�   $��Tw Cen MT Condensed)�6�   $��20(�6  �� 5   
   -   5        $ 
backButton��5      $
��Back��6%   $��Right=�64   $��
0,0,734,10q�6P   $��Bottom=�6d   $��54��6   $��30��6�   $��Tw Cen MT Condensed)�6�   $��20(�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ SelectedData��5      $��598,59,10,58q�6)   �� 5   
   -   5        $ 	SelectAll��5      $��
Select All��6$   $��Right=�69   $��	0,16,10,0q�6U   $	��Top=�6h   $ 0.598,0.553&�6�   $��Tw Cen MT Condensed)�6�   $��20(�6�   $��31��6�   $��79��6�   �� 5   
   -	   5        $ sendSelectedButton��5      $��Send to Selected��6-   $��Right=�6H   $��
0,0,297,10q�6d   $��Bottom=�6x   $ 0.562,0.639&�6�   $��30��6�   $	��117��6�   $��Tw Cen MT Condensed)�6�   $��20(�6�   6�   5      5      