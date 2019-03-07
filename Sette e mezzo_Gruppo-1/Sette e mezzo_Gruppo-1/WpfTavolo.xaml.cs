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
        Tavolo tavolo;
        int n;
        public WpfTavolo(int nP, Tavolo t)
        {
            InitializeComponent();
            tavolo = t;
            n = nP;
            for (int i=0; i<n; i++)
            {
                if (t.Giocatori1[i] != null)
                {
                    Puntata nuova = new Puntata(tavolo, i);
                    nuova.ShowDialog();
                }
            }
        }
       

        private void Chiudi(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
