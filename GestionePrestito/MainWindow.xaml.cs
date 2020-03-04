using System;
using System.Collections.Generic;
using System.IO;
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

namespace GestionePrestito
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        int rate;
        int importo;
        int perc;
        int calcoloperc;
        int importores;
        int imprata;
        List<string> riepiloghi = new List<string>();
        string cognome;
        string nome;
        string nat;
        string citta;
        string rep1;
        string rep2;
        const string file = ("stat.csv");
        private void txtcalcola_Click(object sender, RoutedEventArgs e)

        {
            rate = int.Parse(txtrate.Text);
            importo = int.Parse(txtimporto.Text);
            perc = int.Parse(txtpercentuale.Text);
            calcoloperc = (perc * importo) / 100;
            importores = importo + calcoloperc;
            lblrestituire.Content = importores;
            imprata = importores / rate;
            lblimprata.Content = imprata;

        }

        private void txtstampa_Click(object sender, RoutedEventArgs e)
        {
            cognome = txtcognome.Text;
            nome = txtnome.Text;

            if (rdbf.IsChecked == true)
            {
                nat = "nata";
            }
            else
                nat = "nato";
            citta = txtcitta.Text;
             rate = int.Parse(txtrate.Text);
             importo = int.Parse(txtimporto.Text);
             perc = int.Parse(txtpercentuale.Text);
             calcoloperc = (perc * importo) / 100;
             importores = importo + calcoloperc;
             imprata = importores / rate;
             rep1= ($"{cognome} {nome}, residente in {citta} {nat} il {datapicker.SelectedDate}; prestito di {importo} ad un tasso del {perc}% da rstituire in {rate} rate da {imprata}€ ciascuna, per un totale di {importores}€.");
            rep2 = $"{cognome};{nome};{citta};{nat};{datapicker.SelectedDate};{importo};{perc};{rate};{imprata};{importores}";
            lblresult.Content = (rep1);
            riepiloghi.Add(rep2);


        }

        private void txtnuovo_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter w = new StreamWriter(file);
            w.WriteLine("cognome;nome;città;sesso;data;importo richiesto;percentuale interessi;numero rate;importo singola rata;importo da restituire");

            for (int i = 0; i < riepiloghi.Count; i++)
            {
                {
                    w.WriteLine(riepiloghi[i]);
                }
            
            }
            w.Flush();
            w.Close();
        }
    }
} 
