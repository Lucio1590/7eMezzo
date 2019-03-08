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
using System.Windows.Shapes;

namespace Sette_e_mezzo_Gruppo_1
{
    /// <summary>
    /// Logica di interazione per Puntata.xaml
    /// </summary>
    public partial class Puntata : Window
    {
        Tavolo tavolo;
        int indicePlayer;
        int attuale;
        public Puntata(Tavolo t, int i)
        {
            InitializeComponent();
            tavolo = t;
            indicePlayer = i;
            attuale = 10;
            lblGiocatore.Content = tavolo.Giocatori1[i].Soldi;
            lblNomeGiocatore.Content = tavolo.Giocatori1[i].Nick;
            lblTavolo.Content = tavolo.PuntataAttuale;
        }

        private void btnSu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (attuale >= 100)
                {
                    throw new Exception("Impossibile puntare più di 100");
                }
                else
                {
                    attuale++;
                    tbxPuntata.Text = Convert.ToString(attuale);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ChiudiFinestra(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Conferma(object sender, RoutedEventArgs e)
        {
            tavolo.Giocatori1[indicePlayer].Puntata = attuale;
            try
            {
                if (attuale < tavolo.PuntataAttuale)
                {
                    throw new Exception("Sei un pirla");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (attuale > tavolo.PuntataAttuale)
            {
                tavolo.PuntataAttuale = attuale;
            }
            Close();
        }

        private void Abbandona(object sender, RoutedEventArgs e)
        {
            tavolo.Giocatori1[indicePlayer].Puntata = 0;
            Close();
        }

        private void btnGiu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (attuale <= 10)
                {
                    throw new Exception("Impossibile puntare meno della puntata minima");
                }
                else
                {
                    attuale--;
                    tbxPuntata.Text = Convert.ToString(attuale);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
