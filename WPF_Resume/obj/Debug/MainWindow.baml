   M S B A M L   `   `   `  ����E  AWPF_Resume, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:WPF_Resume
WPF_Resume  5   	       WPF_Resume.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:WPF_Resume     5   	   -   5          � 
ResizeMode$  NoResize=�5   	    � Title$ RESUME��5	   	   $	��433��6   $	��413��6%    � WindowStartupLocation$ CenterScreen=�61    � Icon$ /Picture/cv_102350.ico��6V    � 	Resources 5         LabelAnimation W� From	 W� To g� Duration �� 
TargetName	 �� TargetProperty
 g� 	BeginTime  ImageAnimation  ButtonAnimation��%M  &	        &	 �     &	 t    �� 5   
   .��5      W� $ 0X�6   $ 1X�6'   $ 0:0:4D�6.   $ label1��6?   $	 Opacity�6^   W� 5      $ 0X�6   $ 1X�6'   $ 0:0:4D�6.   $ label2��6?   $	 Opacity�6^   $
 0:0:4X�6�   5      �� 5   
   .��5      W� $ 0X�6   $ 1X�6'   $ 0:0:4D�6.   $ 
pictureBox��6?   $	 Opacity�6b   $
 0:0:4X�6�   5      �� 5   
   .��5      W� $	 150X�6   $ 1X�6)   $ 0:0:7D�60   $ buttonBegin��6A   $8	 2(UIElement.RenderTransform).(TranslateTransform.Y)�6f   $
 0:0:5X�6�   5      5      .��5      � .+�5   
   �� -   5         ��Name$ label1��5      $/��)Вітаємо Вас у програмі��6    $��Center=�6A   $��0,15,0,0q�6^   $	��Top=�6p   $��24(�6�   $
��Bold"�6�   ���	#FF4660EF J� Opacity$ 0Q�6�   �� 5   
   -   5         ��Name$ buttonBegin��5      $��Почати��6&   $��Center=�67   $��	0,322,0,0q�6T   $��18(�6g   $	��108��6u   $��48��6�   $	��Top=�6�   z�5      T� 5       T� Y$	 120Q�6%   5      �� 5    
   -   5        $ label2��5       $��"RESUME"��6    $��Center=�6=   $��0,57,0,0q�6Z   $	��Top=�6l   $��36(�6�   $
��Bold"�6�   ���	#FF4660EF$ 0Q�6�   �� 5!   
   -   5         ��Name$ 
pictureBox��5!      $��Center=�6$   $	��170��6A   $��	0,120,0,0q�6N   $	��Top=�6a   $	��224��6y   $
��Fill=�6�   $��/Picture/ptttpng.png��6�   $ 0Q�6�   5"      5#      