using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonBusiness.Eventi
{
    public class Partecipazione
    {

        public Partecipazione()
        {
            Personaggio = string.Empty;
            Giocatore = string.Empty;
            NumeroGiorni = 0;
            Prezzo = 0;
            PX = 0;
            Pagato = true;
            Partecipato = true;
        }

        public long NumeroPG
        { get; set; }

        public long CdEvento
        {get;set;}

        public string Personaggio
        { get; set; }

        public string Giocatore
        { get; set; }

        public int NumeroGiorni
        { get; set; }

        public float Prezzo
        { get; set; }

        public long PX
        { get; set; }

        public bool Pagato
        { get; set; }

        public bool Partecipato
        { get; set; }
    }
}
