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
    /// Logica di interazione per Classifica.xaml
    /// </summary>
    public partial class Classifica : Window
    {
        Tavolo tavolo;
        public Classifica(Tavolo t)
        {
            InitializeComponent();
            tavolo = t;
            List<Giocatore> giocat= tavolo.GetClassifica();
            foreach(Giocatore g in giocat)
            {
                lbxClassifica.Items.Add(g);
            }
        }

        private void Chiudi(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
