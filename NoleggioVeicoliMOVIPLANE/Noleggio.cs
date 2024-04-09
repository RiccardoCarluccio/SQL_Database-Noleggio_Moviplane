using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace NoleggioVeicoliMOVIPLANE
{
    internal abstract class Noleggio
    {
        protected String codice, nominativo, descrizione;
        protected DateTime data_ritiro, data_consegna;
        protected int giorni_noleggio;
        protected bool disponibilita;

        public Noleggio(string codice, string nominativo, DateTime data_ritiro, DateTime data_consegna, int giorni_noleggio, bool disponibilita, String descrizione)
        {
            this.codice = codice;
            this.nominativo = nominativo;
            this.data_ritiro = data_ritiro;
            this.data_consegna = data_consegna;
            this.giorni_noleggio = giorni_noleggio;
            this.disponibilita = disponibilita;
            this.descrizione = descrizione;
        }

        public Noleggio()
        {

        }

        public abstract String Codice { get; set; }
        public abstract String Nominativo { get; set; }
        public abstract DateTime Data_Ritiro { get; set; }
        public abstract DateTime Data_Consegna { get; set; }
        public abstract int Giorni_Noleggio { get; set; }
        public abstract bool Disponibilita { get; set; }
        public abstract String Descrizione { get; set; }

        public abstract void Ritiro(SqlConnection Cn);
        public abstract void Consegna(SqlConnection Cn);
        public abstract void Stampa(SqlConnection Cn);
    }
}
