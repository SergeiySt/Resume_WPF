   M S B A M L   `   `   `  ����E  AWPF_Resume, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:WPF_Resume.Pages_SimpleWPF_Resume.Pages_Simple  5      %    WPF_Resume.Pages_Simple.PResult   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:WPF_Resume.Pages_Simple     5        N� Title$  PResult��5	      .��5      �  � RowDefinitions 5   
   �� 5      $	��74* �6   �� 5      $
��151* �6   .+�5   
   �� 
���   �$��1q�6%   $
��Left=�69   $	��398��6T   $��	10,10,0,0q�6a   $	��Top=�6t   $	��294��6�   $��2��6�   ._�5      �� -   5         ��Name$ pictureBox2��5       � Cursor$
 Hand��6)   ��68   �� *	Picture+5      �� 5   
   -   5         ��Name$ textBlolckSurname��5      $
��Left=�6/   $��
315,10,0,0q�6J   $
��Wrap=�6^   $��	TextBlock��6r   $	��Top=�6�   $��24(�6�   $
��Bold"�6�   $��Arial)�6�   �� 5   
   -   5        $ textBlockName��5      $
��Left=�6+   $��
315,43,0,0q�6F   $
��Wrap=�6Z   $��	TextBlock��6n   $	��Top=�6   $��24(�6�   $��Arial)�6�   $
��Bold"�6�   �� 5   
   -   5        $ textBlockPobatkovi��5      $
��Left=�60   $��
315,76,0,0q�6K   $
��Wrap=�6_   $��	TextBlock��6s   $	��Top=�6�   $��24(�6�   $��Arial)�6�   $
��Bold"�6�   �� 5   
   $
��Left=�6   $��316,123,0,0q�6/   $
��Wrap=�6D   $$��Дата народження:��6X   $	��Top=�6p   $��14(�6�   $
��Bold"�6�   �� 5   
   -   5        $ textBlockDate��5      $
��Left=�6+   $��447,123,0,0q�6F   $
��Wrap=�6[   $��	TextBlock��6o   $	��Top=�6�   $��14(�6�    J� RenderTransformOrigin$ 0.487,0.806&�6�   �� 5   
   $
��Left=�6   $
��Wrap=�6/   $��Адреса:��6C   $	��Top=�6R   $��14(�6j   $��316,143,0,0q�6x   $��2��6�   $
��Bold"�6�   �� 5   
   -   5        $ textBlockAdress��5      $
��Left=�6-   $��374,143,0,0q�6H   $
��Wrap=�6]   $��	TextBlock��6q   $	��Top=�6�   $��14(�6�   $��2��6�   �� 5   
   $
��Left=�6   $��
317,19,0,0q�6/   $
��Wrap=�6C   $��Телефон:��6W   $	��Top=�6g   $��14(�6   $ 
0.534,0.43&�6�   $��1��6�   $
��Bold"�6�   �� 5   
   -   5        $ textBlockPhone��5      $
��Left=�6,   $��
385,19,0,0q�6G   $
��Wrap=�6[   $��	TextBlock��6o   $	��Top=�6�   $��14(�6�   $��1��6�   �� 5   
   $
��Left=�6   $��
317,43,0,0q�6/   $
��Wrap=�6C   $��Email:��6W   $	��Top=�6e   $��14(�6}   $��1��6�   $
��Bold"�6�   �� 5   
   -   5        $ textBlockEmail��5      $
��Left=�6,   $��
362,43,0,0q�6G   $
��Wrap=�6[   $��	TextBlock��6o   $	��Top=�6�   $��14(�6�   $��1��6�   $ 0.614,0.591&�6�   �� 5   
   $
��Left=�6   $��
315,78,0,0q�6/   $
��Wrap=�6C   $��Освіта:��6W   $	��Top=�6f   $��18(�6~   $
��Bold"�6�   $��1��6�   �� 5   
   -	   5        $ textBlockEducation��5      $
��Left=�60   $��315,107,0,0q�6K   $
��Wrap=�6`   $	��Top=�6u   $	��153��6�   $	��475��6�   $��1��6�   ��6�   �� *	Education+�� 5    
   -
   5         ��Name$ buttonPrintToPdf��5       $��Друкувати��6+   $
��Left=�6?   $��211,272,0,0q�6Z   $	��Top=�6o   $	��348��6�   $��14(�6�   $��1��6�   6�   5!      5"      