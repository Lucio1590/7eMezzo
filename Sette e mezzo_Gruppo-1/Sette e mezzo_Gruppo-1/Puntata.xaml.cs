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
        }

        private void btnSu_Click(object sender, RoutedEventArgs e)
        {
            if (attuale <= 10)
            {
                throw new Exception("Impossibile puntare meno della puntata minima");
            }
        }
    }
}
