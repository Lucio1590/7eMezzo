using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows;
/*using System.ComponentModel.TypeConverter(typeof(System.Drawing.ImageConverter));
using System.Runtime.InteropServices.ComVisible(true);
using System.Serializable;
using System.ComponentModel.TypeConverter("System.Drawing.ImageConverter, System.Windows.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51");
*/
namespace Sette_e_mezzo_Gruppo_1
{
    public class Tavolo
    {
        Giocatore [] _giocatori;
        Mazziere _mazziere;
        List<BitmapImage> _pathImages;
        public Tavolo()
        {
            PathImages= new List<BitmapImage>();
            for(int i=0; i<22; i++)
            {
                Uri u = new Uri("Giocatori/user" + i + ".png", UriKind.Relative);
                BitmapImage im = new BitmapImage(u);
                PathImages.Add(im);
            }
            Giocatori1 = new Giocatore[11];
            for(int i=0; i<Giocatori1.Length; i++)
            {
                Giocatori1[i] = null;
            }
        }
        public Giocatore[] Giocatori1 { get => _giocatori; set => _giocatori = value; }
        public List<BitmapImage> PathImages { get => _pathImages; set => _pathImages = value; }

        /// <summary>
        /// Metodo che viene richiamato con l'avvio di una nuova partita,
        /// si occupa di azzerare la puntata di ogni giocatore , 
        /// togliere ogni carta da ogni giocatore 
        /// e il richiamo del metodo del cambio mazziere poichè 
        /// ad ogni partita il mazziere cambia 
        /// </summary>
        public void NuovaPartita()
        {
            foreach (Giocatore g in Giocatori1)
            {
                if (ControllaAccettazioneGiocatore(g))
                {
                    //azzera puntata
                    g.Puntata = 0;
                    //togli carte dai giocatori 
                    foreach (Carta c in g._carte)
                    {
                        g._carte.Remove(c);
                    }
                }
                else
                {
                    RimuoviGiocatore(g);
                }
            }
            //richiama cambio mazziere 
            CambiaMazziere();
        }
        
        /// <summary>
        /// Metodo di rimozione di un giocatore
        /// </summary>
        /// <returns></returns>
        private void RimuoviGiocatore(Giocatore g)
        {
            for(int i=0; i<Giocatori1.Length; i++)
            {
                if (Giocatori1[i] == g)
                {
                    Giocatori1[i] = null;
                }
            }
        }
        /// <summary>
        /// Metodo di Aggiunta di un giocatore
        /// </summary>
        /// <param name="g"></param>
        public void AggiungiGiocatore(Giocatore g, int pos)
        {
            Giocatori1[pos-1] = g;
        }
        /// <summary>
        /// Metodo di cambio del mazziere e di slittamento di tutti i giocatori all'interno dell'array
        /// </summary>

        public void CambiaMazziere()
        {
            for(int i=0; i<Giocatori1.Length; i++)
            {
                if(Giocatori1[i] is Mazziere)
                {
                    Giocatore aus=null;
                    for(int j=0; j<i; j++)
                    {
                        if (j == 0)
                        {
                            aus = Giocatori1[Giocatori1.Length - 1];
                            Giocatori1[Giocatori1.Length - 1] = Giocatori1[j];
                        }
                        else
                        {
                            Giocatori1[j - 1] = Giocatori1[j];
                            Giocatori1[j] = null;
                        }
                    }
                    if (i != Giocatori1.Length - 1)
                    {
                        Mazziere m = new Mazziere(Giocatori1[i+1].Nick, Giocatori1[i+1].Soldi);
                        Giocatore g = new Giocatore(Giocatori1[i].Nick, Giocatori1[i].Soldi);
                        Giocatori1[i] = m;
                        _mazziere = m;
                        Giocatori1[i - 1] = g;
                    }
                    else
                    {
                        Mazziere m = new Mazziere(Giocatori1[0].Nick, Giocatori1[0].Soldi);
                        Giocatore g = new Giocatore(Giocatori1[i].Nick, Giocatori1[i].Soldi);
                        Giocatori1[Giocatori1.Length] = m;
                        _mazziere = m;
                        Giocatori1[i - 1] = g;
                    }
                    for(int j=i+1; j<Giocatori1.Length; j++)
                    {
                        if (j == Giocatori1.Length - 1 && aus!=null)
                        {
                            Giocatori1[j] = aus;
                        }
                    }
                    break;
                }
            }
        }

        public void AssegnaValoreAReDiDenara(double v, Giocatore g)
        {
            foreach(Giocatore gioc in Giocatori1)
            {
                if(g == gioc)
                {
                    gioc._reDiDenara = v;
                }
            }
        }

        public bool AssegnaCartaAGiocatore(Giocatore g)
        {
            if (g.AccettaCartaAndGetReDenara(_mazziere.DaiCarta()))
            {
                return true;
            }else
            {
                return false;
            }
        }

        public int GetSommaPuntate()
        {
            int tot = 0;
            foreach(Giocatore g in Giocatori1)
            {
                if (g != null)
                {
                    tot += g.Puntata;
                }
            }
            return tot;
        }

        public bool ControllaAccettazioneGiocatore(Giocatore g)
        {
            if (g != null)
            {
                if (g.Soldi < 10)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public void AssegnaVincita()
        {
            List<Giocatore> _vincitori=new List<Giocatore>();
            double max = 0;
            int indexMax = 0;
            for(int i=0; i<Giocatori1.Length; i++)
            {
                if (Giocatori1[i] != null)
                {
                    if (Giocatori1[i].GetPunteggioTotale() > max && !Giocatori1[i].SforaLimite())
                    {
                        max = Giocatori1[i].GetPunteggioTotale();
                        indexMax = i;
                    }else if(Giocatori1[i].GetPunteggioTotale() == max && !Giocatori1[i].SforaLimite())
                    {
                        if(Giocatori1[i]._carte.Count < Giocatori1[indexMax]._carte.Count)
                        {
                            indexMax = i;
                        }
                        else if(Giocatori1[i]._carte.Count == Giocatori1[indexMax]._carte.Count && Giocatori1[i]._reDiDenara!=0)
                        {
                            indexMax = i;
                        }
                        else if(Giocatori1[i]._carte.Count == Giocatori1[indexMax]._carte.Count && Giocatori1[indexMax]._reDiDenara == 0)
                        {
                            _vincitori.Add(Giocatori1[i]);
                        }
                    }
                }
            }
            _vincitori.Add(Giocatori1[indexMax]);
            int tot = 0;
            tot = GetSommaPuntate();
            for(int i = 0; i < _vincitori.Count; i++)
            {
                _vincitori[i].Puntata = tot / _vincitori.Count;
            }
        }

        public void ModificaPuntata(Giocatore g, int puntata)
        {
            for(int i=0; i<Giocatori1.Length; i++)
            {
                if (Giocatori1[i].Nick.Equals(g.Nick))
                {
                    Giocatori1[i] = g;
                    Giocatori1[i].Puntata = puntata;
                }
            }
        }

        public List<Giocatore> GetClassifica()
        {
            List<Giocatore> _classifica = new List<Giocatore>();
            foreach(Giocatore g in Giocatori1)
            {
                _classifica.Add(g);
            }
            _classifica.Sort();
            return _classifica;
        }
        //fine Funzione
    }
}
