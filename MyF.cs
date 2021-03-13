using System;

namespace GestioneCondomini
{
    public class MyF
    {
        public struct ute
        {
            public int id;
            public string nomeutente;
            public string password;
        }
        public struct condomino
        {
            public int id_c;
            public string fiscale;
            public string cognome;
            public string nome;
            public DateTime nascita;
            public string luogoNascita;
            public string telefono;
            public string email;
            public float millesimi;
            public string user;
            public string password;

        }
        public struct riunione
        {
            public int numero;
            public string tipo;
            public DateTime dat;
            public orario ora;
            public string luogo;
            public string oggetto;
            public string odg;
        }
        public struct orario
        {
            public decimal ore;
            public decimal minuti;
        }

        public struct messaggio
        {
            public int id;
            public int mittente;
            public int destinatario;
            public string testo;
            public DateTime Dataora;
        }

    }
}
