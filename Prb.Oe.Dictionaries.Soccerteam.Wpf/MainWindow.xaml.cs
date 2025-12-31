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
        Dictionary<int, string> ReserverseSpelers = new Dictionary <int, string> ();


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

        
        
        public MainWindow()
        {
            InitializeComponent();
            VerbindDictionariesmetLijst();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnAddPlayerToTeam_Click(object sender, RoutedEventArgs e)
        {
            
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
