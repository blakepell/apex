   M S B A M L   `   `   `  ���� K  GApex, Version=1.6.0.0, Culture=neutral, PublicKeyToken=98d06957926c086d1clr-namespace:Apex.ConvertersApex.Converters  '    !Apex.Controls.CircularProgressBar   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     8apexConvertersclr-namespace:Apex.Converters     -     >�Name$  circularProgressBar��$	��120��$	��120��
������  � 	Resources <   6Apex.Converters.StringNullOrEmptyToVisibilityConverter *  &StringNullOrEmptyToVisibilityConverter��%   &	          .��� -    �Name$ 
LayoutRoot��
������ $��Center=�$��Center=� � ToolTip �� *ProgressText+ �� ElementName$ circularProgressBar�� � RowDefinitions �� $��* ��� $
��Auto �.+�(� $��0��.���� -    J� RenderTransformOrigin$ 0.5,0.5&�$��Center=�$��Center=�$	��120��$	��120��.+�A� -    A�Name$ C0��$��20��$��20�� �� Left$ 0��
	 �� Top$	 0��
 �� Stretch$

 Fill=����	#FFE98101 J� Opacity$	 1.0Q�A� -   $ C1��$��20��$��20��$ 0��$	 0��$

 Fill=����	#FFE98101$	 0.9Q�A� -   $ C2��$��20��$��20��$ 0��$	 0��$

 Fill=����	#FFE98101$	 0.8Q�A� -   $ C3��$��20��$��20��$ 0��$	 0��$

 Fill=����	#FFE98101$	 0.7Q�A� -   $ C4��$��20��$��20��$ 0��$	 0��$

 Fill=����	#FFE98101$	 0.6Q�A� -	   $ C5��$��20��$��20��$ 0��$	 0��$

 Fill=����	#FFE98101$	 0.5Q�A� -
   $ C6��$��20��$��20��$ 0��$	 0��$

 Fill=����	#FFE98101$	 0.4Q�A� -   $ C7��$��20��$��20��$ 0��$	 0��$

 Fill=����	#FFE98101$	 0.3Q�A� -   $ C8��$��20��$��20��$ 0��$	 0��$

 Fill=����	#FFE98101$	 0.2Q�z��� -   SpinnerRotate�� �� Angle$ 0Q��� $��1�����	#FFE98101���� *ProgressText+$ circularProgressBar��y��� *ProgressText+$ circularProgressBar�� �� 	Converter# [  