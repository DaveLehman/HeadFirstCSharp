   M S B A M L   `   `   `  ����F  BTwoDecksWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:TwoDecksWPFTwoDecksWPF  5   	       TwoDecksWPF.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:TwoDecksWPF     5   	     � Title$  	Two Decks��5   	   $	��450��6   $	��400��6(    � 	Resources 5	        TwoDecksWPF.Deck   leftDeck  	rightDeck��%:   &	        &	        5
   
   6     5   
   6   5      .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� -   5         ��Name$ 
deck1Label��5   ?   $��0��6   $��0��6   $��Deck _1��6-   $��10,0,0,0q�6S    �� Target 6e   ��  �� ElementName$ leftDeckListBox�� �� Mode$ OneWay=��� 5   
   -   5        $ 
deck2Label��5   ?   $��0��6   $��1��6   $��Deck _2��6-   $��10,0,0,0q�6S    6e   �� $ rightDeckListBox��$ OneWay=��� 5   
   -   5         ��Name$ leftDeckListBox��5   /   $��1��6   $��0��6   $��
10,0,10,10q�6H   #���   6\   6�   �� 5   
   -   5        $ rightDeckListBox��5   /   $��1��6   $��1��6   $��
10,0,10,10q�6I   #���  6]   6�   �� 5   
   -   5        	 ��Name$	 shuffleLeftDeck��5   A   $��2��6   $��0��6   $��_Shuffle��6.   $��
10,0,10,10q�6Z   6n   �� 5   
   -   5        $	 clearRightDeck��5   ?   $��2��6   $��1��6   $��_Clear��6.   $��
10,0,10,10q�6W   6k   �� 5   
   -   5        $	 resetLeftDeck��5   ?   $��3��6   $��0��6   $��_Reset��6.   $��
10,0,10,10q�6V   $��20��6j   $��Bottom=�6v   6�   �� 5   
   -   5        $	 sortRightDeck��5   >   $��3��6   $��1��6   $��Sor_t��6.   $��
10,0,10,10q�6U   6i   5       5"      