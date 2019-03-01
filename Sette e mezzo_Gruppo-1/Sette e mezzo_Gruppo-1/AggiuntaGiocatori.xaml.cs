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
    /// Logica di interazione per AggiuntaGiocatori.xaml
    /// </summary>
    public partial class AggiuntaGiocatori : Window
    {
        Tavolo t;
        int n;
        List<TextBox> testboxes;
        public AggiuntaGiocatori(int nP, Tavolo tavolo)
        {
            testboxes = new List<TextBox>();
            /*foreach(UIElement u in this.)
            for(int i=0; i<11; i++)
            {
                testboxes.Add()
            }*/
            testboxes.Add(tbx_1);
            testboxes.Add(tbx_2);
            testboxes.Add(tbx_3);
            testboxes.Add(tbx_4);
            testboxes.Add(tbx_5);
            testboxes.Add(tbx_6);
            testboxes.Add(tbx_7);
            testboxes.Add(tbx_8);
            testboxes.Add(tbx_9);
            testboxes.Add(tbx_10);
            testboxes.Add(tbx_11);
            n = nP;
            t = tavolo;
            InitializeComponent();
        }
        

        private void AggiungiOrRimuovi(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            string[] el = b.Name.Split('_');
            int pos = Convert.ToInt32(el[1]);
            if (b.Background == Brushes.Red)
            {
                MessageBoxResult result = MessageBox.Show("Sicuro di voler rimuovere il giocatore?", "Conferma", MessageBoxButton.YesNo);
                if (result.Equals(MessageBoxResult.Yes))
                {
                    t.Giocatori1[pos] = null;
                    b.Background = Brushes.Yellow;
                }
            }
            else
            {
                Giocatore g = new Giocatore(testboxes[pos-1].Text);
                t.AggiungiGiocatore(g, pos);
                b.Background = Brushes.Red;
            }
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnNuova_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AggiornaLista(object sender, TextChangedEventArgs e)
        {
            TextBox text = sender as TextBox;
            string[] el = text.Name.Split('_');
            MessageBox.Show(el[1]);
        }
    }
}
