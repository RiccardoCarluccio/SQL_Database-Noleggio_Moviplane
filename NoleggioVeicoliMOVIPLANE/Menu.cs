using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoleggioVeicoliMOVIPLANE
{
    internal class Menu
    {
        static int sceltaUtente;
        public int SceltaOperazione()
        {
            Console.WriteLine("Scegli operazione:\n" +
                        "1.Gestione noleggi\n" +
                        "2.Anagrafica veicoli\n" +
                        "3.Stampe\n" +
                        "9.Esci");
            sceltaUtente = Convert.ToInt32(Console.ReadLine());
            return sceltaUtente;
        }

        public int GestioneNoleggi()
        {
            Console.WriteLine("1.Ritiro furgone\n" +
                "2.Consegna furgone\n" +
                "3.Ritiro automobile\n" +
                "4.Consegna automobile\n" +
                "5.Ritiro moto\n" +
                "6.Consegna moto\n" +
                "9.Concludi operazioni");
            sceltaUtente = Convert.ToInt32(Console.ReadLine());
            return sceltaUtente;
        }

        public int AnagraficaVeicoli()
        {
            Console.WriteLine("1.Inserimento furgone\n" +
                "2.Cancellazione furgone\n" +
                "3.Inserimento automobile\n" +
                "4.Cancellazione automobile\n" +
                "5.Inserimento moto\n" +
                "6.Cancellazione moto\n" +
                "9.Concludi operazioni");
            sceltaUtente = Convert.ToInt32(Console.ReadLine());
            return sceltaUtente;
        }

        public int StampaVeicoli()
        {
            Console.WriteLine("Scegli stampa:\n" +
                                "1.Stampa noleggi furgoni\n" +
                                "2.Stampa noleggi automobili\n" +
                                "3.Stampa noleggi moto\n" +
                                "4.Stampa elenco furgoni\n" +
                                "5.Stampa elenco automobili\n" +
                                "6.Stampa elenco moto\n" +
                                "9.Concludi operazioni");
            sceltaUtente = Convert.ToInt32(Console.ReadLine());
            return sceltaUtente;
        }

        public void ResetDisponibilità(SqlConnection Cn)
        {
            String query = $"UPDATE [Anagrafica Furgoni] SET Disponibile = 1";
            SqlCommand cmd = new SqlCommand(query, Cn);
            cmd.ExecuteNonQuery();
        }
    }
}
