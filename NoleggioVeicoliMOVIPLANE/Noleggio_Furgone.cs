using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace NoleggioVeicoliMOVIPLANE
{
    internal class Noleggio_Furgone : Noleggio
    {
        public Noleggio_Furgone(string codice, string nominativo, DateTime data_ritiro, DateTime data_consegna, int giorni_noleggio, bool disponibilita, String descrizione) : base(codice, nominativo, data_ritiro, data_consegna, giorni_noleggio, disponibilita, descrizione)
        {
            this.codice = codice;
            this.nominativo = nominativo;
            this.data_ritiro = data_ritiro;
            this.data_consegna = data_consegna;
            this.giorni_noleggio = giorni_noleggio;
            this.disponibilita = disponibilita;
            this.descrizione = descrizione;
        }

        public Noleggio_Furgone()
        {

        }

        public override string Codice { get { return codice; } set { codice = value; } }
        public override string Nominativo { get { return nominativo; } set { nominativo = value; } }
        public override DateTime Data_Ritiro { get { return data_ritiro; } set { data_ritiro = value; } }
        public override DateTime Data_Consegna { get { return data_consegna; } set { data_consegna = value; } }
        public override int Giorni_Noleggio { get { return giorni_noleggio; } set { giorni_noleggio = value; } }
        public override bool Disponibilita { get { return disponibilita; } set { disponibilita = value; } }
        public override string Descrizione { get { return descrizione; } set { descrizione = value; } }
        
        public override void Ritiro(SqlConnection Cn)
        {
            try
            {
                String query = $"UPDATE [Anagrafica Furgoni] SET Disponibile = 0 WHERE Codice = '{Codice}' AND Descrizione = '{Descrizione}'";
                SqlCommand cmd = new SqlCommand(query, Cn);
                cmd.Parameters.AddWithValue("@Codice", Codice);
                cmd.Parameters.AddWithValue("@Descrizione", Descrizione);
                cmd.ExecuteNonQuery();

                query = $"INSERT INTO [Noleggio Furgoni] (Codice, Nominativo, [Data Noleggio], Giorni) VALUES ('{Codice}', '{Nominativo}', {Data_Ritiro}, {Giorni_Noleggio})";
                cmd = new SqlCommand(query, Cn);
                cmd.Parameters.AddWithValue("@Codice", Codice);
                cmd.Parameters.AddWithValue("@Nominativo", Nominativo);
                cmd.Parameters.AddWithValue("@DataRitiro", Data_Ritiro);
                cmd.Parameters.AddWithValue("@GiorniNoleggio", Giorni_Noleggio);
                cmd.ExecuteNonQuery();
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public override void Consegna(SqlConnection Cn)
        {
            try
            {
                String query = $"DELETE FROM [Noleggio Furgoni] WHERE Codice = '{Codice}'";
                SqlCommand cmd = new SqlCommand(query, Cn);
                cmd.ExecuteNonQuery();

                query = $"UPDATE [Anagrafica Furgoni] SET Disponibile = 1 WHERE Codice = '{Codice}'";
            }
            catch (IOException ex)
            {
                Console.WriteLine("Errore nel database:");
                Console.WriteLine(ex.Message);
            }
        }
        public override void Stampa(SqlConnection Cn)
        {
            try
            {
                String query = $"SELECT * FROM [Anagrafica Furgoni] WHERE Descrizione = '{Descrizione}' AND Disponibile = 1";
                SqlCommand cmd = new SqlCommand(query, Cn);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("Codice: " + reader.GetString(0) +
                                "  Descrizione: " + reader.GetString(1) +
                                "  Targa: " + reader.GetString(2) +
                                "  Marca: " + reader.GetString(3) +
                                "  Prezzo: " + reader.GetDecimal(5));
                        }
                    }
                    else
                    {
                        Console.WriteLine("Non ci sono furgoni disponibili che corrispondono a questa descrizione\n" +
                            "Consigliamo di usare l'operazione di stampa per visualizzare tutti i furgoni disponibili");
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
