using System;
using System.Collections.Generic;
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
using System.Windows.Threading;

namespace MatchGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        int tenthsOfSecondsElaspsed;
        int matchesFound;

        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(.1);
            timer.Tick += Timer_Tick;
            SetUpGame();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            tenthsOfSecondsElaspsed++;
            timeTextBlock.Text = (tenthsOfSecondsElaspsed / 10F).ToString("0.0s");
            if ( matchesFound == 8 )
            {
                timer.Stop();
                timeTextBlock.Text = timeTextBlock.Text + " - Play again?";
            }
        }

        private void SetUpGame()
        {
            
            List<string> animalEmoji = new List<string>()
            {
                "🤡","🤡",
                "😺","😺",
                "🐴","🐴",
                "🐉","🐉",
                "🐫","🐫",
                "🐬","🐬",
                "🐧","🐧",
                "🐘","🐘"
            };

            Random random = new Random();

            foreach(TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())
            {
                // have 16 emojis and 17 TextBlock because we added the timeTextBlock...
                if( textBlock.Name != "timeTextBlock" )
                {
                    int index = random.Next(animalEmoji.Count);
                    string nextEmoji = animalEmoji[index];
                    textBlock.Text = nextEmoji;
                    textBlock.Visibility = Visibility.Visible;
                    animalEmoji.RemoveAt(index);
                }
            }

            timer.Start();
            tenthsOfSecondsElaspsed = 0;
            matchesFound = 0;
        }

        TextBlock lastTextBlockClicked;
        bool findingMatch = false;  // keeps track of whether or not the player just clicked on
        // the first animal in a pair and is now trying to find its match
        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            if( findingMatch == false )
            {
                // player just clicked the first animal in a pair; make that animal invisible and store it in
                // case it needs to make visible again
                textBlock.Visibility = Visibility.Hidden;
                lastTextBlockClicked = textBlock;
                findingMatch = true;
            }
            else if ( textBlock.Text == lastTextBlockClicked.Text )
            {
                // found a match! Make second animal incisible (and unclickable) and reset
                // finding match so next click is a first click again
                textBlock.Visibility = Visibility.Hidden;
                findingMatch = false;
                matchesFound++;
            }
            else
            {
                // player clicked on an animal that doesn't match so make the first animal visible again
                // and rest finding match
                lastTextBlockClicked.Visibility = Visibility.Visible;
                findingMatch = false;
            }

        }

        private void TimeTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if ( matchesFound == 8 )
            {
                SetUpGame();
            }
        }
    }
}
