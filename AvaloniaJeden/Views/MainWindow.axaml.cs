using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using JetBrains.Annotations;
using Splat;
using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing.Text;
using System.IO;
using Xceed.Wpf.Toolkit;

namespace AvaloniaJeden.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        public string conString = "Data Source=KAROLINA-LAPTOP;Initial Catalog=TravelPlans;Integrated Security=True";
        private void UtworzPlan_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ZapiszDoBazyDanych();
                Clean();
                Zapisz_Click();
              
            }
            catch (Exception ex)
            {
                Error error = new();
                error.Show();
            }
        }

        private void ZapiszDoBazyDanych()
        {
            try {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    con.Open();
                    if (con.State == System.Data.ConnectionState.Open)
                    {
                        string query = "INSERT INTO Informacje (Nazwa, Miejsce, DataPoczatkowa, DataKoncowa, Hotel, CheckIn, CheckOut, Adres, SrodekTransportu, Godzina, NrBiletu) " +
                                       "VALUES (@Nazwa, @Miejsce, @DataPoczatkowa, @DataKoncowa, @Hotel, @CheckIn, @CheckOut, @Adres, @SrodekTransportu, @Godzina, @NrBiletu)";

                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@Nazwa", NazwaPlanu.Text);
                        cmd.Parameters.AddWithValue("@Miejsce", Miejsce.Text);
                        cmd.Parameters.AddWithValue("@DataPoczatkowa", DataPoczatkowa.Text);
                        cmd.Parameters.AddWithValue("@DataKoncowa", DataKoncowa.Text);
                        cmd.Parameters.AddWithValue("@Hotel", Hotel.Text);
                        cmd.Parameters.AddWithValue("@CheckIn", CheckIn.Text);
                        cmd.Parameters.AddWithValue("@CheckOut", CheckOut.Text);
                        cmd.Parameters.AddWithValue("@Adres", Adres.Text);
                        cmd.Parameters.AddWithValue("@SrodekTransportu", SrodekTransportu.Text);
                        cmd.Parameters.AddWithValue("@Godzina", Godzina.Text);
                        cmd.Parameters.AddWithValue("@NrBiletu", NrBiletu.Text);

                        cmd.ExecuteNonQuery();
                        Debug.WriteLine("Dane zostały zapisane do tabeli 'Informacje' w bazie danych.");

                        string query2 = "INSERT INTO Atrakcje (Nazwa, Atrakcje) VALUES (@Nazwa, @Atrakcje)";
                        SqlCommand com = new SqlCommand(query2, con);
                        com.Parameters.AddWithValue("@Nazwa", NazwaPlanu.Text);
                        com.Parameters.AddWithValue("@Atrakcje", Atrakcje.Text);

                        com.ExecuteNonQuery();
                        Debug.WriteLine("Dane zostały zapisane do tabeli 'Atrakcje' w bazie danych.");

                        string query3 = "INSERT INTO Dane (Nazwa, NrDowodu, NrPaszportu, NrLegStud,NrUbezpieczenia,NrRezerwacji) VALUES (@Nazwa, @NrDowodu, @NrPaszportu, @NrLegStud, @NrUbezpieczenia, @NrRezerwacji)";
                        SqlCommand comm = new SqlCommand(query3, con);
                        comm.Parameters.AddWithValue("@Nazwa", NazwaPlanu.Text);
                        comm.Parameters.AddWithValue("@NrDowodu", NrDowodu.Text);
                        comm.Parameters.AddWithValue("@NrPaszportu", NrPaszportu.Text);
                        comm.Parameters.AddWithValue("@NrLegStud", NrLegStud.Text);
                        comm.Parameters.AddWithValue("@NrUbezpieczenia", NrUbezpieczenia.Text);
                        comm.Parameters.AddWithValue("@NrRezerwacji", NrRezerwacji.Text);
                        comm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Error error = new();
                error.Show();
            }


            
        }

        public void Clean()
        {
            NazwaPlanu.Text = String.Empty;
            Miejsce.Text = String.Empty;
            DataPoczatkowa.Text = String.Empty;
            DataKoncowa.Text = String.Empty;
            Hotel.Text = String.Empty;
            CheckIn.Text = String.Empty;
            CheckOut.Text = String.Empty;
            Adres.Text = String.Empty;
            SrodekTransportu.Text = String.Empty;
            Godzina.Text = String.Empty;
            NrBiletu.Text = String.Empty;
            Atrakcje.Text = String.Empty;
            NrDowodu.Text = String.Empty;
            NrPaszportu.Text = String.Empty;
            NrLegStud.Text = String.Empty;
            NrUbezpieczenia.Text = String.Empty;
            NrRezerwacji.Text = String.Empty;
            Debug.WriteLine("DZIALAAAAAAAAAAAAAAAAAAAAJ");
        }


        private void Czysc_Click(object sender, RoutedEventArgs e)
        {
            Clean();
        }


        private void ZapisDoPliku(string zapisanaPodroz, string dane)
        {
            using (StreamWriter writer = new StreamWriter(zapisanaPodroz))
            {
                writer.WriteLine(dane);
            }
        }
        private void Zapisz_Click()
        {
            try
            {
                string zapisanaPodroz = "C:\\Users\\Karolina\\OneDrive\\Desktop\\ATH\\sem4\\zapisanaPodroz.txt";
                string nazwaPlanu = NazwaPlanu.Text;
                string miejscowosc = Miejsce.Text;
                string dataPoczatkowa = DataPoczatkowa.Text;
                string dataKoncowa = DataKoncowa.Text;
                string hotel = Hotel.Text;
                string checkIn = CheckIn.Text;
                string checkOut = CheckOut.Text;
                string adres = Adres.Text;
                string srodektransportu = SrodekTransportu.Text;
                string godzina = Godzina.Text;
                string nrBiletu = NrBiletu.Text;
                string atrakcje = Atrakcje.Text;
                string nrDowodu = NrDowodu.Text;
                string nrPaszportu = NrPaszportu.Text;
                string nrLegStud = NrLegStud.Text;
                string nrUbezpieczenia = NrUbezpieczenia.Text;
                string nrRezerwacji = NrRezerwacji.Text;


                string dane = $"Szczegóły dotyczące twojej podróży {nazwaPlanu}\n" +
                    $"Destynacja: {miejscowosc}\n" +
                    $"Data od {dataPoczatkowa} do {dataPoczatkowa}\n" +
                    $"Nazwa hotelu: {hotel}\n" +
                    $"Adres hotelu: {adres}\n" +
                    $"Pobyt w hotelu od {checkIn} do {checkOut}\n" +
                    $"Użyty środek transportu: {srodektransportu}\n" +
                    $"Numer biletu: [{nrBiletu}\n" +
                    $"Godzina odjazdu: {godzina}\n" +
                    $"Zaplanowane atrakcje: {atrakcje}\n" +
                    "------------------------\n" +
                    $"Numer dowodu osobistego: {nrDowodu}\n" +
                    $"Numer paszportu: {nrPaszportu}\n" +
                    "Numer legitymacji studenckiej: {nrLegStud}\n" +
                    $"Numer ubezpieczenia: {nrUbezpieczenia}\n" +
                    $"Numer rezerwacji: {nrRezerwacji}" +
                    "Życzymy udanej i bezpiecznej podróży!";

                ZapisDoPliku(zapisanaPodroz, dane);
            }
            catch (Exception ex)
            {
                Error error = new();
                error.Show();
            }

            
        }

    }
}




