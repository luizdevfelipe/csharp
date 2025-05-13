using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;
using System.Data;
using MySql.Data.MySqlClient;

namespace busca_paralela_db
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime hora_ini, hora_fim;

            hora_ini = DateTime.Now;

            var t1 = new Thread(() => leitura1());
            var t2 = new Thread(() => leitura2());

            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();

            hora_fim = DateTime.Now;

            var tempo = hora_fim - hora_ini;
            Console.WriteLine("\nTempo total: " + tempo);
        }

        public static void leitura1()
        {
            int contador = 0;
            MySqlConnection conexao = new MySqlConnection("server=localhost;port=3308;database=progpar;uid=root;pwd=");
            conexao.Open();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = conexao;
            comando.CommandText = "SELECT * FROM cadfunc WHERE RE >= 10000 AND RE < 35000";

            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                contador++;
            }
            conexao.Close();

            Console.WriteLine("Total de leituras: " + contador);
        }

        public static void leitura2()
        {
            int contador = 0;
            MySqlConnection conexao = new MySqlConnection("server=127.0.0.1;port=3308;database=progpar;uid=root;pwd=");
            conexao.Open();

            MySqlCommand comando = new MySqlCommand();
            comando.Connection = conexao;
            comando.CommandText = "SELECT * FROM cadfunc WHERE RE >= 35000 AND RE <= 60000";

            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                contador++;
            }
            conexao.Close();

            Console.WriteLine("Total de leituras: " + contador);
        }
    }
}
