using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FieldsApp.View
{
    public sealed partial class Game : Page
    {


        public Game()
        {
            this.InitializeComponent();

        }

        public int number;
        public int score = 0;


        private void Start_Click(object sender, RoutedEventArgs e)
        {
            GuessNumber.Text = " ";
            Answer.Text = " ";
            Score.Text = " ";
            Random rand = new Random();
            number = rand.Next(1, 101);
            btnGuess.IsEnabled = true;


        }

    

        private void btnGuess_Click(object sender, RoutedEventArgs e)
        {
          
            int guessed = Int32.Parse(GuessNumber.Text);
            Start.Content = "NEW GAME";

             
                if (guessed < number)
                {
                    Answer.Text = "HIGHER";
                    score++;
                }

                else if (guessed > number)
                {
                    Answer.Text = "LOWER";
                    score++;
                }
          

            if (guessed == number)
                {
                    score++;
                    Answer.Text = "CORRECT";
                    Score.Text = "Number of attempts: " + Convert.ToString(score);
                    btnGuess.IsEnabled = false;
                score = 0;
                }
            
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void TextBlock_SelectionChanged_1(object sender, RoutedEventArgs e)
        {

        }
    }
    
}
