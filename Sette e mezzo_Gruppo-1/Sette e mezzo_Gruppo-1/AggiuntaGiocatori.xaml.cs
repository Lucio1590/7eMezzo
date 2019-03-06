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
        List<Button> buttons;
        public AggiuntaGiocatori(Tavolo tavolo)
        {
            InitializeComponent();
            n = 1;
            testboxes = new List<TextBox>();
            buttons = new List<Button>();
            for(int i=0; i<11; i++)
            {
                ((ListBox)FindName("lblAvatars_" + i + 1)).Items.Add(t.PathImages);
            }
            /*foreach(UIElement u in this.)
            for(int i=0; i<11; i++)
            {
                testboxes.Add()
            }*/

            buttons.Add(btn_1);
            buttons.Add(btn_2);
            buttons.Add(btn_3);
            buttons.Add(btn_4);
            buttons.Add(btn_5);
            buttons.Add(btn_6);
            buttons.Add(btn_7);
            buttons.Add(btn_8);
            buttons.Add(btn_9);
            buttons.Add(btn_10);
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
            t = tavolo;
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
                    b.Foreground = Brushes.Black;
                    b.Content = "✚";
                    ((TextBox)this.FindName("tbx_" + pos)).Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF858585"));
                    ((TextBox)this.FindName("tbx_" + pos)).Text = "Nick...";
                    buttons[pos - 1] = b;
                    n--;
                }
            }
            else
            {
                try
                {
                    if (((TextBox)this.FindName("tbx_" + pos)).Text == "" || ((TextBox)this.FindName("tbx_" + pos)).Text == "Nick...")
                    {
                        throw new Exception("Errore nell'inserimento del nickname");
                    }
                    else
                    {
                        Giocatore g = new Giocatore(testboxes[pos - 1].Text);
                        t.AggiungiGiocatore(g, pos);
                        ((ListBox)FindName("lblAvatars_" + pos)).Visibility = Visibility.Hidden;
                        MessageBox.Show("Giocatore inserito con successo");
                        b.Background = Brushes.Red;
                        b.Content = "X";
                        b.Foreground = Brushes.White;
                        buttons[pos - 1] = b;
                        n++;
                    }
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnNuova_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (n < 2)
                {
                    throw new Exception("Non è possibile giocare con meno di due giocatori");
                }else if(tbx_11.Text == "")
                {
                    throw new Exception("Errore nell'inserimento del nome del mazziere");
                }
                WpfTavolo nuova = new WpfTavolo(n,t);
                nuova.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AggiornaLista(object sender, TextChangedEventArgs e)
        {
            TextBox text = sender as TextBox;
            string[] el = text.Name.Split('_');
            if (text.Text == "")
            {
                text.Foreground = Brushes.Black;
            }
        }
        
    }
}
