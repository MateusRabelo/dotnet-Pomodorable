   M S B A M L   `   `   `  ���� F  BPomodorable, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:PomodorablePomodorable      Pomodorable.MainWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:Pomodorable       � Title$  Pomodorable��$	��450��$	��800�� � 
ResizeMode$ CanMinimize=� � WindowStartupLocation$ CenterScreen=�$��Center=�$��Center=� � WindowStyle$
 None=� � Icon$ /stop_watch_rtc_icon.ico��.���  � 	Resources  �� 
TargetType �� Property �� Value	 �� 
TargetType
 �� CornerRadius �� RadiusX �� RadiusY � Value �� Triggers P� Property P� Value��%  '�       '�� �     �� " �.���  � �� �� "	 �.R��� #��z��#��z��#��z��$
 5��._�� .+��� 
�������$ 3��$ 5��$��5q�$
��Left=�#��z �� " �� P�  �@J�IsMouseOver$
 True��. ���  � ��
 �   ���  � ��
 �   � � RowDefinitions �� $��0* ��� $��87 ��� $
��281* ��� $	��66* � � ColumnDefinitions �� $
��219* ��� $
��572* ��� $��9* ��� $��0* �.+��� -    ��Name$ bgMain��$
��Left=�$	��450��$��1��$	��Top=�$	��800��$��/bgWpp3.jpg��$
��Fill=�$��3��$��3��]� $��False��$��0,0,2,0q�$��1��$��3��.+��� -   $��lbCkeckList��$��Bottom=�$	��353��$��5q����	#AF101010���� .R���  �� Orientation$ 
Horizontal=�.+��� ���	#B2FFFFFF���	#00000000
�������$
��Left=�$
��Left=����� *
TaskName+ d� 	IsChecked �� *IsCompleted+�� -   $��30��$��10��$��12(�$$��Bahnschrift SemiBold Condensed)�$��5q�$��2��$��Right=�$��Right=� � Cursor$
 Hand��
�������
�������$��2,2,2,2q�����  �� ImageSource$ 
/trash.png�� j� TileMode$
 None=�]� $��False��$��1�����	#990C1613$
��Left=�$	��800��$��88��$��Center=�$��3��.+��� $��	Checklist��$$��Bahnschrift SemiBold Condensed)�$��30(�
������ 
�������$��Center=� J� RenderTransformOrigin$ 
0.468,0.83&�$��Center=�$
��Left=�$	��218��
���   �$��86���� -    ��Name$ lblStatusMain��$��Hora de focar!��$$��Bahnschrift SemiBold Condensed)�$��30(�
������ 
�������$��Center=�$ 
0.468,0.83&�$��Center=�$
��Left=�$	��578��
���   �$��1,0,0,0q��� -    ��Name$ 
btnAddTask��$��Center=�$��	0,267,0,0q�$��2��$��47��$��46��$	��Top=�$��0,0,0,0q� �� IsCancel$
 True��$
 Hand�� �� 	ClickMode$ Press=�$��2������ $ /addButton1.png��$
 Tile=�� -    �Name$ popAddTaskContent��$��False��$	��Top=�$��0,0,0,87q�$��2�� � PlacementTarget ��   �� ElementName$  
btnAddTask��.���� 
�������$
 5��$��1q�$	��200��$��85��._��� ���	#33A9A9A9.+��� 
�������$$��Bahnschrift SemiBold Condensed)�$��  Digite sua task:��$��5q��� -   ! ��Name$! taskTextBox��$	��180��$��5q��� -   $ btnAddTaskPopup��$��	Adicionar��$��75��$��20��$��12(�$$��Bahnschrift SemiBold Condensed)�$��5q�$��2��$��Center=�$
 Hand�����	#7F000000
�������
�������$��2,2,2,2q��� -	   $ lblTimeStatus��$��25:00��$
��Left=�$��0,41,0,0q�$��2��$	��Top=�$	��114��$	��581��$��Arial Black)�$
��Bold"�$	��100(�$��1��$��Center=�$��Center=�
�������$��2���� -
   $ btnPomodoro��$��Pomodoro��$
��Left=�$��133,160,0,0q�$��2��$	��Top=�$��1��$��37��$��96��$��20(�$$��Bahnschrift SemiBold Condensed)�$
 Hand�����	#7F000000
�������$��2,2,2,2q�$��False��
��������� -   $ btnShortBreak��$
��Left=�$��243,160,0,0q�$��2��$	��Top=�$��1��$��37��$��94��$��20(�$$��Bahnschrift SemiBold Condensed)�$��Pausa Curta��$
 Hand�����	#7F000000
�������
�������$��2,2,2,2q��� -   $ btnLongBreak��$��Pausa Longa��$	��Top=�$��37��$��20(�$$��Bahnschrift SemiBold Condensed)�$��1��$��0,160,125,0q�$��2��$��Right=�$��94��$
 Hand�����	#7F000000
�������
�������$��2,2,2,2q�� -   " �Name$" progressBar��$��1��$
��Left=�$��25��$��3��$��Center=�$	��523��# � Maximum$	# 561Q�
������ 
�������$��3q�$��20,0,0,0q��� -   $ lblStatusProgressBar��$��Estado de foco��$
��Left=�$��	10,0,0,50q�$��2��$	��561��$��Arial Black)�$
��Bold"�$��20(�$��Center=�$��32��$��Bottom=�$��1��$��2��
��������� -   $ btnInitialize��$��Start��$
��Left=�$��243,226,0,0q�$��2��$	��Top=�$��1��$��37��$��95��$��20(�$$��Bahnschrift SemiBold Condensed)�$
 Hand�����	#7F000000
�������$��2,2,2,2q�$��False��
��������� -   $ lblDebug��$��debug label��$
��Left=�$��	206,1,0,0q�$��2��$	��Top=�$��44��$	��277��$��Arial Black)�$
��Bold"�$��20(�$��Center=�$��Center=�
�������$��2��$y�Hidden=��� $��1��$
��Left=�$��36��$��
198,11,0,0q�$��2��
���   �$	��Top=�$��40�����	#7F000000�� -   $ btnPlayLofiSound��$
��Left=�$��
198,10,0,0q�$��2��$	��Top=�$��1��$��37��$��41��$��20(�$$��Bahnschrift SemiBold Condensed)�$
 Hand��
�������$��2,2,2,2q�$��False��
�������$ J� Opacity$	$ 0.5Q����� $ /lofiOnLightTheme.png��$
 None=�% j� Stretch$% Uniform=��� $��1��$
��Left=�$��37��$��
204,10,0,0q�$��2��
���   �$	��Top=�$��41�����	#19000000$y�Hidden=�$|�False���� $��1��$
��Left=�$��36��$��
271,11,0,0q�$��2��
���   �$	��Top=�$��40�����	#7F000000�� -   $ btnPlayClockTickingSound��$
��Left=�$��	270,9,0,0q�$��2��$	��Top=�$��1��$��38��$��41��$��20(�$$��Bahnschrift SemiBold Condensed)�$
 Hand��
�������$��2,2,2,2q�$��False��
�������$$ 1Q����� $! /clockSoundOnLightTheme.png��$% UniformToFill=��� $��1��$
��Left=�$��37��$��
264,10,0,0q�$��2��
���   �$	��Top=�$��41�����	#19000000$y�Hidden=�$|�False���� $��1��$
��Left=�$��36��$��
340,11,0,0q�$��2��
���   �$	��Top=�$��40�����	#7F000000�� -   $ btnPlayNoiseSound��$
��Left=�$��
340,10,0,0q�$��2��$	��Top=�$��1��$��37��$��41��$��20(�$$��Bahnschrift SemiBold Condensed)�$
 Hand��
�������$��2,2,2,2q�$��False��
�������$	$ 0.5Q����� $! /noiseSoundOnLightTheme.png��$% Uniform=�$
 None=��� $��1��$
��Left=�$��37��$��
325,10,0,0q�$��2��
���   �$	��Top=�$��41�����	#19000000$y�Hidden=�$|�False���� -   $ btnClose��$��Right=�$��
546,10,0,0q�$��1��$	��Top=�$��1��$��25��$��25��$��20(�$$��Bahnschrift SemiBold Condensed)�$
 Hand��
������ $��2,2,2,2q�$��False��
������ $	$ 0.8Q����� $% Uniform=�$
 None=�$ /close512px.png��