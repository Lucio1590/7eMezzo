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
    /// Logica di interazione per Conferma.xaml
    /// </summary>
    public partial class Conferma : Window
    {
        Tavolo t;
        int pos;
        Button b;
        TextBox textBox;
        public Conferma(Tavolo tavolo, int posizione, Button bB, TextBox tb)
        {
            InitializeComponent();
            t = tavolo;
            pos = posizione;
            b = bB;
            textBox = tb;
        }
        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            
            Close();
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
