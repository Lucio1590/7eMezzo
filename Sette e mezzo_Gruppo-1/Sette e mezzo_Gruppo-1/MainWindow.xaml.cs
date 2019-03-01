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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sette_e_mezzo_Gruppo_1
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Tavolo tavolo;
        int n;
        public MainWindow()
        {
            n = 2;
            tavolo = new Tavolo();
            InitializeComponent();
        }

        //private void CreaInterfacciaGiocatori(int NumeroGiocatori)
        //{

        //}

        private void btnSu_Click(object sender, RoutedEventArgs e)
        {
            if (n + 1 > 11)
            {
                MessageBox.Show("Non è possibile aggiungere più di 11 giocatori");
            }
            else
            {
                n++;
                tbxNumeroGiocatori.Text = Convert.ToString(n);
            }
        }

        private void btnGiù_Click(object sender, RoutedEventArgs e)
        {
            if (n - 1 < 2)
            {
                MessageBox.Show("Non è possibile giocare con meno di 2 giocatori");
            }
            else
            {
                n--;
                tbxNumeroGiocatori.Text = Convert.ToString(n);
            }
        }

        private void btnNuovoGioco_Click(object sender, RoutedEventArgs e)
        {
            tavolo.NuovaPartita();
            for(int i=0; i<n; i++)
            {
                
            }
            AggiuntaGiocatori nuova = new AggiuntaGiocatori(n, tavolo);
            nuova.ShowDialog();
        }

        private void btnEsci_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
