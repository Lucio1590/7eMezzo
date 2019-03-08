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
            t = tavolo;
            n = 1;
            testboxes = new List<TextBox>();
            buttons = new List<Button>();
            for(int i=0; i<11; i++)
            {
                for (int j = 0; j < 21; j++)
                {
                    foreach (BitmapImage bim in t.PathImages)
                    {

                        Image imagine = new Image();
                        Uri uuri = new Uri("Giocatori/user" + j + ".png", UriKind.Relative);
                        BitmapImage bimg = new BitmapImage(uuri);
                        imagine.Source = bimg;

                        ((ListBox)FindName("lbxAvatars_" + Convert.ToString(i + 1))).Items.Add(imagine);
                    }
                }
            }

            for(int i=1; i < n+1; i++)
            {
                testboxes.Add((TextBox)this.FindName("tbx_" + i));
            }

            for (int i = 1; i < n; i++)
            {
                buttons.Add((Button)this.FindName("btn_" + i));
            }
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
                    t.Giocatori1[pos-1] = null;
                    b.Background = Brushes.Yellow;
                    b.Foreground = Brushes.Black;
                    b.Content = "✚";
                    ((TextBox)this.FindName("tbx_" + pos)).Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF858585"));
                    ((TextBox)this.FindName("tbx_" + pos)).Text = "Nick...";
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
                        Giocatore g = new Giocatore(((TextBox)this.FindName("tbx_" + pos)).Text);
                        g.Avatar = ((ListBox)FindName("lbxAvatars_" + Convert.ToString(pos + 1))).SelectedItem as BitmapImage;
                        t.AggiungiGiocatore(g, pos);
                        ((ListBox)FindName("lbxAvatars_" + pos)).Visibility = Visibility.Hidden;
                        MessageBox.Show("Giocatore inserito con successo");
                        b.Background = Brushes.Red;
                        b.Content = "X";
                        b.Foreground = Brushes.White;
                        //buttons[pos - 1] = b;
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
                Mazziere m = new Mazziere(tbx_11.Text);
                t.AggiungiMazziere(m);
                WpfTavolo nuova = new WpfTavolo(n,t);
                nuova.ShowDialog();
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
