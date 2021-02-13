using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TwoDecksWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if (Resources["rightDeck"] is Deck rightDeck)
            {
                rightDeck.Clear();
            }
        }

        private void MoveCard(bool leftToRight)
        {
            // The Windows.Resources tag we added created a Resource Dictionary with two entries: references to
            // two instances of the Deck class with keys leftDeck and rightDeck. This code demostrates how to
            // SAFELY get a reference to a Deck
            if ((Resources["leftDeck"] is Deck leftDeck) && (Resources["rightDeck"] is Deck rightDeck))
            {
                if (leftToRight)
                {
                    if (leftDeckListBox.SelectedItem is Card card)
                    {
                        leftDeck.Remove(card);
                        rightDeck.Add(card);
                    }
                }
                else
                {
                    if (rightDeckListBox.SelectedItem is Card card)
                    {
                        rightDeck.Remove(card);
                        leftDeck.Add(card);
                    }
                }
            }
        }



        #region Click_Handlers
        private void shuffleLeftDeck_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("shuffleLeftDeck_Click()");
            if (Resources["leftDeck"] is Deck leftDeck)
            {
                leftDeck.Shuffle();
            }
        }

        private void clearRightDeck_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("clearRightDeck_Click()");
            if (Resources["rightDeck"] is Deck rightDeck)
            {
                rightDeck.Clear();
            }
        }

        private void resetLeftDeck_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("resetLeftDeck_Click()");
            if (Resources["leftDeck"] is Deck leftDeck)
            {
                leftDeck.Reset();
            }
        }

        private void sortRightDeck_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("sortRightDeck_Click()");
            if (Resources["rightDeck"] is Deck rightDeck)
            {
                rightDeck.Sort();
            }
        }

        #endregion

        #region DoubleClickHandlers
        private void leftDeckListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("leftDeckListBox_MouseDoubleClick");
            // The first click selects a card so doubleclick just needs to move it
            MoveCard(true);

        }

        private void rightDeckListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("rightDeckListBox_MouseDoubleClick");
            // The first click selects a card so doubleclick just needs to move it
            MoveCard(false);
        }




        #endregion

        private void leftDeckListBox_KeyDown(object sender, KeyEventArgs e)
        {
            Debug.WriteLine("leftDeckListBox_KeyDown()");
            // Called any time the ListBox is in focus and user presses a key. We want the user to be
            // able to use up and down arrows to navigate the cards, so we only need to respond when
            // the user presses the Enter key
            if (e.Key == Key.Enter)
            {
                MoveCard(true);
            }
        }

        private void rightDeckListBox_KeyDown(object sender, KeyEventArgs e)
        {
            Debug.WriteLine("leftDeckListBox_KeyDown()");
            // Called any time the ListBox is in focus and user presses a key. We want the user to be
            // able to use up and down arrows to navigate the cards, so we only need to respond when
            // the user presses the Enter key
            if (e.Key == Key.Enter)
            {
                MoveCard(false);
            }
        }
    }
}
