using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace WordleGame
{
    public partial class MainWindow : Window
    {
        private string secretWord = "appel"; // Stel hier het geheime woord in

        public MainWindow()
        {
            InitializeComponent();
        }

        // Controleer of de invoer een letter is
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Regex die alleen letters (a-z of A-Z) toestaat
            Regex regex = new Regex("[^a-zA-Z]+");
            e.Handled = regex.IsMatch(e.Text);  // Als het geen letter is, blokkeer de invoer
        }

        // Verplaats de focus naar het volgende tekstvak
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox currentBox = sender as TextBox;

            // Als het tekstvak gevuld is met een letter, verplaats naar het volgende vakje
            if (currentBox.Text.Length == 1)
            {
                MoveFocusToNextTextBox(currentBox);
            }
        }

        // Verplaats focus terug bij backspace
        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            TextBox currentBox = sender as TextBox;

            // Controleer of de gebruiker op backspace drukt
            if (e.Key == Key.Back && currentBox.Text == "")
            {
                // Ga naar het vorige tekstvak
                MoveFocusToPreviousTextBox(currentBox);
            }
        }

        private void MoveFocusToNextTextBox(TextBox currentBox)
        {
            if (currentBox == LetterBox1) LetterBox2.Focus();
            else if (currentBox == LetterBox2) LetterBox3.Focus();
            else if (currentBox == LetterBox3) LetterBox4.Focus();
            else if (currentBox == LetterBox4) LetterBox5.Focus();
        }

        private void MoveFocusToPreviousTextBox(TextBox currentBox)
        {
            // Ga naar het vorige tekstvak en wis de inhoud
            if (currentBox == LetterBox5) { LetterBox4.Focus(); LetterBox4.Clear(); }
            else if (currentBox == LetterBox4) { LetterBox3.Focus(); LetterBox3.Clear(); }
            else if (currentBox == LetterBox3) { LetterBox2.Focus(); LetterBox2.Clear(); }
            else if (currentBox == LetterBox2) { LetterBox1.Focus(); LetterBox1.Clear(); }
        }

        // Controleer of het ingevoerde woord overeenkomt met het geheime woord
        private string CheckWordButton_Click(object sender, RoutedEventArgs e)
        {
            // Verzamel de letters uit de vijf tekstvakken
            string guess = LetterBox1.Text + LetterBox2.Text + LetterBox3.Text + LetterBox4.Text + LetterBox5.Text;

            // Controleer of de gebruiker vijf letters heeft ingevuld
            if (guess.Length == 5)
            {
                // Vergelijk het ingevoerde woord met het geheime woord
                if (guess.ToLower() == secretWord)
                {
                    MessageBox.Show("Dit was het woord! Gefeliciteerd!");
                }
                else
                {
                    MessageBox.Show("Dit was het woord niet. Probeer opnieuw!");
                }
            }
            else
            {
                MessageBox.Show("Vul een volledig vijfletterwoord in.");
            }
            return guess;
        }
        

        // Start een nieuw spel door de tekstvakken te resetten
        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            // Reset de tekstvakken voor een nieuw spel
            LetterBox1.Clear();
            LetterBox2.Clear();
            LetterBox3.Clear();
            LetterBox4.Clear();
            LetterBox5.Clear();
            LetterBox1.Focus();  // Focus op het eerste vakje
        }
    }
}
