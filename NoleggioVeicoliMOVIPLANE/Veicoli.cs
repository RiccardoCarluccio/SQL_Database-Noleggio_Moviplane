using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace NoleggioVeicoliMOVIPLANE
{
    internal abstract class Veicoli
    {
        protected String codice, descrizione, targa, marca;
        protected int posti;
        protected double prezzo;
        protected bool disponibile;

        public Veicoli(string codice, string descrizione, string targa, string marca, int posti, double prezzo, bool disponibile)
        {
            this.codice = codice;
            this.descrizione = descrizione;
            this.targa = targa;
            this.marca = marca;
            this.posti = posti;
            this.prezzo = prezzo;
            this.disponibile = disponibile;
        }

        public Veicoli()
        {

        }

        public abstract String Codice { get; set; }
        public abstract String Descrizione { get; set; }
        public abstract String Targa { get; set; }
        public abstract String Marca { get; set; }
        public abstract int Posti { get; set; }
        public abstract double Prezzo { get; set; }
        public abstract bool Disponibile {  get; set; }

        public abstract void Inserimento(SqlConnection Cn);
        public abstract void Cancellazione(SqlConnection Cn);
        public abstract void Stampa(SqlConnection Cn);
        public abstract void StampaVeicolo(SqlConnection Cn);
    }
}
