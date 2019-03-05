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
        public MainWindow()
        {
            tavolo = new Tavolo();
            InitializeComponent();
        }

        //private void CreaInterfacciaGiocatori(int NumeroGiocatori)
        //{

        //}
        

        private void btnNuovoGioco_Click(object sender, RoutedEventArgs e)
        {
            tavolo.NuovaPartita();
            AggiuntaGiocatori nuova = new AggiuntaGiocatori(tavolo);
            nuova.ShowDialog();
        }

        private void btnEsci_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
