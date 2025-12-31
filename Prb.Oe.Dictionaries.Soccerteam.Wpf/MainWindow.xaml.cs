using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Prb.Oe.Dictionaries.Soccerteam.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    
    public partial class MainWindow : Window
    {
        Dictionary <int, string> HeleTeam = new Dictionary <int, string> ();
        Dictionary<int, string> WedstrijdTeam = new Dictionary <int, string> ();
        Dictionary<int, string> ReserverseSpelers = new Dictionary<int, string>();
    
        
        public MainWindow()
        {
            InitializeComponent();
            VerbindDictionariesmetLijst();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }


        // ALLE  MIJN METHODES ZIJN HIER ++++++++++++++++++++++++++++++++++++>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        // ALLE  MIJN METHODES ZIJN HIER ++++++++++++++++++++++++++++++++++++>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        // ALLE  MIJN METHODES ZIJN HIER ++++++++++++++++++++++++++++++++++++>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        // ALLE  MIJN METHODES ZIJN HIER ++++++++++++++++++++++++++++++++++++>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>



        public void VerbindDictionariesmetLijst()
        {
            MaakNepVoetballers();
            lstTeamNumbers.ItemsSource = HeleTeam.Keys;
            lstTeam.ItemsSource = HeleTeam.Values;
            lstTeamNextGame.ItemsSource = WedstrijdTeam;
            lstReserveNextGame.ItemsSource = ReserverseSpelers;
        }


        public void WeergaveMethode(int sleutel)
        {
            if (sleutel > 0)
            {
                string spelernaam = HeleTeam[sleutel];
                lblPlayerName.Content = spelernaam;
                lblPlayerNumber.Content = sleutel;
            }
        }

        public void MaakNepVoetballers()
        {
            HeleTeam.Add(12, "Lionel Messi");
            HeleTeam.Add(22, "Cristiano Ronaldo");
            HeleTeam.Add(18, "Kylian Mbappé");
            HeleTeam.Add(44, "Kevin De Bruyne");

            lstTeam.Items.Refresh();
        }


        public void VoegNieuweSpelerToe()
        {
            if (!int.TryParse(txtPlayerNumber.Text, out var key))
            {
                MessageBox.Show("Vul aub een geldig nummer in", "Verkeerde gegegevens", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (txtPlayerNumber.Text == string.Empty)
            {
                MessageBox.Show("Er is geen nummer ingevuld", "Missende gegegevens", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (txtPlayerName.Text == string.Empty)
            {
                MessageBox.Show("Er is geen naam ingevuld", "Missende gegegevens", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            else if (int.TryParse(txtPlayerName.Text, out var verkeerdespelernaam))
            {
                MessageBox.Show("Spelernaam mag geen nummer zijn", "Verkeerde gegegevens", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
           
                int sleutel = Int32.Parse(txtPlayerNumber.Text.Trim());
                string spelernaam = txtPlayerName.Text.Trim();

                if (HeleTeam.ContainsKey(sleutel))
                {
                    MessageBox.Show("Er bestaat al een speler met dit nummer", "Verkeerde gegegevens", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    HeleTeam.Add(sleutel, spelernaam);
                    lstTeam.Items.Refresh();
                    lstTeamNumbers.Items.Refresh();
                }
            }
        }


        // ALLE  MIJN EVENTHANDLERS ZIJN HIER ++++++++++++++++++++++++++++++++++++>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        // ALLE  MIJN EVENTHANDLERS ZIJN HIER ++++++++++++++++++++++++++++++++++++>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        // ALLE  MIJN EVENTHANDLERS ZIJN HIER ++++++++++++++++++++++++++++++++++++>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        // ALLE  MIJN EVENTHANDLERS ZIJN HIER ++++++++++++++++++++++++++++++++++++>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

        private void BtnAddPlayerToTeam_Click(object sender, RoutedEventArgs e)
        {
            VoegNieuweSpelerToe();
        }

        private void BtnAddPlayerToTeamNextGame_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnAddPlayerToReserveNextGame_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnRemovePlayerFromTeamNextGame_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnMovePlayerToReserveNextGame_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnRemovePlayerFromReserveNextGame_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnMovePlayerToTeamNextGame_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void LstTeamNumbers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int sleutel = (int)lstTeamNumbers.SelectedItem;
            WeergaveMethode(sleutel);
        }

        private void LstTeamNextGame_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void LstReserveNextGame_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
