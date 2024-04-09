using System.Data;
using System.Linq.Expressions;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;

namespace NoleggioVeicoliMOVIPLANE
{
    internal class Program
    {
        static int sceltaUtente;
        static char confermaUtente;
        static double prezzoNoleggio;

        static void Main(string[] args)
        {
            Noleggio_Furgone nf = new Noleggio_Furgone();
            Noleggio_Automobile na = new Noleggio_Automobile();
            Noleggio_Moto nm = new Noleggio_Moto();
            Furgone f = new Furgone();
            Automobile a = new Automobile();
            Moto m = new Moto();

            Menu menu = new Menu();
            string login = "Data Source=DESKTOP-KUU0OSI;Initial Catalog=MOVIPLANE;Integrated Security=True;Trust Server Certificate=True";

            try
            {
                SqlConnection Cn = new SqlConnection(login);
                Cn.Open();
                // menu.ResetDisponibilità(Cn);
                do
                {
                    sceltaUtente = menu.SceltaOperazione();
                    switch (sceltaUtente)
                    {
                        // GESTIONE NOLEGGI
                        case 1:
                            sceltaUtente = menu.GestioneNoleggi();
                            switch (sceltaUtente)
                            {
                                case 1:
                                    Console.WriteLine("Inserisci nominativo");
                                    nf.Nominativo = Console.ReadLine();
                                    Console.WriteLine("Inserisci la data di noleggio in formato YYYY-MM-DD");
                                    nf.Data_Ritiro = Convert.ToDateTime(Console.ReadLine()).Date;
                                    Console.WriteLine("Inserisci giorni di noleggio");
                                    nf.Giorni_Noleggio = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Inserisci il tipo di furgone da noleggiare");
                                    nf.Descrizione = Console.ReadLine();
                                    nf.Stampa(Cn);
                                    Console.WriteLine("Inserisci il codice del furgone da noleggiare");
                                    nf.Codice = Console.ReadLine();
                                    // non si continua nel caso di mancanza di risultati
                                    // prezzo: select prezzo from anagrafica where codice = codice
                                    Console.WriteLine("Confermi il noleggio? S/N");
                                    confermaUtente = Convert.ToChar(Console.ReadLine().ToLower());
                                    if (confermaUtente == 's')
                                    {
                                        nf.Ritiro(Cn);
                                        Console.WriteLine("Furgone noleggiato corettamente");
                                    }
                                    else if (confermaUtente == 'n')
                                        Console.WriteLine("Noleggio annullato");
                                    break;

                                case 2:
                                    Console.WriteLine("Inserisci il codice del furgone da consegnare");
                                    nf.Codice = Console.ReadLine();
                                    //stampa descrizione, targa, marca, prezzo \n nominativo \n data inizio noleggio \n giorni noleggio
                                    Console.WriteLine("Confermi la consegna?");
                                    confermaUtente = Convert.ToChar(Console.ReadLine().ToLower());
                                    if (confermaUtente == 's')
                                    {
                                        nf.Consegna(Cn);
                                        Console.WriteLine("Furgone consegnato corettamente");
                                    }
                                    else if (confermaUtente == 'n')
                                        Console.WriteLine("Noleggio annullato");
                                    break;

                                default:
                                    break;
                            }
                            break;

                        // ANAGRAFICA VEICOLI
                        case 2:
                            sceltaUtente = menu.AnagraficaVeicoli();
                            switch (sceltaUtente)
                            {
                                case 1:
                                    Console.WriteLine("Inserire codice del veicolo");
                                    f.Codice = Console.ReadLine();
                                    Console.WriteLine("Inserire descrizione");
                                    f.Descrizione = Console.ReadLine();
                                    Console.WriteLine("Inserire targa");
                                    f.Targa = Console.ReadLine();
                                    Console.WriteLine("Inserire marca");
                                    f.Marca = Console.ReadLine();
                                    Console.WriteLine("Inserire numero di posti");
                                    f.Posti = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Inserire numero di porte");
                                    f.Porte = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Inserire prezzo");
                                    f.Prezzo = Convert.ToDouble(Console.ReadLine());
                                    f.Disponibile = true;
                                    Console.WriteLine("Confermi la registrazione? S/N");
                                    confermaUtente = Convert.ToChar(Console.ReadLine().ToLower());
                                    if (confermaUtente == 's')
                                    {
                                        f.Inserimento(Cn);
                                        Console.WriteLine("Furgone inserito correttamente");
                                    }
                                    else if (confermaUtente == 'n')
                                        Console.WriteLine("Registrazione annullata");
                                    break;

                                case 2:
                                    Console.WriteLine("Inserire il codice del furgone da cancellare");
                                    f.Codice = Console.ReadLine();
                                    f.StampaVeicolo(Cn);
                                    Console.WriteLine("Confermi la cancellazione? S/N");
                                    confermaUtente = Convert.ToChar(Console.ReadLine().ToLower());
                                    if (confermaUtente == 's')
                                    {
                                        f.Cancellazione(Cn);
                                        Console.WriteLine("Furgone eliminato correttamente");
                                    }
                                    else if (confermaUtente == 'n')
                                    {
                                        Console.WriteLine("Cancellazione annullata");
                                    }
                                    break;

                                case 3:
                                    Console.WriteLine("Inserire codice del veicolo");
                                    a.Codice = Console.ReadLine();
                                    Console.WriteLine("Inserire descrizione");
                                    a.Descrizione = Console.ReadLine();
                                    Console.WriteLine("Inserire targa");
                                    a.Targa = Console.ReadLine();
                                    Console.WriteLine("Inserire marca");
                                    a.Marca = Console.ReadLine();
                                    Console.WriteLine("Inserire numero di posti");
                                    a.Posti = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Inserire il tipo");
                                    a.Tipo = Convert.ToChar(Console.ReadLine().ToUpper());
                                    Console.WriteLine("Inserire prezzo");
                                    a.Prezzo = Convert.ToDouble(Console.ReadLine());
                                    a.Disponibile = true;
                                    Console.WriteLine("Confermi la registrazione? S/N");
                                    confermaUtente = Convert.ToChar(Console.ReadLine().ToLower());
                                    if (confermaUtente == 's')
                                    {
                                        a.Inserimento(Cn);
                                        Console.WriteLine("Automobile inserita correttamente");
                                    }
                                    else if (confermaUtente == 'n')
                                        Console.WriteLine("Registrazione annullata");
                                    break;

                                case 4:
                                    Console.WriteLine("Inserire il codice dell'automobile da cancellare");
                                    a.Codice = Console.ReadLine();
                                    a.StampaVeicolo(Cn);
                                    Console.WriteLine("Confermi la cancellazione? S/N");
                                    confermaUtente = Convert.ToChar(Console.ReadLine().ToLower());
                                    if (confermaUtente == 's')
                                    {
                                        a.Cancellazione(Cn);
                                        Console.WriteLine("Automobile eliminata correttamente");
                                    }
                                    else if (confermaUtente == 'n')
                                    {
                                        Console.WriteLine("Eliminazione annullata");
                                    }
                                    break;

                                case 5:
                                    Console.WriteLine("Inserire codice del veicolo");
                                    m.Codice = Console.ReadLine();
                                    Console.WriteLine("Inserire descrizione");
                                    m.Descrizione = Console.ReadLine();
                                    Console.WriteLine("Inserire targa");
                                    m.Targa = Console.ReadLine();
                                    Console.WriteLine("Inserire marca");
                                    m.Marca = Console.ReadLine();
                                    Console.WriteLine("Inserire numero di posti");
                                    m.Posti = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Inserire la cilindrata");
                                    m.CC = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Inserire prezzo");
                                    m.Prezzo = Convert.ToDouble(Console.ReadLine());
                                    m.Disponibile = true;
                                    m.Inserimento(Cn);
                                    break;

                                case 6:
                                    Console.WriteLine("Inserire il codice della moto da cancellare");
                                    m.Codice = Console.ReadLine();
                                    m.StampaVeicolo(Cn);
                                    Console.WriteLine("Confermi la cancellazione? S/N");
                                    confermaUtente = Convert.ToChar(Console.ReadLine().ToLower());
                                    if (confermaUtente == 's')
                                    {
                                        m.Cancellazione(Cn);
                                        Console.WriteLine("Automobile eliminata correttamente");
                                    }
                                    else if (confermaUtente == 'n')
                                    {
                                        Console.WriteLine("Eliminazione annullata");
                                    }
                                    break;

                                default:
                                    break;
                            }
                            break;

                        // STAMPA
                        case 3:                           
                            sceltaUtente = menu.StampaVeicoli();
                            switch(sceltaUtente)
                            {
                                case 4:
                                    f.Stampa(Cn);
                                    break;

                                case 5:
                                    a.Stampa(Cn);
                                    break;

                                case 6:
                                    m.Stampa(Cn);
                                    break;

                                default:
                                    break;
                            }
                            break;

                        default:
                            break;
                    }

                } while (sceltaUtente != 9);
            }
            catch (IOException ex)  //errori di database, connessione, ecc.
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Errore nel database");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

// TO DO LIST:
// refactoring delle funzioni di noleggio. Non ci voglio i "WriteLine" dentro
// aggiungere "Sql parameters" es.: cmd.Parameters.AddWithValue("@Codice", Codice);
// far selezionare all'utente solo 's' o 'n'
