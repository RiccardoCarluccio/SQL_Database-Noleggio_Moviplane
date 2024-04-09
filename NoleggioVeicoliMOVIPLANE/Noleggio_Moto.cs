using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace NoleggioVeicoliMOVIPLANE
{
    internal class Noleggio_Moto : Noleggio
    {
        public Noleggio_Moto(string codice, string nominativo, DateTime data_ritiro, DateTime data_consegna, int giorni_noleggio, bool disponibilita, String descrizione) : base(codice, nominativo, data_ritiro, data_consegna, giorni_noleggio, disponibilita, descrizione)
        {
            this.codice = codice;
            this.nominativo = nominativo;
            this.data_ritiro = data_ritiro;
            this.data_consegna = data_consegna;
            this.giorni_noleggio = giorni_noleggio;
            this.disponibilita = disponibilita;
            this.descrizione = descrizione;
        }

        public Noleggio_Moto()
        {

        }

        public override string Codice { get { return codice; } set { codice = value; } }
        public override string Nominativo { get { return nominativo; } set { nominativo = value; } }
        public override DateTime Data_Ritiro { get { return data_ritiro; } set { data_ritiro = value; } }
        public override DateTime Data_Consegna { get { return data_consegna; } set { data_consegna = value; } }
        public override int Giorni_Noleggio { get { return giorni_noleggio; } set { giorni_noleggio = value; } }
        public override bool Disponibilita { get { return disponibilita; } set { disponibilita = value; } }
        public override String Descrizione { get { return descrizione; } set { descrizione = value; } }
        public override void Ritiro(SqlConnection Cn)
        {

        }
        public override void Consegna(SqlConnection Cn)
        {

        }
        public override void Stampa(SqlConnection Cn)
        {

        }
    }
}
