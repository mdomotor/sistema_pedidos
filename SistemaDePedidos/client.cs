using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDePedidos
{
    class Client
    {
        public string code;
        public string companyName;
        public string cnpj;
        public string address;
        public string city;
        public string state;
        public string zipcode;

        public Client()
        {
        }
       
        public static string PATH
        {
            get
            {
                return "C:\\Users\\42566937850\\";
            }
        }
        public static string FILE
        {
            get
            {
                return PATH + "Clientes.txt";
            }
        }
        
        public static int count()
        {
            StreamReader sr = new StreamReader(FILE, Encoding.UTF8);
            int count = 0;

            while (sr.ReadLine() != null)
            {
                count++;
            }

            sr.Close();
            return count;
        }

        public static Client[] all()
        {
            Client[] clients = new Client[count()];
            Client client;
            StreamReader sr = new StreamReader(FILE, Encoding.UTF8);

            string row = null;
            int position = 0;
            while ((row = sr.ReadLine()) != null)
            {
                string[] columns = row.Split(';');
                client = new Client();
                client.code = columns[0];
                client.companyName = columns[1];
                client.cnpj = columns[2];
                client.address = columns[3];
                client.city = columns[4];
                client.state = columns[5];
                client.zipcode = columns[6];

                clients[position] = client;
                position++;
            }
            sr.Close();

            return clients;
        }

        public static void create(string code, string companyName, string cnpj, string address, string city, string state, string zipcode)
        {
            StreamWriter arq = new StreamWriter(FILE, true, Encoding.UTF8);
            arq.WriteLine(code + ";" + companyName + ";" + cnpj + ";" + address + ";" + city + ";" + state + ";" + zipcode);
            arq.Close();
        }

        public static void update(int row, Client c)
        {
            Client[] clients = all();
            clients[row] = c;

            StreamWriter writer = new StreamWriter(FILE, false, Encoding.UTF8);

            foreach (Client client in clients)
            {
                string line = client.code + ";" + client.companyName + ";" + client.cnpj + ";" + client.address + ";" + client.city + ";" + client.state + ";" + client.zipcode;
                writer.WriteLine(line);
            }

            writer.Close();
        }

        public static void delete(string code)
        {
            Client[] clients = all();

            StreamWriter writer = new StreamWriter(FILE, false, Encoding.UTF8);

            foreach (Client client in clients)
            {
                if (client.code == code) continue;
                string line = client.code + ";" + client.companyName + ";" + client.cnpj + ";" + client.address + ";" + client.city + ";" + client.state + ";" + client.zipcode;
                writer.WriteLine(line);
            }

            writer.Close();

        }
    }
}
