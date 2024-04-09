using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace NoleggioVeicoliMOVIPLANE
{
    internal class Moto : Veicoli
    {
        private int cc;
        public Moto(string codice, string descrizione, string targa, string marca, int posti, int cc, double prezzo, bool disponibile) : base (codice, descrizione, targa, marca, posti, prezzo, disponibile)
        {
            Codice = codice;
            Descrizione = descrizione;
            Targa = targa;
            Marca = marca;
            Posti = posti;
            CC= cc;
            Prezzo = prezzo;
            Disponibile = true;
        }
        
        public Moto()
        {

        }

        public override String Codice { get { return codice; } set { codice = value; } }
        public override String Descrizione { get { return descrizione; } set { descrizione = value; } }
        public override String Targa { get { return targa; } set { targa = value; } }
        public override String Marca { get { return marca; } set { marca = value; } }
        public override int Posti { get { return posti; } set { posti = value; } }
        public int CC { get { return cc; } set { cc = value; } }
        public override double Prezzo { get { return prezzo; } set { prezzo = value; } }
        public override bool Disponibile { get { return disponibile; } set { disponibile = value; } }
        public override void Inserimento(SqlConnection Cn)
        {
            try
            {
                string query = $"INSERT INTO [Anagrafica Moto] VALUES ('{Codice}', '{Descrizione}', '{Targa}', '{Marca}', {Posti}, {Prezzo}, '{Disponibile}', {CC})";
                SqlCommand cmd = new SqlCommand(query, Cn);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Moto inserita correttamente");
            }
            catch (IOException ex)
            {
                Console.WriteLine("Errore nel database:");
                Console.WriteLine(ex.Message);
            }
        }

        public override void Cancellazione(SqlConnection Cn)
        {
            try
            {
                string query = $"DELETE FROM [Anagrafica Furgoni] WHERE Codice = '{Codice}'";
                SqlCommand cmd = new SqlCommand(query, Cn);
                cmd.ExecuteNonQuery();
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
                string query = "SELECT * FROM [Anagrafica Moto]";
                SqlCommand cmd = new SqlCommand(query, Cn);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(reader.GetString(0) + " " +
                            reader.GetString(1) + " " + reader.GetString(2) + " " +
                            reader.GetString(3) + " " + reader.GetInt32(4) + " " +
                            reader.GetDecimal(5) + " " + reader.GetBoolean(6) + " " +
                            reader.GetInt32(7));
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("Errore nel database:");
                Console.WriteLine(ex.Message);
            }
        }

        public override void StampaVeicolo(SqlConnection Cn)
        {
            try
            {
                string query = $"SELECT * FROM [Anagrafica Moto] WHERE Codice = '{Codice}'";
                SqlCommand cmd = new SqlCommand(query, Cn);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("Codice: " + reader.GetString(0) +
                            "  Descrizione: " + reader.GetString(1) +
                            "  Targa: " + reader.GetString(2) +
                            "  Marca: " + reader.GetString(3));
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("Errore nel database:");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
