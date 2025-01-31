﻿using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WordleGame
{
    public partial class MainWindow : Window
    {
        private string secretWord; // initaliseren van het geheime woord
        private int currentAttempt = 1; // Houdt bij welke poging het is
        private const int maxAttempts = 6; // Maximaal aantal pogingen
        private List<string> wordList = new List<string> {
        "appel", "boter", "stoel", "klomp", "fruit", "graan", "molen", "akker", "balen", "beeld", "beker",
        "broek", "bruin", "buien", "dalen", "drama", "dreun", "duren", "eerde", "fiets", "garen",
        "gaven", "glans", "graag", "groep", "grond", "halen", "harde", "haven", "hoofd", "hoven",
        "kabel", "kamer", "klein", "knoop", "koers", "kopen", "kleur", "kweek", "lader", "lopen",
        "maten", "meter", "namen", "nemen", "noord", "onder", "plank", "plint", "ploeg", "regen",
        "rijen", "roest", "samen", "schep", "schoo", "schud", "smaak", "slaap", "snoer", "speld",
        "staal", "steek", "stoel", "teken", "trein", "vaart", "vader", "varen", "velen", "vloer",
        "vogel", "vrede", "wegen", "winst", "woord", "zeven", "zomer", "zware", "zweer", "zwier"
        };

        public MainWindow()
        {
            InitializeComponent();
            ResetGame(); // Zorg ervoor dat het spel klaar is om te starten
        }
        // Reset het spel naar de start
        private void ResetGame()
        {
            currentAttempt = 1;
            secretWord = SelectRandomSecretWord(wordList);
            ClearAllTextBoxes();
            FocusNextAttempt(); // Focus op de eerste rij
        }
       
        // Selecteert een nieuw geheimwoord
        private string SelectRandomSecretWord(List<string> wordList)
        {
            Random random = new Random();
            int randomIndex = random.Next(wordList.Count);
            return wordList[randomIndex];
        }
     
        // Logica voor de "Nieuw Spel" knop
        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            ResetGame();        
        }
        // Controleert of de invoer een letter is
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        // Methode voor het verplaatsen van de focus naar het volgende tekstvak
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox currentBox = sender as TextBox;

            if (currentBox.Text.Length == 1)
            {
                MoveFocusToNextTextBox(currentBox);
            }
        }

        // Methode voor het terug verplaatsen van focus bij de backspace toets
        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            TextBox currentBox = sender as TextBox;

            if (e.Key == Key.Back && currentBox.Text == "")
            {
                MoveFocusToPreviousTextBox(currentBox);
            }

            // Controleer of de gebruiker op Enter drukt om de poging te controleren
            if (e.Key == Key.Enter)
            {
                CheckCurrentGuess();
            }
        }

        private void MoveFocusToNextTextBox(TextBox currentBox)
        {
            // Logica om focus te verplaatsen afhankelijk van welke rij momenteel actief is
            if (currentAttempt == 1)
            {
                if (currentBox == LetterBox1_1) LetterBox1_2.Focus();
                else if (currentBox == LetterBox1_2) LetterBox1_3.Focus();
                else if (currentBox == LetterBox1_3) LetterBox1_4.Focus();
                else if (currentBox == LetterBox1_4) LetterBox1_5.Focus();
            }
            else if (currentAttempt == 2)
            {
                if (currentBox == LetterBox2_1) LetterBox2_2.Focus();
                else if (currentBox == LetterBox2_2) LetterBox2_3.Focus();
                else if (currentBox == LetterBox2_3) LetterBox2_4.Focus();
                else if (currentBox == LetterBox2_4) LetterBox2_5.Focus();
            }
            else if (currentAttempt == 3)
            {
                if (currentBox == LetterBox3_1) LetterBox3_2.Focus();
                else if (currentBox == LetterBox3_2) LetterBox3_3.Focus();
                else if (currentBox == LetterBox3_3) LetterBox3_4.Focus();
                else if (currentBox == LetterBox3_4) LetterBox3_5.Focus();
            }
            else if (currentAttempt == 4)
            {
                if (currentBox == LetterBox4_1) LetterBox4_2.Focus();
                else if (currentBox == LetterBox4_2) LetterBox4_3.Focus();
                else if (currentBox == LetterBox4_3) LetterBox4_4.Focus();
                else if (currentBox == LetterBox4_4) LetterBox4_5.Focus();
            }
            else if (currentAttempt == 5)
            {
                if (currentBox == LetterBox5_1) LetterBox5_2.Focus();
                else if (currentBox == LetterBox5_2) LetterBox5_3.Focus();
                else if (currentBox == LetterBox5_3) LetterBox5_4.Focus();
                else if (currentBox == LetterBox5_4) LetterBox5_5.Focus();
            }
            else if (currentAttempt == 6)
            {
                if (currentBox == LetterBox6_1) LetterBox6_2.Focus();
                else if (currentBox == LetterBox6_2) LetterBox6_3.Focus();
                else if (currentBox == LetterBox6_3) LetterBox6_4.Focus();
                else if (currentBox == LetterBox6_4) LetterBox6_5.Focus();
            }
           
        }

        private void MoveFocusToPreviousTextBox(TextBox currentBox)
        {
            // Logica om de focus TERUG te verplaatsen afhankelijk van welke rij actief is
            if (currentAttempt == 1)
            {
                if (currentBox == LetterBox1_5) { LetterBox1_4.Focus(); LetterBox1_4.Clear(); }
                else if (currentBox == LetterBox1_4) { LetterBox1_3.Focus(); LetterBox1_3.Clear(); }
                else if (currentBox == LetterBox1_3) { LetterBox1_2.Focus(); LetterBox1_2.Clear(); }
                else if (currentBox == LetterBox1_2) { LetterBox1_1.Focus(); LetterBox1_1.Clear(); }
            }
            else if (currentAttempt == 2)
            {
                if (currentBox == LetterBox2_5) { LetterBox2_4.Focus(); LetterBox2_4.Clear(); }
                else if (currentBox == LetterBox2_4) { LetterBox2_3.Focus(); LetterBox2_3.Clear(); }
                else if (currentBox == LetterBox2_3) { LetterBox2_2.Focus(); LetterBox2_2.Clear(); }
                else if (currentBox == LetterBox2_2) { LetterBox2_1.Focus(); LetterBox2_1.Clear(); }
            }
            else if (currentAttempt == 3)
            {
                if (currentBox == LetterBox3_5) { LetterBox3_4.Focus(); LetterBox3_4.Clear(); }
                else if (currentBox == LetterBox3_4) { LetterBox3_3.Focus(); LetterBox3_3.Clear(); }
                else if (currentBox == LetterBox3_3) { LetterBox3_2.Focus(); LetterBox3_2.Clear(); }
                else if (currentBox == LetterBox3_2) { LetterBox3_1.Focus(); LetterBox3_1.Clear(); }
            }
            else if (currentAttempt == 4)
            {
                if (currentBox == LetterBox4_5) { LetterBox4_4.Focus(); LetterBox4_4.Clear(); }
                else if (currentBox == LetterBox4_4) { LetterBox4_3.Focus(); LetterBox4_3.Clear(); }
                else if (currentBox == LetterBox4_3) { LetterBox4_2.Focus(); LetterBox4_2.Clear(); }
                else if (currentBox == LetterBox4_2) { LetterBox4_1.Focus(); LetterBox4_1.Clear(); }
            }
            else if (currentAttempt == 5)
            {
                if (currentBox == LetterBox5_5) { LetterBox5_4.Focus(); LetterBox5_4.Clear(); }
                else if (currentBox == LetterBox5_4) { LetterBox5_3.Focus(); LetterBox5_3.Clear(); }
                else if (currentBox == LetterBox5_3) { LetterBox5_2.Focus(); LetterBox5_2.Clear(); }
                else if (currentBox == LetterBox5_2) { LetterBox5_1.Focus(); LetterBox5_1.Clear(); }
            }
            else if (currentAttempt == 6)
            {
                if (currentBox == LetterBox6_5) { LetterBox6_4.Focus(); LetterBox6_4.Clear(); }
                else if (currentBox == LetterBox6_4) { LetterBox6_3.Focus(); LetterBox6_3.Clear(); }
                else if (currentBox == LetterBox6_3) { LetterBox6_2.Focus(); LetterBox6_2.Clear(); }
                else if (currentBox == LetterBox6_2) { LetterBox6_1.Focus(); LetterBox6_1.Clear(); }
            }
        }

        // Controleer het huidige ingevoerde woord en zet kleuren
        private void CheckCurrentGuess()
        {
            string guess = "";

            // Verzamel de letters van de huidige poging
            if (currentAttempt == 1)
            {
                guess = LetterBox1_1.Text + LetterBox1_2.Text + LetterBox1_3.Text + LetterBox1_4.Text + LetterBox1_5.Text;
            }
            else if (currentAttempt == 2)
            {
                guess = LetterBox2_1.Text + LetterBox2_2.Text + LetterBox2_3.Text + LetterBox2_4.Text + LetterBox2_5.Text;
            }
            else if (currentAttempt == 3)
            {
                guess = LetterBox3_1.Text + LetterBox3_2.Text + LetterBox3_3.Text + LetterBox3_4.Text + LetterBox3_5.Text;
            }
            else if (currentAttempt == 4)
            {
                guess = LetterBox4_1.Text + LetterBox4_2.Text + LetterBox4_3.Text + LetterBox4_4.Text + LetterBox4_5.Text;
            }
            else if (currentAttempt == 5)
            {
                guess = LetterBox5_1.Text + LetterBox5_2.Text + LetterBox5_3.Text + LetterBox5_4.Text + LetterBox5_5.Text;
            }
            else if (currentAttempt == 6)
            {
                guess = LetterBox6_1.Text + LetterBox6_2.Text + LetterBox6_3.Text + LetterBox6_4.Text + LetterBox6_5.Text;
            }

            if (guess.Length == 5)
            {
                // Zet de kleuren voor de huidige poging
                ColorLetters(guess.ToLower(), currentAttempt);

                // Controleer of het geraden woord correct is
                if (guess.ToLower() == secretWord)
                {
                    MessageBox.Show("Dit was het woord! Gefeliciteerd!");
                    return; // Stopt het spel
                }

                // Ga naar de volgende poging als er nog meer over zijn
                if (currentAttempt < maxAttempts)
                {
                    currentAttempt++;
                    FocusNextAttempt(); // Focus op de nieuwe rij
                }
                else
                {
                    MessageBox.Show($"Je hebt het woord niet geraden. Het geheime woord was '{secretWord}'.");
                }
            }
            else
            {
                MessageBox.Show("Vul een volledig vijfletterwoord in.");
            }
        }

        // Methode voor de ahtergrond van de tekstblokken een kleur geven
        private void SetTextBoxColor(TextBox textBox, Brush color)
        {
            textBox.Background = color;
        }

       // logica om kleuren te geven op basis van het geheime woord
        private void ColorLetters(string guess, int attempt)
        {
            char[] secretWordArray = secretWord.ToCharArray();
            char[] guessArray = guess.ToCharArray();
            bool[] correctLetters = new bool[5]; // Houd bij welke letters al correct zijn met WAAR/NIETWAAR

            // GROEN checkt de letters die in de juiste positie staan
            for (int i = 0; i < 5; i++)
            {
                if (guessArray[i] == secretWordArray[i])
                {
                    SetTextBoxColor(GetTextBoxForAttempt(attempt, i), new SolidColorBrush((Color)FindResource("CorrectGreen"))); // Green
                    correctLetters[i] = true; // Markeer als correct
                    secretWordArray[i] = '_'; // Markeer als gebruikt
                }
            }

            // GEEL checkt de letters die wel in het woord zitten maar niet op de juiste plek
            for (int i = 0; i < 5; i++)
            {
                if (!correctLetters[i]) // Check de letter alleen als die nog niet correct is
                {
                    if (secretWordArray.Contains(guessArray[i]))
                    {
                        SetTextBoxColor(GetTextBoxForAttempt(attempt, i), new SolidColorBrush((Color)FindResource("PresentYellow"))); // Geel
                        secretWordArray[Array.IndexOf(secretWordArray, guessArray[i])] = '_'; // markeer de letter als gebruikt
                    }
                    else
                    {
                        SetTextBoxColor(GetTextBoxForAttempt(attempt, i), new SolidColorBrush((Color)FindResource("AbsentGray"))); // Grijs
                    }
                }
            }
        }


        // Hulpmethode om de juiste TextBox te verkrijgen op basis van de poging en de positie
        private TextBox GetTextBoxForAttempt(int attempt, int index)
        {
            switch (attempt)
            {
                case 1:
                    return (TextBox)this.FindName($"LetterBox1_{index + 1}");
                case 2:
                    return (TextBox)this.FindName($"LetterBox2_{index + 1}");
                case 3:
                    return (TextBox)this.FindName($"LetterBox3_{index + 1}");
                case 4:
                    return (TextBox)this.FindName($"LetterBox4_{index + 1}");
                case 5:
                    return (TextBox)this.FindName($"LetterBox5_{index + 1}");
                case 6:
                    return (TextBox)this.FindName($"LetterBox6_{index + 1}");
                default:
                    return null;
            }
        }

  
        // Focus op de volgende rij afhankelijk van de poging
        private void FocusNextAttempt()
        {
            if (currentAttempt == 1)
            {
                LetterBox1_1.Focus();
            }
            else if (currentAttempt == 2)
            {
                LetterBox2_1.Focus();
            }
            else if (currentAttempt == 3)
            {
                LetterBox3_1.Focus();
            }
            else if (currentAttempt == 4)
            {
                LetterBox4_1.Focus();
            }
            else if (currentAttempt == 5)
            {
                LetterBox5_1.Focus();
            }
            else if (currentAttempt == 6)
            {
                LetterBox6_1.Focus();
            }
        }


        // Reset de achtergrondkleur van een tekstvak wordt gebruikt in de ClearAllTextBoxes methode
        private void ResetTextBoxBackground(TextBox textBox)
        {
            textBox.Background = Brushes.White; // Reset de kleur van tekstbox naar wit
        }
        // Methode om alle tekstvakken te wissen en de kleuren te resetten
        private void ClearAllTextBoxes()
        {
            // Rij 1
            LetterBox1_1.Clear();
            LetterBox1_2.Clear();
            LetterBox1_3.Clear();
            LetterBox1_4.Clear();
            LetterBox1_5.Clear();
            ResetTextBoxBackground(LetterBox1_1);
            ResetTextBoxBackground(LetterBox1_2);
            ResetTextBoxBackground(LetterBox1_3);
            ResetTextBoxBackground(LetterBox1_4);
            ResetTextBoxBackground(LetterBox1_5);

            // rij 2
            LetterBox2_1.Clear();
            LetterBox2_2.Clear();
            LetterBox2_3.Clear();
            LetterBox2_4.Clear();
            LetterBox2_5.Clear();
            ResetTextBoxBackground(LetterBox2_1);
            ResetTextBoxBackground(LetterBox2_2);
            ResetTextBoxBackground(LetterBox2_3);
            ResetTextBoxBackground(LetterBox2_4);
            ResetTextBoxBackground(LetterBox2_5);

            // rij 3
            LetterBox3_1.Clear();
            LetterBox3_2.Clear();
            LetterBox3_3.Clear();
            LetterBox3_4.Clear();
            LetterBox3_5.Clear();
            ResetTextBoxBackground(LetterBox3_1);
            ResetTextBoxBackground(LetterBox3_2);
            ResetTextBoxBackground(LetterBox3_3);
            ResetTextBoxBackground(LetterBox3_4);
            ResetTextBoxBackground(LetterBox3_5);
            
            // Rij 4
            LetterBox4_1.Clear();
            LetterBox4_2.Clear();
            LetterBox4_3.Clear();
            LetterBox4_4.Clear();
            LetterBox4_5.Clear();
            ResetTextBoxBackground(LetterBox4_1);
            ResetTextBoxBackground(LetterBox4_2);
            ResetTextBoxBackground(LetterBox4_3);
            ResetTextBoxBackground(LetterBox4_4);
            ResetTextBoxBackground(LetterBox4_5);

            //Rij 5
            LetterBox5_1.Clear();
            LetterBox5_2.Clear();
            LetterBox5_3.Clear();
            LetterBox5_4.Clear();
            LetterBox5_5.Clear();
            ResetTextBoxBackground(LetterBox5_1);
            ResetTextBoxBackground(LetterBox5_2);
            ResetTextBoxBackground(LetterBox5_3);
            ResetTextBoxBackground(LetterBox5_4);
            ResetTextBoxBackground(LetterBox5_5);

            //Rij 6
            LetterBox6_1.Clear();
            LetterBox6_2.Clear();
            LetterBox6_3.Clear();
            LetterBox6_4.Clear();
            LetterBox6_5.Clear();
            ResetTextBoxBackground(LetterBox6_1);
            ResetTextBoxBackground(LetterBox6_2);
            ResetTextBoxBackground(LetterBox6_3);
            ResetTextBoxBackground(LetterBox6_4);
            ResetTextBoxBackground(LetterBox6_5);
        }       
    }
}
