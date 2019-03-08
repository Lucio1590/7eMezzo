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
    /// Logica di interazione per WpfTavolo.xaml
    /// </summary>
    public partial class WpfTavolo : Window
    {
        bool puntataCambiata;
        Tavolo tavolo;
        int playerAttuale;
        int cartaAttuale;
        int nPlayers;
        public WpfTavolo(int n,Tavolo t)
        {
            InitializeComponent();
            nPlayers = n;
            tavolo = t;
            puntataCambiata = false;
            playerAttuale = 0;
            cartaAttuale = 0;
            CercaProssimoGiocatore();
            for (int i=0; i<tavolo.Giocatori1.Length; i++)
            {
                if (tavolo.Giocatori1[i] != null)
                {
                    ((TextBlock)FindName("G" + Convert.ToString(i + 1) + "_Denaro")).Text = Convert.ToString(tavolo.Giocatori1[i].Puntata);
                    ((Label)FindName("G" + Convert.ToString(i + 1) + "_Nick")).Content = tavolo.Giocatori1[i].Nick;
                    BitmapImage bim = tavolo.Giocatori1[i].Avatar;
                    ((Image)FindName("G" + Convert.ToString(i + 1) + "_Avatar")).Source = bim;
                }
                else
                {
                    ((Grid)FindName("G" + Convert.ToString(i + 1))).Visibility = Visibility.Hidden;
                }
            }
        }
       

        private void Chiudi(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnEstrai_Click(object sender, RoutedEventArgs e)
        {
            if (!tavolo.AssegnaCartaAGiocatore(tavolo.Giocatori1[playerAttuale]))
            {
                //((Image)FindName("G" + Convert.ToString(playerAttuale + 1) + "_CS")).Source = tavolo.Giocatori1[playerAttuale]._carte[0].PercorsoImmagineCarta;
                if (playerAttuale == 10)
                {
                    cartaAttuale++;
                }
                CercaProssimoGiocatore();
                if (cartaAttuale==1 && !puntataCambiata)
                {
                    int cont=1;
                    puntataCambiata = true;
                    int j = playerAttuale;
                    Giocatore last=tavolo.Giocatori1[playerAttuale];
                    for(int i=0; i<nPlayers; i++)
                    {
                        Puntata nuova = new Puntata(tavolo, playerAttuale);
                        nuova.ShowDialog();
                        ((TextBlock)FindName("G" + Convert.ToString(playerAttuale + 1) + "_Denaro")).Text = Convert.ToString(tavolo.Giocatori1[playerAttuale].Puntata);
                        ((Label)FindName("G" + Convert.ToString(playerAttuale + 1) + "_Nick")).Content = tavolo.Giocatori1[playerAttuale].Nick;
                        CercaProssimoGiocatore();
                    }
                    while(cont!=nPlayers)
                    {
                        CercaProssimoGiocatore();
                        if (tavolo.Giocatori1[playerAttuale].Puntata != last.Puntata)
                        {
                            Puntata nuova = new Puntata(tavolo, playerAttuale);
                            nuova.ShowDialog();
                            ((TextBlock)FindName("G" + Convert.ToString(playerAttuale + 1) + "_Denaro")).Text = Convert.ToString(tavolo.Giocatori1[playerAttuale].Puntata);
                            ((Label)FindName("G" + Convert.ToString(playerAttuale + 1) + "_Nick")).Content = tavolo.Giocatori1[playerAttuale].Nick;
                            cont = 1;
                        }
                        else
                        {
                            cont++;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Inserire Valore per Re di Denara");
                if (playerAttuale == 10)
                {
                    cartaAttuale++;
                }
                CercaProssimoGiocatore();
                if (cartaAttuale == 1 && !puntataCambiata)
                {
                    int cont = 1;
                    puntataCambiata = true;
                    int j = playerAttuale;
                    Giocatore last = tavolo.Giocatori1[playerAttuale];
                    for (int i = 0; i < nPlayers; i++)
                    {
                        Puntata nuova = new Puntata(tavolo, playerAttuale);
                        nuova.ShowDialog();
                        CercaProssimoGiocatore();
                    }
                    while (cont != nPlayers)
                    {
                        CercaProssimoGiocatore();
                        if (tavolo.Giocatori1[playerAttuale].Puntata != last.Puntata)
                        {
                            Puntata nuova = new Puntata(tavolo, playerAttuale);
                            nuova.ShowDialog();
                            cont = 1;
                        }
                        else
                        {
                            cont++;
                        }
                    }
                }
            }
        }

        public void CercaProssimoGiocatore()
        {
            if (playerAttuale == 10)
            {
                playerAttuale = 0;
            }
            else
            {
                playerAttuale++;
            }
            for (int i = playerAttuale; i < tavolo.Giocatori1.Length; i++)
            {
                if (tavolo.Giocatori1[i] != null)
                {
                    break;
                }
                playerAttuale++;
            }
        }

        private void LAscia(object sender, RoutedEventArgs e)
        {
            playerAttuale++;
            cartaAttuale = 1;
            if (playerAttuale == 10)
            {
                Classifica nuova = new Classifica(tavolo);
            }
        }
    }
}
