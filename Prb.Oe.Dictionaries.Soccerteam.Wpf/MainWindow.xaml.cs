using System;
using System.Collections.Generic;
using System.Linq;
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
            RefreshAlleLijsten();
        }


        public void WeergaveMethode(int sleutel, Dictionary<int, string> relevantewoordenboek )
        {
            if (sleutel > 0)
            {
                string spelernaam = relevantewoordenboek[sleutel];
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
         
                }
            }
        }


        public void RefreshAlleLijsten()
        {

            lstTeam.ItemsSource = null;
            lstTeam.ItemsSource = HeleTeam.Values.ToList();
            lstTeam.Items.Refresh();

            lstTeamNumbers.ItemsSource = null;
            lstTeamNumbers.ItemsSource = HeleTeam.Keys.ToList();
            lstTeamNumbers.Items.Refresh();

            lstTeamNextGame.ItemsSource = null;
            lstTeamNextGame.ItemsSource = WedstrijdTeam.Keys.ToList();
            lstTeamNextGame.Items.Refresh();


            lstReserveNextGame.ItemsSource = null;
            lstReserveNextGame.ItemsSource = ReserverseSpelers.Keys.ToList();
            lstReserveNextGame.Items.Refresh();
       
        }



    void VoegSpelersToeAanAnderTeam(int sleutel, Dictionary<int, string> mijnoudewoordenboek, Dictionary<int, string> mijnnieuwewoordeboek)
        {
            if (sleutel <= 0)
            {
                MessageBox.Show("Selecteer eerst een speler", "Missende gegegevens", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            else if (sleutel > 0)
            {
                mijnnieuwewoordeboek.Add(sleutel, mijnoudewoordenboek[sleutel]);
                mijnoudewoordenboek.Remove(sleutel);
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
            if (lstTeamNumbers.SelectedItem != null)
            {
                int sleutel = (int)lstTeamNumbers.SelectedItem;
                VoegSpelersToeAanAnderTeam(sleutel, HeleTeam, WedstrijdTeam);
                RefreshAlleLijsten();

            }
            else if (WedstrijdTeam.Count == 11)
            {
                MessageBox.Show("Je team mag niet meer dan 11 spelers bevatten", "Max spelers bereikt", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
            else 
            {
                MessageBox.Show("Selecteer eerst een speler a.u.b", "Missende gegevens", MessageBoxButton.OK, MessageBoxImage.Hand);
            }

        }

        

        private void BtnAddPlayerToReserveNextGame_Click(object sender, RoutedEventArgs e)
        {

            if (lstTeamNumbers.SelectedItem != null)
            {
                int sleutel = (int)lstTeamNumbers.SelectedItem;
                VoegSpelersToeAanAnderTeam(sleutel, HeleTeam, ReserverseSpelers);
                RefreshAlleLijsten();
            }
            else if (ReserverseSpelers.Count == 7)
            {
                MessageBox.Show("Je mag niet meer dan 7 reserve spelers hebben", "Max spelers bereikt", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
            else
            {
                MessageBox.Show("Selecteer eerst een speler a.u.b", "Missende gegevens", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
           


        }

        private void BtnRemovePlayerFromTeamNextGame_Click(object sender, RoutedEventArgs e)
        {

            if (lstTeamNextGame.SelectedItem != null)
            {
                int sleutel = (int)lstTeamNextGame.SelectedItem;
                VoegSpelersToeAanAnderTeam(sleutel, WedstrijdTeam, HeleTeam);
                RefreshAlleLijsten();
            }
            else
            {
                MessageBox.Show("Selecteer eerst een speler a.u.b", "Missende gegevens", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
        

        }

        private void BtnMovePlayerToReserveNextGame_Click(object sender, RoutedEventArgs e)
        {

            if (lstTeamNextGame.SelectedItem != null)
            {
                int sleutel = (int)lstTeamNextGame.SelectedItem;
                VoegSpelersToeAanAnderTeam(sleutel, WedstrijdTeam, ReserverseSpelers);
                RefreshAlleLijsten();
            }
            else if (ReserverseSpelers.Count == 7)
            {
                MessageBox.Show("Je mag niet meer dan 7 reserve spelers hebben", "Max spelers bereikt", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
            else
            {
                MessageBox.Show("Selecteer eerst een speler a.u.b", "Missende gegevens", MessageBoxButton.OK, MessageBoxImage.Hand);
            }

          
        }

        private void BtnRemovePlayerFromReserveNextGame_Click(object sender, RoutedEventArgs e)
        {

            if (lstReserveNextGame.SelectedItem != null)
            {
                int sleutel = (int)lstReserveNextGame.SelectedItem;
                VoegSpelersToeAanAnderTeam(sleutel, ReserverseSpelers, HeleTeam);
                RefreshAlleLijsten();
            }
            else
            {
                MessageBox.Show("Selecteer eerst een speler a.u.b", "Missende gegevens", MessageBoxButton.OK, MessageBoxImage.Hand);
            }

         
        }

        private void BtnMovePlayerToTeamNextGame_Click(object sender, RoutedEventArgs e)
        {

            if (lstReserveNextGame.SelectedItem != null)
            {
                int sleutel = (int)lstReserveNextGame.SelectedItem;
                VoegSpelersToeAanAnderTeam(sleutel, ReserverseSpelers, WedstrijdTeam);
                RefreshAlleLijsten();

            }
            else if (WedstrijdTeam.Count == 11)
            {
                MessageBox.Show("Je team mag niet meer dan 11 spelers bevatten", "Max spelers bereikt", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
            else
            {
                MessageBox.Show("Selecteer eerst een speler a.u.b", "Missende gegevens", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
       
        }

        private void LstTeamNumbers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (lstTeamNumbers.SelectedItem != null)
            {
                int sleutel = (int)lstTeamNumbers.SelectedItem;
                WeergaveMethode(sleutel, HeleTeam);
            }
           
        }

        private void LstTeamNextGame_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (lstTeamNextGame.SelectedItem != null)
            {
                int sleutel = (int)lstTeamNextGame.SelectedItem;
                WeergaveMethode(sleutel, WedstrijdTeam);
            }

        }

        private void LstReserveNextGame_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstReserveNextGame.SelectedItem != null)
            {
                int sleutel = (int)lstReserveNextGame.SelectedItem;
                WeergaveMethode(sleutel, ReserverseSpelers);
            }
        }
    }
}
